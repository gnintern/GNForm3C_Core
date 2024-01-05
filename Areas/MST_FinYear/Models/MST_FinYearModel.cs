using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GNForm3C_.Areas.MST_FinYear.Models
{
    public class MST_FinYearModel
    {
        public int? FinYearID { get; set; }
        public string? FinYearName { get; set; }
        [Required(ErrorMessage ="Please Enter From Date")]
        [DisplayName("From Date")]
        public DateTime FromDate { get; set; }
		[Required(ErrorMessage = "Please Enter To Date")]
		[DisplayName("To Date")]
		public DateTime ToDate { get; set; }
        public DateTime? Created { get; set; } 
        public DateTime Modified { get; set; } 
    }
    public class FinYearDropdownModel
    {
        public int? FinYearID { get; set; }
        public string? FinYearName { get; set; }

    }
}
