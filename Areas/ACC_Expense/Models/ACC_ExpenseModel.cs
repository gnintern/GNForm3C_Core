
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GNForm3C_.Areas.ACC_Expense.Models
{
    public class ACC_ExpenseModel
    {
        public int? ExpenseID { get; set; }
        [Required]
        [DisplayName("Expense Type")]
        public int? ExpenseTypeID { get; set; }
        public string ExpenseType { get; set; }
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
        [DisplayName("Expense Date")]
        public DateTime Date { get; set; } = DateTime.Now;
        public string? Note {  get; set; }
        public string Remarks {  get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; } 

    }
}
