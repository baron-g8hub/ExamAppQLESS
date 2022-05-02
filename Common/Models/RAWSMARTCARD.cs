using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public class RAWSMARTCARD
    {
        [Key]
        [Column("SmartCardID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SmartCardID { get; set; }

        public string? SmartCardName { get; set; }

        public int? SerialNumber { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? ActivatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? DeactivatedDate { get; set; }

        public bool? IsValid { get; set; }

        [ConcurrencyCheck]
        [Timestamp]
        public byte[]? RowVersion { get; set; }


        public ICollection<TransportCard>? TransportCards { get; set; }


        //[NotMapped]
        //public bool MyColumnBool
        //{
        //    get
        //    {
        //        return (IsActive == 1);
        //    }
        //}

        //public int MyColumn { get; set; }
    }
}
