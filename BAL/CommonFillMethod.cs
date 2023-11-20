using GNForm3C_.Areas.MST_Hospital.Models;
using GNForm3C_.DAL;
using System.Data;

namespace GNForm3C_.BAL
{
    public class CommonFillMethod
    {
        public CommonFillMethod()
        {
            
        }
        public static List<HospitalDropDowmModel> SelectDropDownListForHospital()
        {
            MST_DAL dalMST = new MST_DAL();
            DataTable dt1 = dalMST.PR_Hospital_SelectComboBox();
            List<HospitalDropDowmModel> Hospital = new List<HospitalDropDowmModel>();
            foreach (DataRow dr1 in dt1.Rows)
            {
                HospitalDropDowmModel dropDownModel=new HospitalDropDowmModel();
                dropDownModel.HospitalID = Convert.ToInt32(dr1["HospitalID"]);
                dropDownModel.Hospital = dr1["Hospital"].ToString();
                Hospital.Add(dropDownModel);
            }
            return Hospital;
        }
    }
}
