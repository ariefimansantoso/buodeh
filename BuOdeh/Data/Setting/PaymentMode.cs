using System.ComponentModel.DataAnnotations;

namespace BuOdeh.Data.Setting
{
    public class PaymentMode
    {
        [Key]
        public int PaymentmodeId { get; set; }
        public string Name { get; set; }
    }
}
