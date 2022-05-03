using Common.Models;

namespace QLESS.Web.UI.ViewModels
{
    public class TransportCardViewModel
    {
        public TransportCardViewModel()
        {
            Entity = new TransportCard();
            TrainStation = new  TrainStation();
            TrainStationsList = new List<TrainStation>();   
            EntityList = new List<TransportCard>();
            RAWSMARTCARDList = new List<RAWSMARTCARD>();
            CardTransaction = new CardTransaction();    
            CardTransactionList = new List<CardTransaction>();  
            TransportCardTrip = new TransportCardTrip();    
            TransportCardTripsList = new List<TransportCardTrip>();
        }

        public TransportCard Entity { get; set; }
        public List<TransportCard> EntityList { get; set; }
        public List<RAWSMARTCARD> RAWSMARTCARDList { get; set; }
        public CardTransaction CardTransaction { get; set; }
        public List<CardTransaction> CardTransactionList { get; set; }
        public TrainStation TrainStation { get; set; }
        public List<TrainStation> TrainStationsList { get; set; }
        public TransportCardTrip TransportCardTrip { get; set; }
        public List<TransportCardTrip> TransportCardTripsList { get; set; }
    }
}
