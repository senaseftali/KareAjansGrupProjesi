using KareAjans.DTO;
using KareAjans.Entities.EntityClasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL
{
    public static class AdresDAL
    {
        
        private static List<Adres> Adres;
        static AdresDAL()
        {
            Adres = new List<Adres>();
        }
        public static List<Adres> AdresGetir(int mankenID,string kisi)
        {
            Adres.Clear();
            string cmdText = $"SELECT a.AdresID,a.Adres, a.Sehir as Şehir, a.Ulke as Ülke FROM {kisi}Adres ma join Adres a on ma.AdresID = a.AdresID  where {kisi}ID=@mid";
            Dictionary<string, object> adresler = new Dictionary<string, object>();
            adresler.Add("@mid", mankenID);
            Adres adres = null;
            DBHelper dBHelper = new DBHelper();
            SqlDataReader reader = dBHelper.ExecuteReader(cmdText, adresler);
            while (reader.Read())
            {
                adres = new Adres();
                adres.AcikAdres = reader["Adres"].ToString();
                adres.AdresID = (int)reader["AdresID"];
                adres.Sehir = reader["Şehir"].ToString();
                adres.Ulke = reader["Ülke"].ToString();
                Adres.Add(adres);

            }
            reader.Close();
            return Adres;
        }
        public static int AdresEkle(List<Adres> adres, string kisi)
        {
            DBHelper dBHelper = new DBHelper();
            string cmdtext = $"select top 1 MankenID from Manken order by MankenID desc";
            int id = Convert.ToInt32(dBHelper.ExecuteScalar(cmdtext, new Dictionary<string, object>()));
            cmdtext = "insert into Adres (Adres,Sehir,Ulke) values(@adres,@sehir,@ulke)";
            Dictionary<string, object> adresler = new Dictionary<string, object>();
            foreach (Adres item in adres)
            {
                adresler.Clear();
                adresler.Add("@adres", item.AcikAdres);
                adresler.Add("@sehir", item.Sehir);
                adresler.Add("@ulke", item.Ulke);
                dBHelper.ExecuteNonQuery(cmdtext, adresler);
            }
            cmdtext = "select top 1 AdresID from Adres order by AdresID desc";
            int id1 = Convert.ToInt32(dBHelper.ExecuteScalar(cmdtext, new Dictionary<string, object>()));
            AdresDTO adresDTO = new AdresDTO();
            adresDTO.AdresID1 = adres.Count > 0 ? id1 : 0;
            adresDTO.AdresID2 = adres.Count > 1 ? id1 - 1 : 0;
            adresDTO.KisiID = id;
            AraTabloyaAdresEkle(adresDTO, kisi);
            return id1;
        }
        public static void AraTabloyaAdresEkle(AdresDTO adres, string kisi)
        {
            DBHelper dBHelper = new DBHelper();
            string cmdText = $"insert into {kisi}Adres(AdresID,{kisi}ID) values(@adresid,@id)";
            Dictionary<string, object> mankenAraTablo = new Dictionary<string, object>();

            if (adres.AdresID1 != 0)
            {
                mankenAraTablo.Add("@adresid", adres.AdresID1);
                mankenAraTablo.Add("@id", adres.KisiID);
                dBHelper.ExecuteNonQuery(cmdText, mankenAraTablo);
            }
            if (adres.AdresID2 != 0)
            {
                mankenAraTablo.Add("@adresid", adres.AdresID2);
                mankenAraTablo.Add("@id", adres.KisiID);
                dBHelper.ExecuteNonQuery(cmdText, mankenAraTablo);
            }
        }
    }
}
