using GNForm3C_.Areas.MST_FinYear.Models;
using GNForm3C_.Areas.MST_Hospital.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GNForm3C_.Areas.SEC_User.Models
{
    public class SEC_UserModel
    {
        public int? UserID { get; set; }
        [Required(ErrorMessage = "Please Enter User Name")]
        [DisplayName("Please Enter User Name")]
        public string? UserName { get; set; }
        [Required(ErrorMessage ="Please Select Hospital")]
        [DisplayName("Hospital Name")]
        public int HospitalID { get; set; }
        public string Hospital { get; set; }
        [Required(ErrorMessage ="Please Enter Password")]
        [DisplayName("Password")]
        public string? Password { get; set; }
		[Required(ErrorMessage = "Please Enter Confirm Password")]
		[DisplayName("Confirm Password")]
        public string? ConfirmPassword { get; set; }
        [Required]
        public bool? IsActive { get; set; }
        public DateTime? Created { get; set; } 
        public DateTime? Modified { get; set; }

		public int? FinYearID { get; set; }
		public string? FinYearName { get; set; }

	}
    public class Login_SEC_UserModel
    {


        [Required(ErrorMessage = "Please Enter User Name")]
        [DisplayName("User Name")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Please Select Hospital")]
        [DisplayName("Hospital")]
        public int? HospitalID { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [DisplayName("Password")]
        public string? Password { get; set; }

    }
}
