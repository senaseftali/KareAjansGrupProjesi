
using KareAjans.DAL;
using KareAjans.DTO;
using KareAjans.Entities.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.BLL
{
   public class KullaniciBLL
    {

        public Kullanici Giris(LoginDTO giris)
        {
            List<Kullanici> kullanicilar = KullaniciDAL.KullaniciGetir();
            foreach (Kullanici item in kullanicilar)
            {
                if(item.Mail == giris.Mail)
                {
                    if (item.Sifre == giris.Sifre)
                    {
                        return item;
                    }
                    else
                    {
                        throw new Exception("Şifre hatalı");
                    }
                }
            }
            throw new Exception("Mail hatalı");
        }

        public Kullanici KullaniciGetir(int id)
        {
            return KullaniciDAL.KisiIDBul(id);
        }
        
    }
}
