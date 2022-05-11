using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class CardTransaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CardTransactionID")]
        public Guid CardTransactionID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy h:mm tt}")]
        [Column(TypeName = "datetime")]
        public DateTime PostingDate { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "smallmoney")]
        public decimal? AmountTotal { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? AmountReceived { get; set; }

        public double? DiscountPercentage { get; set; } = 0;

        [Column(TypeName = "smallmoney")]
        public decimal? AmountDiscounted { get; set; } = decimal.Zero;

        [Column(TypeName = "smallmoney")]
        public decimal? AmountChange { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }

        public TransportCard? TransportCard { get; set; }

        public TransportCardTrip? TransportCardTrip { get; set; }
    }
}
