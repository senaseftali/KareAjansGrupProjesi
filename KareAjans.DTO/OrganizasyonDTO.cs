using KareAjans.Entities.EntityClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DTO
{
    public class OrganizasyonDTO
    {
        public int OrganizasyonID { get; set; }
        public string Ad { get; set; }
        public decimal OrganizasyonGelir { get; set; }
        public DateTime BaslangicTArihi { get; set; }
        public DateTime BitisTarihi { get; set; }
        public int Kat3KişiSayısı { get; set; }
        public string Yer { get; set; }
        public Adres Adres { get; set; }
        public int OrganızasyonGünSayısı
        {
            get { return (int)(BitisTarihi - BaslangicTArihi).TotalDays; }
        }
    }
}
