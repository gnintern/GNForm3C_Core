using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GNForm3C_.Areas.MST_IncomeType.Models
{
	public class MST_IncomeTypeModel
	{
		public int? IncomeTypeID { get; set; }
		[Required(ErrorMessage = "Please Enter Income Type")]
		[DisplayName("Income Type")]

		public string? IncomeType { get; set; }
		public string? Remarks { get; set; }
		[Required(ErrorMessage = "Please Select Hospital")]
		[DisplayName("Hospital Name")]
		public int? HospitalID { get; set; }
		public string Hospital { get; set; }
		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
	}
	public class IncomeTypeDropdownModel
    {
        public int IncomeTypeID { get; set; }
        public string? IncomeType { get; set; }
    }
}
