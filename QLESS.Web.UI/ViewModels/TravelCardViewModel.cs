using Common.Models;

namespace QLESS.Web.UI.ViewModels
{
    public class TravelCardViewModel
    {
        public TravelCardViewModel()
        {
            TravelCardsList = new List<TravelCards>();
        }


        public List<TravelCards> TravelCardsList { get; set; }
    }
}
