using KareAjans.DAL;
using KareAjans.DTO;
using KareAjans.Entities.EntityClasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.BLL
{
    public class OrganizasyonBLL
    {
        public List<OrganizasyonDTO> OrganizasyonlarıGetir()
        {
            return OrganizasyonDAL.OrganizasyonDTOGetir();
        }
        public int SonOrganizasyonID()
        {
            int result = 0;
            List<OrganizasyonDTO> organizasyonDtos = OrganizasyonDAL.OrganizasyonDTOGetir();
            foreach (OrganizasyonDTO organizasyonDto in organizasyonDtos)
            {
                if (organizasyonDto.OrganizasyonID > result)
                {
                    result = organizasyonDto.OrganizasyonID;
                }
            }

            return result;
        }
        public int OrganizasyonGiderEkle(List<OrganizasyonGider> organizasyonGider)
        {
            return OrganizasyonGiderDAL.GiderEkle(organizasyonGider);
        }
        public int OrganizasyonEkle(Organizasyon organizasyon)
        {
            return OrganizasyonDAL.OrganizasyonEkle(organizasyon);
        }

        public OrganizasyonDTO OrganizasyonGetir(string orgAd)
        {
            List<OrganizasyonDTO> organizasyonDtos = OrganizasyonDAL.OrganizasyonDTOGetir();
            foreach (OrganizasyonDTO organizasyon in organizasyonDtos)
            {
                if (organizasyon.Ad == orgAd)
                {
                    return organizasyon;
                }
            }
            return new OrganizasyonDTO();
        }
        public OrganizasyonDTO OrganizasyonGelirGetir(int orgId)
        {
            return OrganizasyonDAL.OrganizasyonDTOGelirGetir(orgId);
        }
        public SqlDataAdapter OrganizasyonAdapter()
        {
            return OrganizasyonDAL.AdapterGetir();
        }
        public SqlDataAdapter MuhasebeAdapterGetir(int organizayonID)
        {
            return OrganizasyonDAL.MuhasebeAdapterGetir(organizayonID);
        }
    }
}
