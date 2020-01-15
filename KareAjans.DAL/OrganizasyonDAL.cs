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
    public static class OrganizasyonDAL
    {
        static List<Organizasyon> _organizasyon;
        static List<OrganizasyonDTO> _organizasyondto;

        static OrganizasyonDAL()
        {
            _organizasyon = new List<Organizasyon>();
            _organizasyondto = new List<OrganizasyonDTO>();
        }
        public static List<Organizasyon> OrganizasyonGetir()
        {
            DBHelper dBHelper = new DBHelper();
            _organizasyon.Clear();
            string cmdText = "select*from Organizasyon";
            Dictionary<string, object> organizasyon = new Dictionary<string, object>();
            Organizasyon organizasyon1 = null;
            SqlDataReader reader = dBHelper.ExecuteReader(cmdText,organizasyon);
            while (reader.Read())
            {
                organizasyon1 = new Organizasyon();
                organizasyon1.Ad = reader["Ad"].ToString();
                organizasyon1.OrganizasyonID = (int)reader["OrganizasyonID"];
                organizasyon1.MusteriID = (int)reader["MusteriID"];
                organizasyon1.BaslangicTArihi = (DateTime)reader["BaslangicTarihi"];
                organizasyon1.BitisTarihi =(DateTime) reader["BitisTarihi"];
                organizasyon1.OrganizasyonGelir = OrganizasyonGelirDAL.OrganizasyonGelirGetir(organizasyon1.OrganizasyonID);
                organizasyon1.OrganizasyonGider = OrganizasyonGiderDAL.OrganizasyonGelirGetir(organizasyon1.OrganizasyonID);
                _organizasyon.Add(organizasyon1);
            }
            reader.Close();
            return _organizasyon;
        }
        public static List<OrganizasyonDTO> OrganizasyonDTOGetir()
        {
            DBHelper dBHelper = new DBHelper();
            //_organizasyondto.Clear();
            string cmdText = "select*from Organizasyon";
            Dictionary<string, object> organizasyon = new Dictionary<string, object>();
            OrganizasyonDTO organizasyon1 = null;
            SqlDataReader reader = dBHelper.ExecuteReader(cmdText, organizasyon);
            while (reader.Read())
            {
                organizasyon1 = new OrganizasyonDTO();
                organizasyon1.Ad = reader["Ad"].ToString();
                organizasyon1.OrganizasyonID = (int)reader["OrganizasyonID"];
                _organizasyondto.Add(organizasyon1);
            }
            reader.Close();
            return _organizasyondto;
        }
        public static int OrganizasyonEkle(Organizasyon organizasyon)
        {
            DBHelper dBHelper = new DBHelper();
            string cmdText = "insert Organizasyon(MusteriID,Ad,BaslangicTarihi,BitisTarihi) values(@musteriID,@ad,@baslangicTarihi,@bitisTarihi)";
            Dictionary<string, object> organizasyonEkle = new Dictionary<string, object>();
            organizasyonEkle.Add("@musteriID", organizasyon.MusteriID);
            organizasyonEkle.Add("@ad", organizasyon.Ad);
            organizasyonEkle.Add("@baslangicTarihi", organizasyon.BaslangicTArihi);
            organizasyonEkle.Add("@bitisTarihi", organizasyon.BitisTarihi);
            int result = dBHelper.ExecuteNonQuery(cmdText, organizasyonEkle);
            AdresDAL.AdresEkle(organizasyon.OrganizasyonAdres, "Organizasyon");
            OrganizasyonGiderDAL.GiderEkle(organizasyon.OrganizasyonGider);
            OrganizasyonGelirDAL.GelirEkle(organizasyon.OrganizasyonGelir[0]);
            return result;
        }
        public static int OrganizasyonSil(int organizasyonID)
        {
            DBHelper dBHelper = new DBHelper();
            string cmdText = "delete*from Organizasyon where OrganizasyonID=@organizasyonid ";
            Dictionary<string, object> organizasyon = new Dictionary<string, object>();
            organizasyon.Add("@organizasyonid",organizasyonID);
            int result = dBHelper.ExecuteNonQuery(cmdText,organizasyon);
            return result;
        }
        public static int OrganizasyonGuncelle(Organizasyon organizasyon )
        {
            DBHelper dBHelper = new DBHelper();
            string cmdText = "update Organizasyon set MusteriID=@musteriID,Ad=@ad,BaslangicTarihi=@baslangicTarihi,BitisTarihi=@bitisTarihi where OrganizasyonID=@orgID";
            Dictionary<string, object> organizasyonGuncel = new Dictionary<string, object>();
            organizasyonGuncel.Add("@musteriID",organizasyon.MusteriID);
            organizasyonGuncel.Add("@ad",organizasyon.Ad);
            organizasyonGuncel.Add("@baslangicTarihi",organizasyon.BaslangicTArihi);
            organizasyonGuncel.Add("@bitisTarihi",organizasyon.BitisTarihi);
            int result = dBHelper.ExecuteNonQuery(cmdText,organizasyonGuncel);
            return result;
        }
        public static Organizasyon OrganizasyonAdArama(string organizasyonAd)
        {
            DBHelper dBHelper = new DBHelper();
            string cmdText = "select*from Organizasyon where Ad=@ad";
            Dictionary<string, object> orgArama = new Dictionary<string, object>();
            orgArama.Add("@ad",organizasyonAd);
            Organizasyon organizasyon = null;
            SqlDataReader reader = dBHelper.ExecuteReader(cmdText, orgArama);
            while (reader.Read())
            {
                organizasyon = new Organizasyon();
                organizasyon.Ad = reader["Ad"].ToString();
                organizasyon.OrganizasyonID = (int)reader["OrganizasyonID"];
                organizasyon.MusteriID = (int)reader["MusteriID"];
                organizasyon.BaslangicTArihi = (DateTime)reader["BaslangicTarihi"];
                organizasyon.BitisTarihi = (DateTime)reader["BitisTarihi"];
                organizasyon.OrganizasyonGelir = OrganizasyonGelirDAL.OrganizasyonGelirGetir(organizasyon.OrganizasyonID);
                organizasyon.OrganizasyonGider = OrganizasyonGiderDAL.OrganizasyonGelirGetir(organizasyon.OrganizasyonID);
                _organizasyon.Add(organizasyon);
            }
            reader.Close();
            return organizasyon;
        }
        public static List<OrganizasyonDTO> OrganizasyonAdGetir()
        {
            DBHelper dBHelper = new DBHelper();
            List<OrganizasyonDTO> organizasyonAd = new List<OrganizasyonDTO>();
            string cmdText = "select OrganizasyonID,Ad from Organizasyon";
            Dictionary<string, object> organizasyon = new Dictionary<string, object>();
            OrganizasyonDTO organizasyon1 = null;
            SqlDataReader reader = dBHelper.ExecuteReader(cmdText, organizasyon);
            while (reader.Read())
            {
                organizasyon1 = new OrganizasyonDTO();
                organizasyon1.Ad = reader["Ad"].ToString();
                organizasyon1.OrganizasyonID = (int)reader["OrganizasyonID"];
                organizasyonAd.Add(organizasyon1);
            }
            reader.Close();
            return organizasyonAd;
        }
        public static SqlDataAdapter AdapterGetir()
        {
            DBHelper helper = new DBHelper();
            string cmdTExt = "Select o.Ad as [Organizasyon Adı],m.Ad +' '+m.Soyad AS [Manken],o.BaslangicTarihi as [Başlangıç Tarihi], o.BitisTarihi as [Bitiş Tarihi] from Organizasyon o join OrganizasyonGider og on o.OrganizasyonID = og.OrganizasyonID join Manken m on m.MankenID=og.MankenID";
            SqlDataAdapter adapter = helper.AdapterGetir(cmdTExt, new Dictionary<string, object>());
            return adapter;
        }
        public static OrganizasyonDTO OrganizasyonDTOGelirGetir(int orgId)
        {
            DBHelper dBHelper = new DBHelper();
            _organizasyondto.Clear();
            string cmdText = "select Ad,o.OrganizasyonID,Butce from Organizasyon o join OrganizasyonGelir og on og.OrganizasyonID = o.OrganizasyonID where og.OrganizasyonID = @oid";
            Dictionary<string, object> organizasyon = new Dictionary<string, object>();
            organizasyon.Add("@oid", orgId);
            OrganizasyonDTO organizasyon1 = null;
            SqlDataReader reader = dBHelper.ExecuteReader(cmdText, organizasyon);
            while (reader.Read())
            {
                organizasyon1 = new OrganizasyonDTO();
                organizasyon1.Ad = reader["Ad"].ToString();
                organizasyon1.OrganizasyonID = (int)reader["OrganizasyonID"];
                organizasyon1.OrganizasyonGelir = (decimal)reader["Butce"];
                _organizasyondto.Add(organizasyon1);
            }
            reader.Close();
            return _organizasyondto[_organizasyondto.Count - 1];
        }
        public static SqlDataAdapter MuhasebeAdapterGetir(int organiszasyonID)
        {
            DBHelper dbHelper = new DBHelper();
            string cmdText =
                "select o.Ad as Organizasyon,m.Ad +' '+m.Soyad as Manken,m.KategoriID as Kategori,og.GünSayisi,og.Konaklama,og.GünlükÜcret,(select (gg.Butce*(gg.GelirYüzdesi)/gg.KategoriUcKisiSayisi + gg.GünlükÜcret *gg.GünSayisi ) from OrganizasyonGider gg where gg.MankenID = og.MankenID  and gg.OrganizasyonID = og.OrganizasyonID ) as Odenecek,(select (gg.GünSayisi *gg.OgunUcreti) from OrganizasyonGider gg where gg.MankenID = og.MankenID  and gg.OrganizasyonID = og.OrganizasyonID  ) as Harcama from Organizasyon o join OrganizasyonGider og on og.OrganizasyonID = o.OrganizasyonID join Manken m on m.MankenID = og.MankenID where og.OrganizasyonID = @oid";
            Dictionary<string, object> parametreler = new Dictionary<string, object>();
            parametreler.Add("@oid", organiszasyonID);
            SqlDataAdapter adapter = dbHelper.AdapterGetir(cmdText, parametreler);
            return adapter;
        }


    }
}
