using KareAjans.Entities.EntityClasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL
{
   public static class MankenResimDAL
    {

        private static List<Resim> Resim;
        static MankenResimDAL()
        {
            Resim = new List<Resim>();        }
        public static List<Resim> ResimGetir(int mankenID)
        {
            DBHelper dBHelper = new DBHelper();
            //Resim.Clear();
            string cmdText = "select * from MankenResim mr join Resim r on mr.ResimID = r.ResimID where MankenID=@mid";
            Dictionary<string, object> resimler = new Dictionary<string, object>();
            resimler.Add("@mid", mankenID);
            Resim resim = null;
            SqlDataReader reader = dBHelper.ExecuteReader(cmdText, resimler);
            while (reader.Read())
            {
                resim = new Resim();
                resim.ResimID = (int)reader["ResimID"];
                resim.MankenResim = (byte[])reader["MankenResim"];
                Resim.Add(resim);

            }
            reader.Close();
            return Resim;

        }
        public static void ResimEkle(int mankenID,byte[] resim)
        {
            DBHelper dBHelper = new DBHelper();
            string cmdText = "insert Resim(MankenResim) values(@resim))"; //burada resime ekleme yapılır.
            Dictionary<string, object> eklenenResim = new Dictionary<string, object>();
            eklenenResim.Add("@resim", resim);
            dBHelper.ExecuteNonQuery(cmdText, eklenenResim);

            string cmdtext1 = "select*from Resim where MankenResim=@resim";//burada eklenen resmi id si alınır.
            Dictionary<string, object> resimler = new Dictionary<string, object>();
            resimler.Add("@resim", resim);
            int result=(int)dBHelper.ExecuteScalar(cmdtext1,resimler);

            string cmdtext2 = "insert MankenResim(MankenID,ResimID) values(@mankenID,@ResimID)";
            Dictionary<string, object> mankenResim = new Dictionary<string, object>();
            mankenResim.Add("@mankenID",mankenID);
            mankenResim.Add("@ResimID", result);
            dBHelper.ExecuteNonQuery(cmdtext2,mankenResim);    
        }
    }
}
