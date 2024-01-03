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
