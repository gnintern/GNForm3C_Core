using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GNForm3C_.Areas.MST_Hospital.Models
{
    public class MST_HospitalModel
    {
        public int? HospitalID { get; set; }
        [Required]
        [DisplayName("Hospital Name")]
        public string? Hospital { get; set; }
        [Required]
        [DisplayName("Print Name")]
        public string PrintName { get; set; }
        [Required]
        [DisplayName("Print Line-1")]
        public string PrintLine1 { get; set; }
        [Required]
        [DisplayName("Print Line-2")]
        public string PrintLine2 { get; set; }
        [Required]
        [DisplayName("Print Line-3")]
        public string PrintLine3 { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;
        [Required]
        [DisplayName("Footer Name")]
        public string FooterName { get; set; }
        [Required]
        [DisplayName("Report Header Name")]
        public string ReportHeaderName { get; set; }

    }

    public class HospitalDropDowmModel
    {
        public int? HospitalID { get; set; }
        public string? Hospital { get; set; }
    }
}
