using Common.Models;

namespace QLESS.Web.UI.ViewModels
{
    public class TransportCardViewModel
    {
        public TransportCardViewModel()
        {
            Entity = new TransportCard();  
            EntityList = new List<TransportCard>();
        }

        public TransportCard Entity { get; set; }
        public List<TransportCard> EntityList { get; set; }
    }
}
