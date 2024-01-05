
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GNForm3C_.Areas.ACC_Expense.Models
{
    public class ACC_ExpenseModel
    {
        public int? ExpenseID { get; set; }
        [Required(ErrorMessage ="Please Select Expense Type")]
        [DisplayName("Expense Type")]
        public int? ExpenseTypeID { get; set; }
        public string ExpenseType { get; set; }
		[Required(ErrorMessage = "Please Select Financial Year")]
		[DisplayName("Fin Year Name")]
        public int? FinYearID { get; set; }
        public string FinYearName { get; set; }
        [Required(ErrorMessage ="Please Select Hospital")]
        [DisplayName("Hospital Name")]
        public int? HospitalID { get; set; }
        public string Hospital { get; set; }
		[Required(ErrorMessage ="Please Enter Amount")]
		[DisplayName("Amount")]
		public decimal? Amount { get; set; }
        [Required(ErrorMessage ="Please Enter Expense Date")]
        [DisplayName("Expense Date")]
        public DateTime? Date { get; set; }
        public string? Note {  get; set; }
        public string Remarks {  get; set; }
        public DateTime? Created { get; set; } 
        public DateTime? Modified { get; set; } 

    }
}
