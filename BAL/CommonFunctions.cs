using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using System.Text;

namespace GNForm3C_.BAL
{
    public class CommonFunctions : Controller
    {
        #region GLOBAL DECLARATION
        //Content of table Data to Download the excel
        public static List<Dictionary<int, string>> tableData = new List<Dictionary<int, string>>();

        #endregion

        #region For Encryption
        public static string EncryptBase64(string password)
        {
            if (CommonVariables.IsURLEncryption)
            {
                string strmsg = string.Empty;
                byte[] encode = new byte[password.Length];
                encode = Encoding.UTF8.GetBytes(password);
                strmsg = Convert.ToBase64String(encode);
                return strmsg;
            }
            else
                return password;

        }
        #endregion

        #region For Converting String into ByteCode
        public static bool IsBase64Encoded(String str)
        {
            try
            {
                // If no exception is caught, then it is possibly a base64 encoded string
                byte[] data = Convert.FromBase64String(str);
                // The part that checks if the string was properly padded to the
                // correct length was borrowed from d@anish's solution
                return (str.Replace(" ", "").Length % 4 == 0);
            }
            catch
            {
                // If exception is caught, then it is not a base64 encoded string
                return false;
            }
        }
        #endregion

        #region For Decryption
        public static SqlInt32 DecryptBase64Int32(SqlString encryptpwd)
        {
            int n;

            if (CommonVariables.IsURLEncryption)
            {

                if (!encryptpwd.IsNull && encryptpwd.Value != String.Empty)
                {
                    if (IsBase64Encoded(encryptpwd.Value))
                    {
                        string decryptpwd = string.Empty;
                        UTF8Encoding encodepwd = new UTF8Encoding();
                        Decoder Decode = encodepwd.GetDecoder();
                        byte[] todecode_byte = Convert.FromBase64String(encryptpwd.Value);
                        int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                        char[] decoded_char = new char[charCount];
                        Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                        decryptpwd = new String(decoded_char);

                        if (int.TryParse(decryptpwd, out n))
                            return Convert.ToInt32(decryptpwd);
                        else return SqlInt32.Null;
                    }
                    else return SqlInt32.Null;
                }
                else
                    return SqlInt32.Null;
            }
            else
            {
                if (encryptpwd.IsNull)
                    return SqlInt32.Null;
                else if (int.TryParse(encryptpwd.Value, out n))
                    return Convert.ToInt32(encryptpwd.Value);
                else return SqlInt32.Null;
            }

        }
        #endregion'

        #region Excel Export Operation

        #region Get The Table Data
        [HttpPost]
        public bool ExportTable([FromBody] List<Dictionary<int, string>> listOfData)
        {
            if (listOfData[1].Count > 0)
            {
                tableData = listOfData;
                return true;
            }
            else
            {
                TempData["error"] = "No Data Found";
                return false;
            }
        }
        #endregion

        #region Download Excel
        public IActionResult DownloadExcel(string FileName)
        {
            var workbook = new XLWorkbook();
            // Add a worksheet to the workbook
            var worksheet = workbook.Worksheets.Add(FileName);

            //Write the Values in Cell
            int i = 1;
            foreach (var row in tableData)
            {
                int j = 1;
                foreach (var data in row)
                {
                    //set the values in the cell
                    worksheet.Cell(i, j).Value = data.Value.Trim();
                    j++;
                }
                i++;
            }

            // Make the header row bold
            worksheet.Row(1).Style.Font.Bold = true;

            // Adjust column widths based on content
            worksheet.Columns().AdjustToContents();

            //Set the content type and file name for the response
            var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            var fileName = $"{FileName}_{DateTime.Now.ToString("dd/MM/yyyy")}.xlsx";

            // Return the Excel file as the response
            using (var stream = new MemoryStream())
            {
                workbook.SaveAs(stream);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream.ToArray(), contentType, fileName);
            }
        }
        #endregion

        #endregion
    }
}
