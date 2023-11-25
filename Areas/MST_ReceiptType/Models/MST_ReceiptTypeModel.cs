using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GNForm3C_.Areas.MST_ReceiptType.Models
{
    public class MST_ReceiptTypeModel
    {
        public int? ReceiptTypeID { get; set; }
		[Required]
		[DisplayName("Receipt Type")]
		public string? ReceiptTypeName { get; set;}
		[Required]
		[DisplayName("Print Name")]
		public string? PrintName { get; set; }
        public bool? IsDefault { get; set; }
        public string? Remarks { get; set; }
        [Required]
        [DisplayName("Hospital Name")]
        public int? HospitalID { get; set; }
        public string? Hospital { get; set; }
        public DateTime? Created { get; set; }
        public DateTime Modified { get; set; }
    }
	public class ReceiptDropDownModel
	{
		public int? ReceiptTypeID { get; set; }
		public string? ReceiptTypeName { get; set; }
	}
}
