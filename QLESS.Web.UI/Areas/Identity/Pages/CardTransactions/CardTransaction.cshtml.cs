using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace QLESS.Web.UI
{
    public class CardTransactionModel : PageModel
    {
        public CardTransactionModel()
        {

        }



        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

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


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            if (ModelState.IsValid)
            {
                //    var user = CreateUser();






            }
            else
            {
                //foreach (var error in result.Errors)
                //{
                //    ModelState.AddModelError(string.Empty, error.Description);
                //}
            }
            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
