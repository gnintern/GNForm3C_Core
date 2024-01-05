using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GNForm3C_.Areas.MST_Hospital.Models
{
    public class MST_HospitalModel
    {
        public int? HospitalID { get; set; }
        [Required(ErrorMessage ="Please Select Hospital")]
        [DisplayName("Hospital Name")]
        public string? Hospital { get; set; }
        [Required(ErrorMessage ="Please Enter Print Name")]
        [DisplayName("Print Name")]
        public string? PrintName { get; set; }
        public string? PrintLine1 { get; set; }
        public string? PrintLine2 { get; set; }
        public string? PrintLine3 { get; set; }
        public DateTime Created { get; set; } 
        public DateTime Modified { get; set; } 
        [Required(ErrorMessage ="Please Enter Footer Name")]
        [DisplayName("Footer Name")]
        public string? FooterName { get; set; }
        public string? ReportHeaderName { get; set; }
    }

    public class HospitalDropDowmModel
    {
        public int? HospitalID { get; set; }
        public string? Hospital { get; set; }
    }
}
