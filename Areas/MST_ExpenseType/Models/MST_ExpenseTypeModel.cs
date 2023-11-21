using System.ComponentModel.DataAnnotations;

namespace GNForm3C_.Areas.MST_ExpenseType.Models
{
    public class MST_ExpenseTypeModel
    {
        public int? ExpenseTypeID {  get; set; }
        public string? ExpenseType { get; set; }
        public string? Remarks { get; set; }
        public int? HospitalID { get; set; }
        [Required]
        public string? Hospital { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
