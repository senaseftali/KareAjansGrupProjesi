using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL
{
    public class DBHelper
    {
        public SqlConnection conn;
        SqlCommand cmd;
        public DBHelper()
        {
            conn = new SqlConnection(Properties.Settings.Default.KareAjans);
            cmd = new SqlCommand();
            cmd.Connection = conn;
        }
        public int ExecuteNonQuery(string cmdText, Dictionary<string, object> parameters)
        {
            cmd.CommandText = cmdText;
            cmd.Parameters.Clear();

            foreach (KeyValuePair<string, object> item in parameters)
            {
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            }

            conn.Open();
            int result = cmd.ExecuteNonQuery();
            conn.Close();

            return result;

        }
        internal object ExecuteScalar(string cmdText, Dictionary<string, object> parameters)
        {
            cmd.CommandText = cmdText;
            cmd.Parameters.Clear();

            foreach (KeyValuePair<string, object> item in parameters)
            {
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            }

            conn.Open();
            object result = cmd.ExecuteScalar();
            conn.Close();

            return result;
        }

        internal SqlDataReader ExecuteReader(string cmdText, Dictionary<string, object> parameters)
        {
            cmd.CommandText = cmdText;
            foreach (KeyValuePair<string, object> item in parameters)
            {
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            }

            conn.Open();
            SqlDataReader result = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            return result;
        }
        public SqlDataAdapter AdapterGetir(string cmdText, Dictionary<string, object> parameters)
        {

            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            cmd.CommandText = cmdText;
            adapter.SelectCommand = cmd;
            foreach (KeyValuePair<string, object> item in parameters)
            {
                cmd.Parameters.AddWithValue(item.Key, item.Value);
            }
            return adapter;
        }
    }
}
