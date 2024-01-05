﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GNForm3C_.Areas.MST_ExpenseType.Models
{
	public class MST_ExpenseTypeModel
	{
		public int? ExpenseTypeID { get; set; }
		[Required(ErrorMessage = "Please Enter Expense Type")]
		[DisplayName("Expense Type")]
		public string? ExpenseType { get; set; }
		public string? Remarks { get; set; }
		[Required(ErrorMessage = "Please Select Hospital")]
		[DisplayName("Hospital Name")]
		public int? HospitalID { get; set; }
		public string Hospital { get; set; }
		public DateTime Created { get; set; }
		public DateTime Modified { get; set; }
	}
	public class ExpenseTypeDropdownModel
    {
        public int ExpenseTypeID { get; set; }
        public string? ExpenseType { get; set; }
    }
}
