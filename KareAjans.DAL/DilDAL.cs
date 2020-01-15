using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL
{
    public static class DilDAL
    {
        private static List<string> Dil;
        static DilDAL()
        {
            Dil = new List<string>();
        }
        public static List<string> DilGetir(int mankenID)
        {
            DBHelper dBHelper = new DBHelper();
            //Dil.Clear();
            string cmdText = "select * from MankenDil md join YabanciDil yd on md.DilID = yd.DilID where MankenID =@mid";
            Dictionary<string, object> diller = new Dictionary<string, object>();
            diller.Add("@mid", mankenID);

            SqlDataReader reader = dBHelper.ExecuteReader(cmdText, diller);
            while (reader.Read())
            {
                Dil.Add(reader["Dil"].ToString());

            }
            reader.Close();
            return Dil;

        }

        public static void DilEkle(string[] dil, int kisiID)
        {
            DBHelper dBHelper = new DBHelper();
            for (int i = 0; i < dil.Length; i++)
            {
                string cmdText = "select * from YabanciDil";
                Dictionary<string, object> eklenenDil = new Dictionary<string, object>();
                int result = (int)dBHelper.ExecuteScalar(cmdText, eklenenDil);
                if (result > 0)
                {
                    string cmdTextt = "insert MankenDil (MankenID,DilID) values(@mid,@did)";
                    Dictionary<string, object> eklenenDill = new Dictionary<string, object>();
                    eklenenDill.Add("@mid", kisiID);
                    eklenenDill.Add("@did", result);
                    dBHelper.ExecuteNonQuery(cmdTextt, eklenenDill);
                }
                else
                {
                    string cmdtexttt = "insert YabanciDil (Dil) values(@dil)";
                    Dictionary<string, object> eklnendilll = new Dictionary<string, object>();
                    eklnendilll.Add("@dil", dil[i]);
                    dBHelper.ExecuteNonQuery(cmdtexttt, eklnendilll);

                    string cmdText1 = "select * from YabanciDil";
                    Dictionary<string, object> eklenenDil1 = new Dictionary<string, object>();
                    int result1 = (int)dBHelper.ExecuteScalar(cmdText1, eklenenDil1);

                    string cmdTextt = "insert MankenDil (MankenID,DilID) values(@mid,@did)";
                    Dictionary<string, object> eklenenDill = new Dictionary<string, object>();
                    eklenenDill.Add("@mid", kisiID);
                    eklenenDill.Add("@did", result1);
                    dBHelper.ExecuteNonQuery(cmdTextt, eklenenDill);

                }
            }



        }
    }
}
