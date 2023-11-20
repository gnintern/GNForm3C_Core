namespace GNForm3C_.Areas.MST_Hospital.Models
{
    public class MST_HospitalModel
    {
        public int? HospitalID { get; set; }
        public string Hospital { get; set; }
        public string PrintName { get; set; }
        public string PrintLine1 { get; set; }
        public string PrintLine2 { get; set; }
        public string PrintLine3 { get; set; }
        public DateTime Modified { get; set; }=DateTime.Now;
        public string FooterName { get; set; }
        public string ReportHeaderName { get; set; }

    }

    public class HospitalDropDowmModel
    {
        public int? HospitalID { get; set; }
        public string? Hospital { get; set; }
    }
}
