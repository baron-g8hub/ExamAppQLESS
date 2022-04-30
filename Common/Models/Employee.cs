using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Models
{
    public class Employee
    {
        [Column("EmployeeID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }

        public string? EmployeeFirstName { get; set; }

        public string? EmployeeLastName { get; set; }

        public string? BranchCode { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }

        public bool? IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? CreatedBy { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UpdatedDate { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? UpdatedBy { get; set; }

        [Key]
        public string? EmployeeUID { get; set; }
        public GenEmpUID? GenEmpUID { get; set; }

    }
}
