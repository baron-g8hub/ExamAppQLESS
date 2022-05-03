using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public class TransportCardTrip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TransportCardTripID { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime TransportCardTripDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "smallmoney")]
        public decimal? AmountTripCharge { get; set; }

        public string? TransportCardTripOperatorCode { get; set; }

        public bool HasGateIN { get; set; } = false;

        public bool HasGateOUT { get; set; } = false;

        [ConcurrencyCheck]
        [Timestamp]
        public byte[]? RowVersion { get; set; }
        
        //[InverseProperty("TrainStationFrom")]
        //public TrainStation TrainStationFrom { get; set; } = null!;
        
        //[InverseProperty("TrainStationTo")]
        //public TrainStation TrainStationTo { get; set; } = null!;

    }
}
