using Common.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLESS.Web.UI.ViewModels
{
    public class TransportCardViewModel
    {
        public TransportCardViewModel()
        {
            Entity = new TransportCard();
            TrainStation = new TrainStation();
            TrainStationsList = new List<TrainStation>();
            EntityList = new List<TransportCard>();
            RAWSMARTCARDList = new List<RAWSMARTCARD>();
            CardTransaction = new CardTransaction();
            CardTransactionList = new List<CardTransaction>();
            Trip = new TransportCardTrip();
            TransportCardTripsList = new List<TransportCardTrip>();
            OriginList = new List<SelectListItem> { new SelectListItem { Value = "0", Text = " Origin Station ", Selected = true } };
            DestinationList = new List<SelectListItem> { new SelectListItem { Value = "0", Text = " Destination Station ", Selected = true } };
        }

        public TransportCard Entity { get; set; }
        public List<TransportCard> EntityList { get; set; }
        public List<RAWSMARTCARD> RAWSMARTCARDList { get; set; }
        public CardTransaction CardTransaction { get; set; }
        public List<CardTransaction> CardTransactionList { get; set; }
        public TrainStation TrainStation { get; set; }
        public List<TrainStation> TrainStationsList { get; set; }

        public List<SelectListItem> OriginList { get; set; }
        public List<SelectListItem> DestinationList { get; set; }

        public TransportCardTrip Trip { get; set; }
        public List<TransportCardTrip> TransportCardTripsList { get; set; }


        [Required]
        public int TransportCardID { get; set; }

        public DateTime TravelDate { get; set; } = DateTime.Now;

        [Required]
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Rate { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Trip == Trip.OriginStationCode)
        //    {
        //        yield return new ValidationResult(
        //            $"Classic movies must have a release year no later than {_classicYear}.", new[] { nameof(ReleaseDate) });
        //    }
        //}
    }
}
