using KareAjans.DAL;
using KareAjans.DTO;
using KareAjans.Entities.EntityClasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KareAjans.BLL
{
    public class MankenBLL
    {

        public List<Manken> MankenleriGetir()
        {
            return MankenDAL.MankenGetir();
        }
        public SqlDataAdapter MankenAdapter()
        {
            return MankenDAL.MankenAdapterGetir();
        }
        public int MankenEkle(Manken manken, string mail, string sifre)
        {
            int result = MankenDAL.MankenEkle(manken, mail, sifre);
            return result;

        }

        public int MankenGuncelle(Manken manken)
        {
            int result = MankenDAL.MankenGuncelle(manken);
            return result;
        }

        public int MankenSil(Manken manken)
        {
            int result = MankenDAL.MankenSil(manken.MankenID);
            return result;

        }
        public SqlDataAdapter UygunMankenGetirAdapter()
        {
            return MankenDAL.MankenAdapterGetir();

        }
        public Manken MankenGetir(int mankenID)
        {
            return MankenDAL.MankenAdArama(mankenID);
        }
        public List<MankenAdDTO> MankenAdDTOGetir()
        {
            return MankenDAL.MankenAdGetir();
        }



    }
}
