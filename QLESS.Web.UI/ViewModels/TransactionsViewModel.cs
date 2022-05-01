using Common.Models;

namespace QLESS.Web.UI.ViewModels
{
    public class TransactionsViewModel
    {
        public TransactionsViewModel()
        {
            CardTransaction = new CardTransaction();
            TransportCard = new TransportCard();
        }

        public CardTransaction CardTransaction { get; set; }

        public TransportCard TransportCard { get; set; }

        
        public decimal? AmountTotal { get; set; }
        public decimal? AmountReceived { get; set; }
        public double? DiscountPercentage { get; set; } = 0;
        public decimal? AmountDiscounted { get; set; } = decimal.Zero;
        public decimal? AmountChange { get; set; }
    }
}
