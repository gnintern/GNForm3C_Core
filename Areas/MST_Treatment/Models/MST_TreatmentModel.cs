using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GNForm3C_.Areas.MST_Treatment.Models
{
    public class MST_TreatmentModel
    {
        public int? TreatmentID {  get; set; }
        [Required]
        public string Treatment { get; set; }
        [Required]
        [DisplayName("Hospital Name")]
        public int? HospitalID { get; set; }
        public string Hospital {  get; set; }
        public string? Remarks { get; set; }
        public DateTime Created { get; set; } 
        public DateTime Modified { get; set; }
    }
	public class TreatementDropDownModel
	{
		public int TreatmentID { get; set; }
		public string Treatment { get; set; }
	}
}
