using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public class GenEmpUID
    {
        [Column("GeneratedID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GeneratedID { get; set; }

        public bool IsActive { get; set; } = false;
     
        [Key]
        [Column("GeneratedUID")]
        public string GeneratedUID { get; set; } = null!;

        [Timestamp]
        public byte[]? RowVersion { get; set; }


        public Employee? Employee { get; set; }
    }
}
