using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GNForm3C_.Areas.SEC_User.Models
{
    public class SEC_UserModel
    {

        public int? UserID { get; set; }
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Hospital Name")]
        public int? HospitalID { get; set; }
        public string Hospital { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [DisplayName("Confirm Password")]
        public string? ConfirmPassword { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;
    }
}
