using KareAjans.Entities.EntityClasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KareAjans.DAL
{
    public static class MudurDAL
    {
        public static Mudur MudurGetir(int kisiID)
        {
            DBHelper dBHelper = new DBHelper();
            string cmdText = "select*from Mudur where MudurID=@ad";
            Dictionary<string, object> mankenArama = new Dictionary<string, object>();
            mankenArama.Add("@ad", kisiID);
            SqlDataReader reader = dBHelper.ExecuteReader(cmdText, mankenArama);
            Mudur mudur = null;
        
            while (reader.Read())
            {
                mudur = new Mudur();
                mudur.Ad = reader["Ad"].ToString();
                mudur.Soyad = reader["Soyad"].ToString();
                mudur.Unvan = reader["Unvan"].ToString();
                mudur.MudurID = (int)reader["MudurID"];
                mudur.Adres = AdresDAL.AdresGetir(kisiID, "Mudur");
                mudur.Telefon = TelefonDAL.TelefonGetir(kisiID,"Mudur") ?? new List<string>();
                mudur.OlusturulmaTarihi = (DateTime)reader["OlusturulmaTarihi"];
                mudur.AKtifMi = (bool)reader["AktifMi"];

            }
            reader.Close();
            return mudur;


        }

    }
}
