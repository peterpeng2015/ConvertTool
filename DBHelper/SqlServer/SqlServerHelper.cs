using IOHelper;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DBHelper
{
    public class SqlServerHelper : IDBHelper
    {
        private static string _connectionString;

        public SqlServerHelper()
        {
            _connectionString = ConfigHelper.GetAppConfig("connectionString");

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ArgumentNullException("数据库连接未设置！！");
            }
        }

        public SqlServerHelper(string source)
        {
            _connectionString = source;
        }

        public DataTable Execute(string sql)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, _connectionString))
            {
                DataTable dt = new DataTable();

                try
                {
                    adapter.Fill(dt);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return dt;
            }
        }

        public int ExecuteNoQuery(string sql)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }
            }
        }

        public object ExecuteScalar(string sql)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        return cmd.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
    }
}
