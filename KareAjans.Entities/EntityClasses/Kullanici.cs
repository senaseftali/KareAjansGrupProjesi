using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.Entities.EntityClasses
{
    public class Kullanici
    {
        public int KullaniciID { get; set; }
        public int RolID { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
        public Kisi Kisi { get; set; }

    }
}
