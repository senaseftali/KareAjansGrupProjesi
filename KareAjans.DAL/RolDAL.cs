using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL
{
    public static class RolDAL
    {
        public static string RolGetir(int rolID)
        {
            DBHelper dBHelper = new DBHelper();
            string cmdText = "select Ad form KullaniciRol where RolId=@rolid";
            Dictionary<string, object> roller = new Dictionary<string, object>();
            roller.Add("@rolid",rolID);
            string result = dBHelper.ExecuteScalar(cmdText,roller).ToString();
            return result;
        }
    }
}
