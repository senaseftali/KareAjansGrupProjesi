using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.Entities.EntityClasses
{
   public class OrganizasyonGider
    {
        public int OrganizasyonID { get; set; }
        public int MankenID { get; set; }
        public Manken Manken { get; set; }
        public decimal Butce { get; set; }
        public int KategoriUcKisiSayisi { get; set; }
        public decimal OgunUcreti { get; set; }
        public decimal KonaklamaUcreti { get; set; }
        public decimal GelirYuzdesi { get; set; }
        public decimal GunlukUcret { get; set; }
        public short GunSayisi { get; set; }
    }
}
