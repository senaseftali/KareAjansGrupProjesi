using KareAjans.Entities.EntityClasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL
{
    public static class OrganizasyonGiderDAL
    {
        static List<OrganizasyonGider> _organizasyonGider;
      
        public static List<OrganizasyonGider> OrganizasyonGelirGetir(int orgID)
        {
            DBHelper dBHelper = new DBHelper();
            _organizasyonGider.Clear();
            string cmdText = "select*from organizasyonGider where OrganizasyonID=@ogrID";
            Dictionary<string, object> organizasyonlar = new Dictionary<string, object>();
            organizasyonlar.Add("ogrID",orgID);
            OrganizasyonGider gelir = null;
            SqlDataReader reader = dBHelper.ExecuteReader(cmdText,organizasyonlar);
            while (reader.Read())
            {
                gelir = new OrganizasyonGider();
                gelir.OrganizasyonID =(int) reader["OrganizasyonID"];
                gelir.MankenID = (int)reader["MankenID"];
                gelir.OgunUcreti = (decimal)reader["OgunUcreti"];
                gelir.KonaklamaUcreti = (decimal)reader["KonaklamaUcreti"];
                gelir.KategoriUcKisiSayisi = (int)reader["KategoriUcKisiSayisi"];
                gelir.GunSayisi = (short)reader["GunSayisi"];
                gelir.GunlukUcret = (decimal)reader["GunlukUcret"];
                gelir.GelirYuzdesi = (decimal)reader["GelirYüzdesi"];
                _organizasyonGider.Add(gelir);

            }
            reader.Close();
            return _organizasyonGider;
        }
        public static List<OrganizasyonGider> OrganizasyonGelirGetir()
        {
            DBHelper dBHelper = new DBHelper();
            string cmdText = "select*from organizasyonGider where OrganizasyonID=@ogrID";
            Dictionary<string, object> organizasyonlar = new Dictionary<string, object>();          
            OrganizasyonGider gelir = null;
            SqlDataReader reader = dBHelper.ExecuteReader(cmdText, organizasyonlar);
            while (reader.Read())
            {
                gelir = new OrganizasyonGider();
                gelir.OrganizasyonID = (int)reader["OrganizasyonID"];
                gelir.MankenID = (int)reader["MankenID"];
                gelir.OgunUcreti = (decimal)reader["OgunUcreti"];
                gelir.KonaklamaUcreti = (decimal)reader["Konaklama"];
                gelir.KategoriUcKisiSayisi = (int)reader["KategoriUcKisiSayisi"];
                gelir.GunSayisi = (short)reader["GünSayisi"];
                gelir.GunlukUcret = (decimal)reader["GünlükUcret"];
                gelir.GelirYuzdesi = (decimal)reader["GelirYüzdesi"];
                _organizasyonGider.Add(gelir);

            }
            reader.Close();
            return _organizasyonGider;
        }
        public static int GiderEkle(List<OrganizasyonGider> organizasyonGiderS)
        {
            DBHelper dbHelper = new DBHelper();
            string cmdText =
                "insert into OrganizasyonGider(OrganizasyonID,MankenID,OgunUcreti,Konaklama,KategoriUcKisiSayisi,GünSayisi," +
                "GünlükÜcret,GelirYüzdesi,Butce) values(@oid,@mid,@ogn,@knklm,@ktg,@gün,@günücret,@geliryüzde,@bütçe)";
            Dictionary<string, object> paramatreler = new Dictionary<string, object>();
            int result = 0;
            foreach (OrganizasyonGider organizasyonGider in organizasyonGiderS)
            {
                paramatreler.Clear();
                paramatreler.Add("@oid", organizasyonGider.OrganizasyonID);
                paramatreler.Add("@mid", organizasyonGider.MankenID);
                paramatreler.Add("@ogn", organizasyonGider.OgunUcreti);
                paramatreler.Add("@knklm", organizasyonGider.KonaklamaUcreti);
                paramatreler.Add("@gün", organizasyonGider.GunSayisi);
                paramatreler.Add("@günücret", organizasyonGider.GunlukUcret);
                paramatreler.Add("@geliryüzde", organizasyonGider.GelirYuzdesi);
                paramatreler.Add("@bütçe", organizasyonGider.Butce);
                paramatreler.Add("@ktg", organizasyonGider.KategoriUcKisiSayisi);
                result = dbHelper.ExecuteNonQuery(cmdText, paramatreler);

            }

            return result;
        }

    }
}
