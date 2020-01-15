using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.Entities.EntityClasses
{
    public abstract class Kisi
    {
        public Kisi()
        {
            Adres = new List<Adres>();
            Telefon = new List<string>();
            AKtifMi = true;
        }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public bool AKtifMi { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public List<Adres> Adres { get; set; }
        public List<string> Telefon { get; set; }
       
    }
}
