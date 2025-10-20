using System.ComponentModel.DataAnnotations;

namespace BuOdeh.Data.Authentication
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
