using System.ComponentModel.DataAnnotations;

namespace BuOdeh.Data.Setting
{
    public class Unit
    {
        [Key]
        public int UnitId { get; set; }
        [Required]
        public string UnitName { get; set; }
        public int NoOfDecimalplaces { get; set; }
        public int CompanyId { get; set; }
        public DateTime? AddedDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
