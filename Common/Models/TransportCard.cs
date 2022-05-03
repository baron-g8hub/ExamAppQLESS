using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Common.Models
{
    public class TransportCard
    {
        [Key]
        [Column("TransportCardID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransportCardID { get; set; }

        [StringLength(150)]
        public string? CardHolder { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? LoadBalance { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy | h: mm tt}")]
        [Column(TypeName = "datetime")]
        public DateTime? LastUsedDate { get; set; } = DateTime.UtcNow;

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy | h: mm tt}")]
        [Column(TypeName = "datetime")]
        public DateTime? ValidityDate { get; set; }


        public bool? IsActive { get; set; } = true;

        [Timestamp]
        public byte[]? RowVersion { get; set; }

        public bool? IsPWDCard { get; set; } = false;
        public bool? IsSeniorCard { get; set; } = false;


        // 10-character length string with “##-####-####” format
        //[SCCNumberMask("99-9999-9999", ErrorMessage = "{0} value does not match the mask {1}.")]

        [Required]
        [StringLength(150)]
        public string? SCCNumber { get; set; }


        // 12-character length string with “####-####-####” format

        [StringLength(150)]
        public string? PWDNumber { get; set; }
        
        public RAWSMARTCARD RAWSMARTCARD { get; set; } = null!;

        public ICollection<CardTransaction>? CardTransactions { get; set; }
        public ICollection<TransportCardTrip>? TransportCardTrips { get; set; }
    }
}
