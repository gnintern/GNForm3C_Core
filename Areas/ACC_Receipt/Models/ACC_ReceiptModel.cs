using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GNForm3C_.Areas.ACC_Receipt.Models
{
    public class ACC_ReceiptModel
    {
        public int? TransactionID { get; set; }
        public string? Patient { get; set; }
        public int TreatmentID { get; set;}
        public string? Treatment {  get; set; }
        public int HospitalID { get; set; }
        public string? Hospital { get; set; }

        public int? FinYearID {  get; set; }
        public string? FinYearName { get; set; }
        public int? ReceiptTypeID { get; set; }
        public string? ReceiptTypeName { get; set; }
        public decimal? Amount { get; set; }
        public int SerialNo {  get; set; }
        public string? ReferenceDoctor {  get; set; }
        public int? Count {  get; set; }
        public int ReceiptNo { get; set; }
        public DateTime Date { get; set; } 
        public DateTime? DateOfAdmission { get; set; } 
        public DateTime? DateOfDischarge {  get; set; } 
        public decimal? Deposite { get; set; }
        public decimal? NetAmount {  get; set; }
        public int? NoOfDays { get; set; }
        public string? Remarks { get; set;}
        public DateTime Modified { get; set; }
        [Required]
        public DateTime? FromDate {  get; set; }
        [Required]
        public DateTime? ToDate {  get; set; } 

    }
    public class ViewBagModel
    {
        public int? SerialNo { get; set; }
        public int? ReceiptNo { get; set; }

    }
}
