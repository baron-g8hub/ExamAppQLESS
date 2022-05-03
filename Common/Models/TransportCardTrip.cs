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

        [DataType(DataType.Currency)]
        [Column(TypeName = "smallmoney")]
        public decimal? AmountTripCharge { get; set; }

        public string? TransportCardTripOperatorCode { get; set; }
    
        public string? OriginStationCode { get; set; }
    
        public string? DestinationStationCode { get; set; }

        public bool HasGateIN { get; set; } = false;

        public bool HasGateOUT { get; set; } = false;

        [ConcurrencyCheck]
        [Timestamp]
        public byte[]? RowVersion { get; set; }

        public TransportCard? TransportCard { get; set; }

        public ICollection<TrainStation>? TrainStations { get; set; }
    }
}
