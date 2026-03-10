using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuOdeh.Data.HrPayroll
{
    [Table("EmployeeProduction")]
    public class EmployeeProduction
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int EmployeeID { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime InputDate { get; set; }

        [Required]
        public int CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; } = DateTime.Now;

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Angka produksi harus lebih dari 0")]
        public decimal NumberProduced { get; set; }

        public bool IsDeleted { get; set; } = false;

        // Navigation property
        [NotMapped]
        public Employee Employee { get; set; }

        [Required]
        public string Satuan { get; set; } = "";
    }
}