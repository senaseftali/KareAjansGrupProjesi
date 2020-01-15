using KareAjans.Entities.EntityClasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL
{
    public static class YorumDAL
    {
        private static List<Yorum> Yorum;
        static YorumDAL()
        {
            Yorum = new List<Yorum>();
        }
        public static List<Yorum> YorumGetir(int mankenID)
        {
            DBHelper dBHelper = new DBHelper();
            //Yorum.Clear();
            string cmdText = "SELECT * FROM Yorum where MankenID=@mid";
            Dictionary<string, object> yorumlar = new Dictionary<string, object>();
            yorumlar.Add("@mid", mankenID);
            Yorum yorum = null;
            SqlDataReader reader = dBHelper.ExecuteReader(cmdText, yorumlar);
            while (reader.Read())
            {
                yorum = new Yorum();
                yorum.KullaniciID = (int)reader["KullaniciID"];
                yorum.MankenYorumu = reader["Yorum"].ToString();
                Yorum.Add(yorum);

            }
            reader.Close();
            return Yorum;

        }
       
    }
}
