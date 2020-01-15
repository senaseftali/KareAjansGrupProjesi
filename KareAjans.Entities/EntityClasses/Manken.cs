using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.Entities.EntityClasses
{
    public class Manken:Kisi
    {
        public Manken()
        {
            MankenResim = new List<Resim>();
            Dil = new List<string>();
            Yorumlar = new List<Yorum>();
        }
        public int MankenID { get; set; }
        public int KategoriID { get; set; }
        public decimal AyakkabiNo { get; set; }
        public short Beden { get; set; }
        public decimal Kilo { get; set; }
        public string SacRengi { get; set; }
        public string GözRengi { get; set; }
        public bool SehirDisiDurumu { get; set; }
        public bool Ehliyet { get; set; }
        public string Ozellik { get; set; }
        public bool Durum { get; set; }




        public List<Resim> MankenResim { get; set; }
        public List<string> Dil { get; set; }
        public List<Yorum> Yorumlar { get; set; }


    }
}
