using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GNForm3C_.Areas.MST_ExpenseType.Models
{
    public class MST_ExpenseTypeModel
    {
        public int? ExpenseTypeID {  get; set; }
        [Required]
        public string? ExpenseType { get; set; }
        public string? Remarks { get; set; }
        [Required]
        [DisplayName("Hospital Name")]
        public int? HospitalID { get; set; }
        public string Hospital { get; set; }
        public DateTime Created { get; set; } 
        public DateTime Modified { get; set; } 
    }
    public class ExpenseTypeDropdownModel
    {
        public int ExpenseTypeID { get; set; }
        public string? ExpenseType { get; set; }
    }
}
