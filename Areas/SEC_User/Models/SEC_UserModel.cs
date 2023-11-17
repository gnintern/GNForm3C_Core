using System.ComponentModel.DataAnnotations;

namespace GNForm3C_.Areas.SEC_User.Models
{
    public class SEC_UserModel
    {

        public int? UserID { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Hospital { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public int HospitalID { get; set; } = 1;
        public DateTime Modified { get; set; }
    }
}
