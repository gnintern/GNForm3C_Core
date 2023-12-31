﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GNForm3C_.Areas.ACC_Receipt.Models
{
    public class ACC_ReceiptModel
    {
        public int? TransactionID { get; set; }
        [Required(ErrorMessage ="Please Enter Patient Name")]
        public string? Patient { get; set; }
        [Required(ErrorMessage = "Please Select Treatment")]
        public int TreatmentID { get; set;}
        public string? Treatment {  get; set; }
        [Required(ErrorMessage ="Please Select Hospital")]
        public int HospitalID { get; set; }
        public string? Hospital { get; set; }
        public int? FinYearID {  get; set; }
        public string? FinYearName { get; set; }
        [Required(ErrorMessage ="Please Select Receipt Type")]
        public int? ReceiptTypeID { get; set; }
        public string? ReceiptTypeName { get; set; }
        [Required(ErrorMessage ="Please Enter Amount")]
        public decimal? Amount { get; set; }
        [Required(ErrorMessage ="Please Enter Serial No")]
        public int SerialNo {  get; set; }
        public string? ReferenceDoctor {  get; set; }
        public int? Count {  get; set; }
        [Required(ErrorMessage = "Please Enter Receipt No")]
        public int ReceiptNo { get; set; }
        public DateTime Date { get; set; } 
        public DateTime? DateOfAdmission { get; set; } 
        public DateTime? DateOfDischarge {  get; set; }

        public decimal? Deposite { get; set; }
        public decimal? NetAmount {  get; set; }
        public int? NoOfDays { get; set; }
        public string? Remarks { get; set;}
        public DateTime Modified { get; set; }
        [Required(ErrorMessage = "Please Enter From Date")]
        [DisplayName("From Date")]
        public DateTime FromDate { get; set; } 
        [Required(ErrorMessage = "Please Enter To Date")]
        [DisplayName("To Date")]
        public DateTime ToDate {  get; set; } 

    }
    public class ViewBagModel
    {
        public int? SerialNo { get; set; }
        public int? ReceiptNo { get; set; }

    }
    public class ViewBagReceiptModel
    {
        [Required(ErrorMessage = "Please Enter From Date")]
        [DisplayName("From Date")]
        public DateTime? FromDate { get; set; }
        [Required(ErrorMessage = "Please Enter To Date")]
        [DisplayName("To Date")]
        public DateTime? ToDate { get; set; }

    }
}
