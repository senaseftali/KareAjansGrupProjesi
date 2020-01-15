using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.Entities.EntityClasses
{
    public class Organizasyon
    {
        public Organizasyon()
        {
            OrganizasyonGider = new List<OrganizasyonGider>();
            OrganizasyonGelir = new List<OrganizasyonGelir>();
            OrganizasyonAdres = new List<Adres>();
        }
        public int OrganizasyonID { get; set; }
        public int MusteriID { get; set; }
        public string Ad { get; set; }
        public DateTime BaslangicTArihi { get; set; }
        public DateTime BitisTarihi { get; set; }

        public List<OrganizasyonGider> OrganizasyonGider { get; set; }
        public List<OrganizasyonGelir> OrganizasyonGelir { get; set; }
        public List<Adres> OrganizasyonAdres { get; set; }



    }
}
