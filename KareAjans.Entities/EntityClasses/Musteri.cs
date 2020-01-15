using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.Entities.EntityClasses

{
    public class Musteri
    {
        public int MusteriID { get; set; }
        public string Ad { get; set; }
        public string Yetkili { get; set; }
        public List<Adres> MusteriAdres { get; set; }
        public List<string> Telefon { get; set; }
    }
}
