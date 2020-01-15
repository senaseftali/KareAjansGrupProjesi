using KareAjans.Entities.EntityClasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL
{
   public static class MusteriDAL
    {
        static List<Musteri> _musteriler;
        static MusteriDAL()
        {
            _musteriler = new List<Musteri>();
        }
        public static List<Musteri> MusteriGetir()
        {
            DBHelper dBHelper = new DBHelper();
            _musteriler.Clear();
            string cmdText = "select*from Musteri";
            Dictionary<string, object> musteriler = new Dictionary<string, object>();
            SqlDataReader reader = dBHelper.ExecuteReader(cmdText,musteriler);
            Musteri musteri = null;
            while (reader.Read())
            {
                musteri = new Musteri();
                musteri.Ad = reader["Ad"].ToString();
                musteri.MusteriID = (int)reader["MusteriID"];
                musteri.Yetkili = reader["Yetkili"].ToString();
                musteri.Telefon = TelefonDAL.TelefonGetir(musteri.MusteriID,"Musteri");//Burada KişiID'sine göre yapmışız.
                musteri.MusteriAdres = AdresDAL.AdresGetir(musteri.MusteriID,"Musteri");//burada AdresDAL'da sorguda sadeca manken için yazmışız.Bakalım.
            }
            reader.Close();
            return _musteriler;
        }
       
        public static int MusteriEkle(Musteri musteri)
        {
            DBHelper dBHelper = new DBHelper();
            string cmdText = "insert Musteri(MusteriID,Ad,Yetkili,AdresID) values(@musteriID,@ad,@yetkili,@adresID)";
            Dictionary<string, object> musteriler = new Dictionary<string, object>();
            musteriler.Add("@musteriID",musteri.MusteriID);
            musteriler.Add("@ad",musteri.Ad);
            musteriler.Add("yetkili", musteri.Yetkili);
            musteriler.Add("@adresID",musteri.MusteriAdres);
            musteriler.Add("", musteri.Telefon);//veritabınında telefon yok ekleme nasıl olacak.Güncellemede aynısı bak.
            int result = dBHelper.ExecuteNonQuery(cmdText,musteriler);
            return result;
        }
        public static int MusteriSil(int musteriID)
        {
            DBHelper dBHelper = new DBHelper();
            string cmdText = "delete from Musteri where Musteri=@musteriID";
            Dictionary<string, object> musteriSil = new Dictionary<string, object>();
            musteriSil.Add("@musteriID",musteriID);
            int result = dBHelper.ExecuteNonQuery(cmdText,musteriSil);
            return result;
        }
        public static int MusteriGuncelle(Musteri musteri)
        {
            DBHelper dBHelper = new DBHelper();
            string cmdText = "update Musteri set Ad=@ad,Yetkili=@yetkili,AdresID=@adresID";
            Dictionary<string, object> musteriGuncel = new Dictionary<string, object>();
            musteriGuncel.Add("@ad",musteri.Ad);
            musteriGuncel.Add("@yetkili",musteri.Yetkili);
            musteriGuncel.Add("@adresID",musteri.MusteriAdres);
            int result = dBHelper.ExecuteNonQuery(cmdText,musteriGuncel);
            return result;
        }
        
    }
}
