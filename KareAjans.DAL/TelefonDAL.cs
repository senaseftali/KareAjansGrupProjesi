using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL
{
    public static class TelefonDAL
    {
        private static List<string> Telefon;
        static TelefonDAL()
        {
            Telefon = new List<string>();
        }
        public static List<string> TelefonGetir(int mankenID , string kisi)
        {
            DBHelper dBHelper = new DBHelper();
            //Telefon.Clear();
            string cmdText = $"SELECT TelefonNo FROM Telefon t join {kisi}Telefon mt on t.TelefonID = mt.TelefonID WHERE {kisi}ID=@mid";
            Dictionary<string, object> telefonlar = new Dictionary<string, object>();
            telefonlar.Add("@mid", mankenID);

            SqlDataReader reader = dBHelper.ExecuteReader(cmdText, telefonlar);
            while (reader.Read())
            {
                Telefon.Add(reader["TelefonNo"].ToString());
            }
            reader.Close();
            return Telefon;

        }

        public static void TelefonEkle(string[] telefon, int kisiID)
        {
            DBHelper dBHelper = new DBHelper();
            string cmdText = "insert Telefon (KisiID,TelefonNo) values(@kid,@tel)";
            Dictionary<string, object> eklenenTelefon = new Dictionary<string, object>();
           
            for (int i = 0; i < telefon.Length; i++)
            {
                eklenenTelefon.Clear();
                eklenenTelefon.Add("@kid", kisiID);
                eklenenTelefon.Add("@tel", telefon[i]);
                dBHelper.ExecuteNonQuery(cmdText, eklenenTelefon);
            }
           
        }

    }
}
