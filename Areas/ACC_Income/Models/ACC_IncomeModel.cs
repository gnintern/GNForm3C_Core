using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GNForm3C_.Areas.ACC_Income.Models
{
    public class ACC_IncomeModel
    {
        public int? IncomeID { get; set; }
        [Required]
        [DisplayName("Income Type")]
        public int? IncomeTypeID { get; set; }
        public string IncomeType { get; set; }
        [Required]
        [DisplayName("Financial Year")]
        public int? FinYearID { get; set; }
        public string FinYearName { get; set; }
        [Required]
        [DisplayName("Hospital Name")]
        public int? HospitalID { get; set; }
        public string Hospital { get; set; }
        [Required]
        [DisplayName("Amount")]
        public decimal? Amount { get; set; }
        [Required]
        [DisplayName("Income Date")]
        public DateTime Date { get; set; } = DateTime.Now;  
        public string? Note { get; set; }
        public string Remarks { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
