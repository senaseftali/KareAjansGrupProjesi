using KareAjans.Entities.EntityClasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL
{
   public static class KullaniciDAL
    {
        static List<Kullanici> _kullaniciler;
        static  KullaniciDAL()
        {
            _kullaniciler = new List<Kullanici>();
        }
        public static List<Kullanici> KullaniciGetir()
        {
            DBHelper dBHelper = new DBHelper();
            _kullaniciler.Clear();
            string cmdText = "select*from Kullanicilar";
            Dictionary<string, object> kullanici = new Dictionary<string, object>();
            Kullanici kullanici1 = null;
            SqlDataReader reader = dBHelper.ExecuteReader(cmdText,kullanici);
            while (reader.Read())
            {
                kullanici1 = new Kullanici();
                kullanici1.KullaniciID = (int)reader["KullaniciID"];
                kullanici1.Mail = reader["Mail"].ToString();
                kullanici1.Sifre = reader["Sifre"].ToString();
                kullanici1.RolID =(int) reader["RolID"];
                kullanici1.Kisi = KisiBul(kullanici1.KullaniciID);
                _kullaniciler.Add(kullanici1);
            }
            reader.Close();
          
            return _kullaniciler;
        }

        public static Kullanici KisiIDBul(int kisiID)
        {

            DBHelper dBHelper = new DBHelper();
            _kullaniciler.Clear();
            string cmdText = "select*from Kullanicilar Where KullaniciID=@id";
            Dictionary<string, object> kullanici = new Dictionary<string, object>();
            kullanici.Add("@id", kisiID);
            Kullanici kullanici1 = null;
            SqlDataReader reader = dBHelper.ExecuteReader(cmdText, kullanici);
            while (reader.Read())
            {
                kullanici1 = new Kullanici();
                kullanici1.KullaniciID = (int)reader["KullaniciID"];
                kullanici1.Mail = reader["Mail"].ToString();
                kullanici1.Sifre = reader["Sifre"].ToString();
                kullanici1.RolID = (int)reader["RolID"];
                kullanici1.Kisi = KisiBul(kullanici1.KullaniciID);
                _kullaniciler.Add(kullanici1);
            }
            reader.Close();

            return kullanici1;
        }
        public static Kisi KisiBul(int kullaniciID)
        {
            Manken manken = MankenDAL.MankenAdArama(kullaniciID);
            if (manken!=null)
            {
                return manken;    
            }
            else
            {
                Mudur mudur = MudurDAL.MudurGetir(kullaniciID);
                return mudur;
            }
      
        }

        public static int KullaniciSil(int kullaniciID)
        {
            DBHelper dBHelper = new DBHelper();
            string cmdText = "delete*from Kullanicilar where KullaniciID=@kullaniciID";
            Dictionary<string, object> sil = new Dictionary<string, object>();
            sil.Add("@kullaniciID",kullaniciID);
            int result = dBHelper.ExecuteNonQuery(cmdText,sil);
            return result;
        }
        public static int MusteriGuncelle(Kullanici kullanici)
        {
            DBHelper dBHelper = new DBHelper();
            string cmdText = "update Kullanicilar set Mail=@mail,Sifre=@sifre,RolID=@rol where KullaniciID=@kullaniciID";
            Dictionary<string, object> guncelle = new Dictionary<string, object>();
            guncelle.Add("@mail",kullanici.Mail);
            guncelle.Add("@sifre",kullanici.Sifre);
            guncelle.Add("@rol",kullanici.RolID);
            int result = dBHelper.ExecuteNonQuery(cmdText,guncelle);
            return result;
        }
        public static int KullaniciEkle(Kullanici kullanici)
        {
            DBHelper dBHelper = new DBHelper();
            string cmdText = "insert Kullanicilar(Mail,Sifre,RolID) values(@mail,@sifre,@rol)";
            Dictionary<string, object> ekle = new Dictionary<string, object>();
            ekle.Add("@mail",kullanici.Mail);
            ekle.Add("@sifre",kullanici.Sifre);
            ekle.Add("@rol",kullanici.RolID);
            //ekle.Add("@aktif",kullanici.Kisi.AKtifMi);//bu dogru mu?
            //ekle.Add("@oTarih",kullanici.Kisi.OlusturmaTarihi);
            int result = dBHelper.ExecuteNonQuery(cmdText,ekle);
            return result;     
        }

    }
}
