using Common;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLESS.Web.UI
{
    public class AddValueCardTransactionModel : PageModel
    {
        public ApplicationDbContext _context;
        private CancellationTokenSource? _cts = null;
        public AddValueCardTransactionModel(ApplicationDbContext context)
        {
            _context = context;
            RAWSMARTCARDList = new List<SelectListItem> { new SelectListItem { Value = "0", Text = "- select card -", Selected = true } };
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; } = null!;

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string? ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>

            public int CardNumber { get; set; }

            [Display(Name = "CardName")]
            public string? CardName { get; set; }

            [Display(Name = "AmountTotal")]
            public decimal? AmountTotal { get; set; }

            [Display(Name = "AmountReceived")]
            public decimal? AmountReceived { get; set; }

            [Display(Name = "DiscountPercentage")]
            public double? DiscountPercentage { get; set; }


            [Display(Name = "AmountDiscounted")]
            public decimal? AmountDiscounted { get; set; }

            [Display(Name = "AmountChange")]
            public decimal? AmountChange { get; set; }

            [DataType(DataType.Currency)]
            [Column(TypeName = "decimal(18, 2)")]
            public decimal? Balance { get; set; }
        }
        public List<SelectListItem> RAWSMARTCARDList { get; set; }



        public async Task OnGetAsync(string? returnUrl = null)
        {
            var transactions = await _context.CardTransactions.ToListAsync();
            var transportCards = await _context.TransportCards.ToListAsync();
            if (transportCards != null)
            {
                var rAWSMARTCARDs = await _context.RAWSMARTCARDs.ToListAsync();
                var list = new List<TransportCard>();
                if (transportCards.Count > 0)
                {
                    list = (from a in transportCards join b in rAWSMARTCARDs on a.RAWSMARTCARD.SmartCardID equals b.SmartCardID select a).ToList();
                    foreach (var item in list)
                    {
                        var total = transactions.FindAll(x => x.TransportCard?.TransportCardID == item.TransportCardID).Sum(x => x.AmountTotal);
                        if (total > 0)
                        {
                            item.LoadBalance = decimal.Parse(total.Value.ToString("0.##"));
                        }
                    }
                }
                RAWSMARTCARDList.AddRange(collection: list.Select(x =>
                new SelectListItem { Value = x.TransportCardID.ToString(), Text = (x.RAWSMARTCARD.SmartCardName + " | LOAD: " + x.LoadBalance) }).ToList());
            }
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            _cts = new CancellationTokenSource();

            // send a cancel after 4000 ms or call cts.Cancel();
            _cts.CancelAfter(4000);

            //Fetch the Token
            CancellationToken ct = _cts.Token;
            if (ModelState.IsValid)
            {
                var transaction = new CardTransaction();
                // Get 1 smart Card
                var cards = await _context.RAWSMARTCARDs.ToListAsync();
                // Add Insert into TransportCards ledger and Add Cash Value
                var transportCard = new TransportCard();
                if (cards != null)
                {
                    var smartCard = cards.FirstOrDefault(x => x.SmartCardID == Input.CardNumber);
                    if (smartCard != null)
                    {
                        transportCard.LastUsedDate = DateTime.UtcNow;
                        transportCard.RAWSMARTCARD = smartCard;
                        transportCard.IsPWDCard = false;
                        transportCard.IsSeniorCard = false;
                        transportCard.LoadBalance += Input.AmountTotal;
                        transportCard.IsActive = true;
                        transportCard.SCCNumber = string.Empty;
                        transportCard.PWDNumber = string.Empty;
                        // Insert into TransportCards table
                        _context.TransportCards.Update(transportCard);
                        var change = Input.AmountTotal - Input.AmountReceived;
                        transaction = new CardTransaction
                        {
                            TransportCard = transportCard,
                            PostingDate = DateTime.Now,
                            AmountTotal = Input.AmountTotal,
                            AmountReceived = Input.AmountReceived,
                            DiscountPercentage = 0,
                            AmountDiscounted = 0,
                            AmountChange = change,
                        };

                        await _context.CardTransactions.AddAsync(transaction);
                        smartCard.IsActive = true;
                        _context.RAWSMARTCARDs.Update(smartCard);
                        // TODO: To use context transactional approach here.
                        IDbContextTransaction? trans = null;
                        try
                        {
                            using (trans = await _context.Database.BeginTransactionAsync())
                            {
                                await _context.SaveChangesAsync();
                                await trans.CommitAsync();
                            }
                        }
                        catch (Exception ex)
                        {
                            if (ex.InnerException is SqlException sqlexception)
                            {
                                ModelState.AddModelError(string.Empty, sqlexception.Message.ToString());
                            }
                            else
                            {
                                ModelState.AddModelError(string.Empty, ex.Message.ToString());
                            }
                        }
                        finally
                        {
                            trans?.RollbackAsync();
                        }
                    }
                }
                Input.AmountTotal = transaction.AmountTotal;
                Input.AmountReceived = transaction.AmountReceived;
                Input.AmountChange = transaction.AmountChange;
                return LocalRedirect(returnUrl);
            }
            // If we got this far, something failed, redisplay form
            return Page();
        }


    }
}
