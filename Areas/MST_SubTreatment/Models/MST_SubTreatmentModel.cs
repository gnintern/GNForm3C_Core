using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace GNForm3C_.Areas.MST_SubTreatment.Models
{
    public class MST_SubTreatmentModel
    {
        public int? SubTreatmentID { get; set; }
        [Required]
        [DisplayName("SubTreatment Name")]
        public string? SubTreatmentName { get; set; }
        public int? SequenceNo { get; set; }
        public decimal? Rate { get; set; }
        public bool? IsInGrid { get; set; }
        public bool? IsPerDay { get; set; }
      
        public string? Remarks { get; set; }
        [Required]
        [DisplayName("Hospital Name")]
        public int? HospitalID { get; set; }  
        public string? Hospital { get; set; }
       
        public string? DefaultUnit { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;
    }
}
