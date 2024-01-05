using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GNForm3C_.Areas.ACC_Income.Models
{
    public class ACC_IncomeModel
    {
        public int? IncomeID { get; set; }
        [Required(ErrorMessage ="Please Select Income Type")]
        [DisplayName("Income Type")]
        public int? IncomeTypeID { get; set; }
        public string IncomeType { get; set; }
        [Required(ErrorMessage ="Please Select Financial Year")]
        [DisplayName("Financial Year")]
        public int? FinYearID { get; set; }
        public string FinYearName { get; set; }
        [Required(ErrorMessage ="Please Select Hospital")]
        [DisplayName("Hospital Name")]
        public int? HospitalID { get; set; }
        public string Hospital { get; set; }
        [Required(ErrorMessage ="Please Enter Amount")]
        [DisplayName("Amount")]
        public decimal? Amount { get; set; }
        [Required(ErrorMessage ="Please Enter Income Date")]
        [DisplayName("Income Date")]
        public DateTime Date { get; set; } = DateTime.Now;  
        public string? Note { get; set; }
        public string Remarks { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
