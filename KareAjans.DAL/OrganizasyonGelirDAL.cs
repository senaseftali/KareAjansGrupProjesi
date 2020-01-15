using KareAjans.Entities.EntityClasses;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL
{
    public static class OrganizasyonGelirDAL
    {
        static List<OrganizasyonGelir> _organizasyonGelir;

        public static List<OrganizasyonGelir> OrganizasyonGelirGetir(int orgID)
        {
            DBHelper dBHelper = new DBHelper();
            _organizasyonGelir.Clear();
            string cmdtext = "select*from OrganizasyonGelir where OrganizasyonID=@orgid";
            Dictionary<string, object> organizasyon = new Dictionary<string, object>();
            organizasyon.Add("@orgid", orgID);
            OrganizasyonGelir gelir = null;
            SqlDataReader reader = dBHelper.ExecuteReader(cmdtext,organizasyon);           
            while (reader.Read())
            {
                gelir = new OrganizasyonGelir();
                gelir.OrganizasyonID = (int)reader["OrganizasyonID"];
                gelir.Butce = (decimal)reader["Butce"];
                _organizasyonGelir.Add(gelir);
            }
            reader.Close();
            return _organizasyonGelir;
        }
        public static List<OrganizasyonGelir> OrganizasyonGelirGetir()
        {
            DBHelper dBHelper = new DBHelper();
            _organizasyonGelir.Clear();
            string cmdtext = "select*from OrganizasyonGelir";
            Dictionary<string, object> organizasyon = new Dictionary<string, object>();  
            
            OrganizasyonGelir gelir = null;
            SqlDataReader reader = dBHelper.ExecuteReader(cmdtext, organizasyon);
            while (reader.Read())
            {
                gelir = new OrganizasyonGelir();
                gelir.OrganizasyonID = (int)reader["OrganizasyonID"];
                gelir.Butce = (decimal)reader["Butce"];
                _organizasyonGelir.Add(gelir);
            }
            reader.Close();
            return _organizasyonGelir;
        }
        public static int GelirEkle(OrganizasyonGelir organizasyonGelir)
        {
            DBHelper dbHelper = new DBHelper();
            string cmdText = "insert into OrganizasyonGelir(OrganizasyonID,Butce) values(@id,@butce)";
            Dictionary<string, object> parametreler = new Dictionary<string, object>();
            parametreler.Add("@id", organizasyonGelir.OrganizasyonID);
            parametreler.Add("@butce", organizasyonGelir.Butce);
            int result = dbHelper.ExecuteNonQuery(cmdText, parametreler);
            return result;
        }

    }
}
