namespace GNForm3C_.BAL
{

    public static class CommonVariables
    {
		#region CommonVariables
		static CommonVariables()
		{
			_httpContextAccessor = new HttpContextAccessor();
		}
		#endregion
        
		public static Boolean IsURLEncryption=true;
        
		#region Common Images
        public static string SmallLogo = "/Theme/assets/media/logos/GNForm3CPlus_OnlyLogo.png";
        public static string SlidebarImage = "/Theme/assets/media/logos/GNForm3CPlus_Logo.png";
		public static string LoginCard = "/Theme/assets/media/logos/GNForm3CPlus_Logo.png";
		public static string LoginImage = "/Theme/assets/media/logos/GNForm3CFull.png";
		public static string LoginSmallImage = "/Theme/assets/media/logos/GNWebSoftFull.png";
		public static string ExpenseLogo = "/Theme/assets/media/svg/Expense-removebg-preview (1).png";
        public static string IncomeLogo = "/Theme/assets/media/svg/income-removebg-preview (1).png";
        public static string HospitalListLogo = "/Theme/assets/media/svg/downloaded-icons/hospital-buildings-black.svg";
        public static string HospitalDashboardLogo = "/Theme/assets/media/svg/downloaded-icons/hospital-buildings-white.svg";
        public static string FinYearListLogo = "/Theme/assets/media/svg/downloaded-icons/date-icon.svg";
        public static string UserListLogo = "/Theme/assets/media/svg/downloaded-icons/userListLogo.svg";
        public static string IncomeTypeListLogo = "/Theme/assets/media/svg/downloaded-icons/income-type-black.svg";
        public static string ExpenseTypeListLogo = "/Theme/assets/media/svg/downloaded-icons/expense-type-black.svg";
        public static string ReceiptTypeListLogo = "/Theme/assets/media/svg/downloaded-icons/receipt-type-black.svg";
        public static string TreatmentListLogo = "/Theme/assets/media/svg/downloaded-icons/images/treatment-black.png";
        public static string SubTreatmentListLogo = "/Theme/assets/media/svg/downloaded-icons/images/subtreatment-black.png";
        public static string ReceiptListLogo = "/Theme/assets/media/svg/downloaded-icons/receipt.svg";
        public static string TreatmentDashboardLogo = "/Theme/assets/media/svg/downloaded-icons/treatment-dashboard-logo.svg";
        public static string IncomeDashboardLogo = "/Theme/assets/media/svg/downloaded-icons/Income-dashboard-logo-white.png";
        public static string ExpenseDashboardLogo = "/Theme/assets/media/svg/downloaded-icons/Expense-dashboard-logo-white.png";
        #endregion

        #region Common Button
        public static string AddBtnColor = "btn btn-success btn-sm rounded-pill ";
        public static string SearchBtnColor = "btn btn-primary btn-sm";
        public static string ClearBtnColor = "btn btn-light btn-sm";
        public static string SaveBtnColor = "btn btn-primary btn-sm";
        public static string BackToListBtnColor = "btn btn-light btn-sm";

        #endregion

        #region Common Labels
        public static string ExpenseTypelabel = "Expense Type";
        public static string IncomeTypelabel = "Income Type";
        public static string ExpenseDatelabel = "Expense Date";
		public static string IncomeDatelabel = "Income Date";
		public static string ReceiptDatelabel = "Receipt Date";
		public static string Amountlabel = "Amount";
        public static string AdvanceAmountlabel = "Advance";
        public static string NetAmountlabel = "Net Amount";
        public static string Created = "Created";
        public static string Modified = "Modified";
        public static string notelabel = "Note";
        public static string FinancialYearNamelabel = "Financial Year";
        public static string HospitalNamelabel = "Hospital";
        public static string PrintNameHospitallabel = "Print Name";
        public static string PrintLine1label = "Print Line-1";
        public static string PrintLine2label = "Print Line-2";
        public static string PrintLine3label = "Print Line-3";
        public static string HeaderNamelabel = "Header Name";
        public static string FooterNamelabel = "Footer Name";
        public static string FromDatelabel = "From Date";
        public static string ToDatelabel = "To Date";
        public static string UserNamelabel = "User Name";
        public static string Passwordlabel = "Password";
        public static string ConfirmPasswordlabel = "Confirm Password";
        public static string Remarklabel = "Remarks";
        public static string ReceiptTypelabel = "Receipt Type";
        public static string Defaultlabel = "Default";
        public static string Activelabel = "Active";
        public static string Treatmentlabel = "Treatment";
        public static string SubTreatmentlabel = "Sub Treatment";
        public static string SequenceNolabel = "Sequence No";
        public static string ReceiptNolabel = "Receipt No";
        public static string SerialNolabel = "Serial No";
        public static string Ratelabel = "Rate";
        public static string AutoLoadinReceiptlabel = "Auto Load In Receipt";
        public static string Unitlabel = "Unit";
        public static string ChargePerDaylabel = "Charge Per Day";
        public static string Actionlabel = "Action";
		public static string AdmissionDatelabel = "Admission Date";
		public static string DischargeDatelabel = "Discharge Date";
		public static string TotalDayslabel = "Total Days";
        public static string PatientNamelabel = "Patient Name";
        public static string PrintNameReceiptlabel = "Print Name";
        #endregion


        private static IHttpContextAccessor _httpContextAccessor;

		#region UserName
		public static string? UserName()
		{
			string? UserName = null;

			if(_httpContextAccessor.HttpContext.Session.GetString("UserName") != null)
			{
				UserName = _httpContextAccessor.HttpContext.Session.GetString("UserName").ToString();
			}
			return UserName;
		}
		#endregion

		#region UserID
		public static int? UserID()
		{
			int? UserID = null;
			if(_httpContextAccessor.HttpContext.Session.GetString("UserID") != null)
			{
				UserID = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("UserID"));
			}
			return UserID;
		}
		#endregion

		#region Password
		public static string? Password()
		{
			string? Password = null;

			if(_httpContextAccessor.HttpContext.Session.GetString("Password") != null)
			{
				Password = _httpContextAccessor.HttpContext.Session.GetString("Password").ToString();
			}
			return Password;
		}
        #endregion

        #region FinYearID
        public static int? FinYearID()
        {
            int? FinYearID = null;
            if (_httpContextAccessor.HttpContext.Session.GetString("FinYearID") != null)
            {
                FinYearID = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("FinYearID"));
            }
            return FinYearID;
        }
        #endregion

        #region HospitalID
        public static int? HospitalID()
        {
            int? HospitalID = null;
            if(_httpContextAccessor.HttpContext.Session.GetString("HospitalID") != null)
            {
                HospitalID = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetString("HospitalID"));
            }
            return HospitalID;
        }
        #endregion

        #region Hospital
        public static string? Hospital()
        {
            string? Hospital = null;

            if(_httpContextAccessor.HttpContext.Session.GetString("Hospital") != null)
            {
                Hospital = _httpContextAccessor.HttpContext.Session.GetString("Hospital").ToString();
            }
            return Hospital;
        }
        #endregion
    }

}
