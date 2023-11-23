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
    }

}
