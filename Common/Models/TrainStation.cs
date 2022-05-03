using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public class TrainStation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("TrainStationID")]
        public Guid TrainStationID { get; set; }

        public string TrainStationCode { get; set; } = string.Empty;

        public int TrainStationNumber { get; set; } = 1;

        public bool IsActive { get; set; } = true;

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Column(TypeName = "datetime")]
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;

        [StringLength(100)]
        [Unicode(false)]
        public string? CreatedBy { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        public string? UpdatedBy { get; set; }

        [ConcurrencyCheck]
        [Timestamp]
        public byte[]? RowVersion { get; set; }

        public ICollection<TransportCardTrip> TransportCardTrips { get; set; } = null!;
    }
}
