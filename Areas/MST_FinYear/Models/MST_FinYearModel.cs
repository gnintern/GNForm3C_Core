using System.ComponentModel.DataAnnotations;

namespace GNForm3C_.Areas.MST_FinYear.Models
{
    public class MST_FinYearModel
    {
        public int? FinYearID { get; set; }
        public string FinYearName { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
        public DateTime? Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;
    }
    public class FinYearDropdownModel
    {
        public int? FinYearID { get; set; }
        public string? FinYearName { get; set; }

    }
}
