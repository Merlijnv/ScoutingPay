using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ScoutingPay.Data
{
    public abstract class BaseMssqlContext
    {
        private readonly string _connectionString;
        protected BaseMssqlContext(string connString)
        {
            _connectionString = connString;
        }

        public DataSet ExecuteMssql(string query, List<KeyValuePair<string, string>> parameters)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                foreach (KeyValuePair<string, string> kvp in parameters)
                {
                    SqlParameter para = new SqlParameter();
                    para.ParameterName = "@" + kvp.Key;
                    para.Value = kvp.Value;
                    cmd.Parameters.AddWithValue(para.ParameterName, para.Value);
                }
                cmd.CommandText = query;
                da.SelectCommand = cmd;

                conn.Open();
                da.Fill(ds);
                conn.Close();
            }
            catch (Exception ex)
            {
                return null;
            }
            return ds;
        }
    }
}