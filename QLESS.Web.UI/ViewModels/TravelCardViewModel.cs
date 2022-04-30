using Common.Models;

namespace QLESS.Web.UI.ViewModels
{
    public class TravelCardViewModel
    {
        public TravelCardViewModel()
        {
            Entity = new TravelCard();  
            EntityList = new List<TravelCard>();
        }

        public TravelCard Entity { get; set; }
        public List<TravelCard> EntityList { get; set; }
    }
}
