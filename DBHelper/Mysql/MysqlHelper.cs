using IOHelper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper
{
    public class MysqlHelper : IDBHelper
    {
        private static string _connectionString;

        public MysqlHelper()
        {
            _connectionString = ConfigHelper.GetAppConfig("connectionString");

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new ArgumentNullException("数据库连接未设置！！");
            }
        }

        public MysqlHelper(string source)
        {
            _connectionString = source;
        }

        public DataTable Execute(string sql)
        {
            using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, _connectionString))
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
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
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
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
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
