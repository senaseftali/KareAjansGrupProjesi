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
    public static class MankenDAL
    {
        static List<Manken> _mankenler;
        static MankenDAL()
        {
            _mankenler = new List<Manken>();
        }
        public static List<Manken> MankenGetir()
        {
            DBHelper dBHelper = new DBHelper();
            _mankenler.Clear();
            string cmdText = "select*from Manken ";
            SqlDataReader reader = dBHelper.ExecuteReader(cmdText, new Dictionary<string, object>());
            Manken manken = null;
            while (reader.Read())
            {
                manken = new Manken();
                manken.Ad = reader["Ad"].ToString();
                manken.Soyad = reader["Soyad"].ToString();
                manken.SacRengi = reader["SacRengi"].ToString();
                manken.GözRengi = reader["GozRengi"].ToString();
                manken.AyakkabiNo = (decimal)reader["AyakkabiNo"];
                manken.Beden = (short)reader["Beden"];
                manken.Ehliyet = (bool)reader["Ehliyet"];
                manken.Adres = AdresDAL.AdresGetir(manken.MankenID, "Manken");
                manken.Telefon = TelefonDAL.TelefonGetir(manken.MankenID, "Manken");
                manken.Ozellik = reader["Ozellik"].ToString();
                manken.Yorumlar = YorumDAL.YorumGetir(manken.MankenID);
                manken.SehirDisiDurumu = (bool)reader["SehirDisiDurumu"];
                manken.Durum = (bool)reader["Durum"];
                manken.OlusturulmaTarihi = (DateTime)reader["OlusturulmaTarihi"];
                manken.Kilo = (decimal)reader["Kilo"];
                manken.MankenID = (int)reader["MankenID"];
                manken.KategoriID = (int)reader["KategoriID"];
                manken.Dil = DilDAL.DilGetir(manken.MankenID);
                manken.MankenResim = MankenResimDAL.ResimGetir(manken.MankenID);
                manken.AKtifMi = (bool)reader["AktifMi"];
                _mankenler.Add(manken);

            }
            reader.Close();
            return _mankenler;
        }

        public static SqlDataAdapter MankenAdapterGetir()
        {
            DBHelper helper = new DBHelper();
            string cmdTExt = "select m.MankenID, Ad+' '+Soyad as [Ad Soyad],a.Adres,a.Sehir as Şehir,a.Ulke as Ülke,KategoriID as [Kategori No], AyakkabiNo as [Ayakkabı No],Beden,Kilo,SacRengi as [Saç Rengi],SehirDisiDurumu as [Şehir Dışı],Ehliyet,Ozellik as Özellik,AktifMi as [Aktif],OlusturulmaTarihi as [Kayıt Tarihi],Durum as [İş Durumu] from Manken m join MankenAdres ma on m.MankenID = ma.MankenID join Adres a on ma.AdresID = a.AdresID ";
            SqlDataAdapter adapter = helper.AdapterGetir(cmdTExt, new Dictionary<string, object>());
            return adapter;
        }
        public static int MankenEkle(Manken manken, string mail, string sifre)
        {
            Kullanici kullanici = new Kullanici();
            kullanici.Kisi = manken;
            kullanici.Mail = mail;
            kullanici.Sifre = sifre;
            kullanici.RolID = 1; //manken olduğu için
            KullaniciDAL.KullaniciEkle(kullanici);
            string query = "select top 1 KullaniciID from Kullanicilar order by KullaniciID desc";
            DBHelper dBHelperr = new DBHelper();
            int resultt = Convert.ToInt32(dBHelperr.ExecuteScalar(query, new Dictionary<string, object>()));
            DBHelper dBHelper11 = new DBHelper();
            string cmdText = "insert into Manken(MankenID,Ad,Soyad,KategoriID,AyakkabiNo,Beden,Kilo,SacRengi,GozRengi,SehirDisiDurumu,Ehliyet,Ozellik,AktifMi,Durum) values(@mid,@ad,@soyad,@kid,@aykNo,@beden,@kilo,@scrng,@gzrng,@shrdrum,@ehliyet,@ozellik,@aktifmi,@drm)";
            Dictionary<string, object> eklenenManken = new Dictionary<string, object>();
            eklenenManken.Add("@ad", manken.Ad);
            eklenenManken.Add("@Soyad", manken.Soyad);
            eklenenManken.Add("@kid", manken.KategoriID);
            eklenenManken.Add("@mid", resultt);
            eklenenManken.Add("@aykNo", manken.AyakkabiNo);
            eklenenManken.Add("@beden", manken.Beden);
            eklenenManken.Add("@scrng", manken.SacRengi);
            eklenenManken.Add("@gzrng", manken.GözRengi);
            eklenenManken.Add("@shrdrum", manken.SehirDisiDurumu);
            eklenenManken.Add("@ehliyet", manken.Ehliyet);
            eklenenManken.Add("@ozellik", manken.Ozellik);
            eklenenManken.Add("@aktifmi", manken.AKtifMi);
            eklenenManken.Add("@drm", manken.Durum);
            eklenenManken.Add("@kilo", manken.Kilo);
            AdresDAL.AdresEkle(manken.Adres, "Manken");
            int result = dBHelper11.ExecuteNonQuery(cmdText, eklenenManken);
            return result;
        }
        public static int MankenSil(int mankenid)
        {
            DBHelper dBHelper = new DBHelper();
            string cmdText = "delete from Manken where MankenID=@mnkid";
            Dictionary<string, object> mankenSil = new Dictionary<string, object>();
            mankenSil.Add("@mnkid", mankenid);
            int result = dBHelper.ExecuteNonQuery(cmdText, mankenSil);
            return result;
        }
        public static int MankenGuncelle(Manken manken)
        {
            DBHelper dBHelper = new DBHelper();
            string cmdText = "update Manken set Ad=@ad,Soyad=@soyad,KategoriID=@kid,AyakkabiNo=@aykNo,Beden=@beden,Kilo=@kilo,SacRengi=@scrng,GozRengi=@gzrng,SehirDisiDurumu=@shrdrum,Ehliyet=@ehliyet,Ozellik=@ozellik,AktifMi=@aktif,Durum=@drm where MankenID=@mankenID";
            Dictionary<string, object> parametre = new Dictionary<string, object>();
            parametre.Add("@ad", manken.Ad);
            parametre.Add("@Soyad", manken.Soyad);
            parametre.Add("@kid", manken.KategoriID);
            parametre.Add("@aykNo", manken.AyakkabiNo);
            parametre.Add("@beden", manken.Beden);
            parametre.Add("@scrng", manken.SacRengi);
            parametre.Add("@gzrng", manken.GözRengi);
            parametre.Add("@shrdrum", manken.SehirDisiDurumu);
            parametre.Add("@ehliyet", manken.Ehliyet);
            parametre.Add("@ozellik", manken.Ozellik);
            parametre.Add("@aktif", manken.AKtifMi);
            parametre.Add("@drm", manken.Durum);
            parametre.Add("@mankenID", manken.MankenID);
            parametre.Add("@kilo", manken.Kilo);
            int result = dBHelper.ExecuteNonQuery(cmdText, parametre);
            return result;
        }
        public static Manken MankenAdArama(string mankenAd)
        {
            DBHelper dBHelper = new DBHelper();
            string cmdText = "select*from Manken where Ad=@ad";
            Dictionary<string, object> mankenArama = new Dictionary<string, object>();
            mankenArama.Add("@ad", mankenAd);
            SqlDataReader reader = dBHelper.ExecuteReader(cmdText, mankenArama);
            Manken manken = null;
            while (reader.Read())
            {
                manken = new Manken();
                manken.Ad = reader["Ad"].ToString();
                manken.Soyad = reader["Soyad"].ToString();
                manken.SacRengi = reader["SacRengi"].ToString();
                manken.GözRengi = reader["GozRengi"].ToString();
                manken.AyakkabiNo = (decimal)reader["AyakkabiNo"];
                manken.Beden = (short)reader["Beden"];
                manken.Ehliyet = (bool)reader["Ehliyet"];
                manken.Adres = AdresDAL.AdresGetir(manken.MankenID, "Manken");
                manken.Telefon = TelefonDAL.TelefonGetir(manken.MankenID, "Manken");
                manken.Ozellik = reader["Ozellik"].ToString();
                manken.Yorumlar = YorumDAL.YorumGetir(manken.MankenID);
                manken.SehirDisiDurumu = (bool)reader["SehirDisiDurumu"];
                manken.Durum = (bool)reader["Durum"];
                manken.OlusturulmaTarihi = (DateTime)reader["OlusturulmaTarihi"];
                manken.Kilo = (decimal)reader["Kilo"];
                manken.MankenID = (int)reader["MankenID"];
                manken.KategoriID = (int)reader["KategoriID"];
                manken.Dil = DilDAL.DilGetir(manken.MankenID);
                manken.MankenResim = MankenResimDAL.ResimGetir(manken.MankenID);
                manken.AKtifMi = (bool)reader["AktifMi"];
                _mankenler.Add(manken);

            }
            reader.Close();
            return manken;
        }
        public static List<MankenAdDTO> MankenAdGetir()
        {
            List<MankenAdDTO> mankenAdlar = new List<MankenAdDTO>();
            DBHelper dBHelper = new DBHelper();
            string cmdText = "select Ad,Soyad,MankenID from Manken ";
            SqlDataReader reader = dBHelper.ExecuteReader(cmdText, new Dictionary<string, object>());
            MankenAdDTO mankenAd = null;
            while (reader.Read())
            {
                mankenAd = new MankenAdDTO();
                mankenAd.MankenID = (int)reader["MankenID"];
                mankenAd.Fullname = reader["Ad"] + " " + reader["Soyad"];
                mankenAdlar.Add(mankenAd);
            }
            reader.Close();
            return mankenAdlar;

        }
        public static Manken MankenAdArama(int mankenID)
        {
            DBHelper dBHelper = new DBHelper();
            string cmdText = "select*from Manken where MankenID=@ad";
            Dictionary<string, object> mankenArama = new Dictionary<string, object>();
            mankenArama.Add("@ad", mankenID);
            SqlDataReader reader = dBHelper.ExecuteReader(cmdText, mankenArama);
            Manken manken = null;
            while (reader.Read())
            {
                manken = new Manken();
                manken.Ad = reader["Ad"].ToString();
                manken.Soyad = reader["Soyad"].ToString();
                manken.SacRengi = reader["SacRengi"].ToString();
                manken.GözRengi = reader["GozRengi"].ToString();
                manken.AyakkabiNo = (decimal)reader["AyakkabiNo"];
                manken.Beden = (short)reader["Beden"];
                manken.Ehliyet = (bool)reader["Ehliyet"];
                manken.Adres = AdresDAL.AdresGetir(mankenID, "Manken");
                manken.Telefon = TelefonDAL.TelefonGetir(mankenID, "Manken");
                manken.Ozellik = reader["Ozellik"].ToString();
                manken.Yorumlar = YorumDAL.YorumGetir(mankenID);
                manken.SehirDisiDurumu = (bool)reader["SehirDisiDurumu"];
                manken.Durum = (bool)reader["Durum"];
                manken.Kilo = (decimal)reader["Kilo"];
                manken.MankenID = (int)reader["MankenID"];
                manken.KategoriID = (int)reader["KategoriID"];
                manken.Dil = DilDAL.DilGetir(mankenID);
                manken.MankenResim = MankenResimDAL.ResimGetir(mankenID);
                manken.AKtifMi = (bool)reader["AktifMi"];
                _mankenler.Add(manken);

            }
            reader.Close();
            return manken;
        }

    }
}
