using Common;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;

namespace QLESS.Web.UI
{
    public class CardTransactionModel : PageModel
    {
        public ApplicationDbContext _context;
        private CancellationTokenSource? _cts = null;
        public CardTransactionModel(ApplicationDbContext context)
        {
            _context = context;
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
            [Display(Name = "CardNumber")]
            public int CardNumber { get; set; }

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

        }


        public async Task OnGetAsync(string? returnUrl = null)
        {
            var cards = await _context.RAWSMARTCARDs.ToListAsync();
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
                if (Input.AmountTotal < 100)
                {
                    if (Input.AmountTotal != null)
                    {
                        ModelState.AddModelError(string.Empty, "Minimum load of 100.");
                        return Page();
                    }
                }
                if (Input.AmountReceived < Input.AmountTotal)
                {
                    if (Input.AmountTotal != null)
                    {
                        ModelState.AddModelError(string.Empty, "Enter valid amount.");
                        return Page();
                    }
                }

                var transaction = new CardTransaction();
                // Get 1 smart Card
                var cards = await _context.RAWSMARTCARDs.ToListAsync();
                // Add Insert into TransportCards ledger and Add Cash Value
                var transportCard = new TransportCard();
                if (cards != null)
                {
                    var smartCard = cards.FirstOrDefault(x => x.IsActive == false);
                    if (smartCard != null)
                    {
                        transportCard.LastUsedDate = DateTime.UtcNow;
                        transportCard.RAWSMARTCARD = smartCard;
                        transportCard.IsPWDCard = false;
                        transportCard.IsSeniorCard = false;
                        transportCard.LoadBalance = Input.AmountTotal;
                        transportCard.IsActive = true;
                        transportCard.SCCNumber = string.Empty;
                        transportCard.PWDNumber = string.Empty;
                        // Insert into TransportCards table
                        await _context.TransportCards.AddAsync(transportCard);
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

                            //var result = await CreateCardTransactionAsync(ct);
                            //if (result > 0)
                            //{
                            //    return LocalRedirect(returnUrl);
                            //}
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

        public async Task<int> CreateCardTransactionAsync(CancellationToken ct)
        {
            IDbContextTransaction? transaction = null;
            //await Task.Delay(5000);
            if (ct.IsCancellationRequested)
            {
                ct.ThrowIfCancellationRequested();
            }
            try
            {
                using (transaction = await _context.Database.BeginTransactionAsync())
                {
                    int records = await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return records;
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                foreach (var entry in ex.Entries)
                {
                    if (entry.Entity is RAWSMARTCARD)
                    {
                        var proposedValues = entry.CurrentValues;
                        var databaseValues = entry.GetDatabaseValues();

                        foreach (var property in proposedValues.Properties)
                        {
                            var proposedValue = proposedValues[property];
                            var databaseValue = databaseValues?[property];
                        }

                        // Refresh original values to bypass next concurrency check
                        if (databaseValues != null)
                        {
                            entry.OriginalValues.SetValues(databaseValues);
                        }
                    }
                    else
                    {
                        throw new NotSupportedException("Unable to save changes. The Entity details was updated by another user. " + entry.Metadata.Name);
                    }
                }
                throw ex;
            }
            catch (DbUpdateException ex)
            {
                SqlException? s = ex.InnerException as SqlException;
                //var errorMessage = $"{ex.Message}" + " {ex?.InnerException.Message}" + " rolling back…";
                transaction?.RollbackAsync();
                throw s!;
            }
        }
    }
}
