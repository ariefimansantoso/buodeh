using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuOdeh.Data.Setting
{
    [Table("Recipe")]
    public class Recipe
    {
        [Key]
        public int ID { get; set; }

        // The Parent Product (e.g., Peanut Cookie)
        [Required]
        public int ProductId { get; set; }

        [StringLength(500)]
        public string ProductName { get; set; }

        // The Ingredient Product (e.g., Flour, Sugar, Peanut, Butter)
        [Required]
        public int ProductIngredientId { get; set; }

        // Quantity of the ingredient needed
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Quantity { get; set; }

        // Unit of Measure (KG, GR, PCS, LTR, ML)
        [StringLength(50)]
        public string UOM { get; set; }

        // Audit fields
        public bool IsActive { get; set; } = true;

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? AddedDate { get; set; } = DateTime.Now;

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? ModifyDate { get; set; }

        // Navigation properties (optional, for Entity Framework relationships)
        [NotMapped]
        public Product ParentProduct { get; set; }

        [NotMapped]
        public Product IngredientProduct { get; set; }
    }
}