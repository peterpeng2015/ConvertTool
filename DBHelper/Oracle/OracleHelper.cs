using IOHelper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace DBHelper
{
    public class OracleHelper : IDBHelper
    {
        private static string _connString = $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={ConfigHelper.GetAppConfig("Host")})(PORT={ConfigHelper.GetAppConfig("Port")}))(CONNECT_DATA=(SERVICE_NAME={ConfigHelper.GetAppConfig("DBName")})));Persist Security Info=True;User ID={ConfigHelper.GetAppConfig("UserName")};Password={ConfigHelper.GetAppConfig("Password")};";

        public OracleHelper(string connString = null)
        {
            if (!string.IsNullOrEmpty(connString))
            {
                _connString = connString;
            }
        }

        public DataTable Execute(string sql)
        {
            using (OracleConnection conn = new OracleConnection(_connString))
            {
                try
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = sql;
                        OracleDataAdapter ada = new OracleDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        ada.Fill(ds);
                        return ds.Tables[0];
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public DataSet ExecuteReturnDS(string sql)
        {
            using (OracleConnection conn = new OracleConnection(_connString))
            {
                try
                {
                    conn.Open();
                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = sql;
                        OracleDataAdapter ada = new OracleDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        ada.Fill(ds);

                        return ds;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool TestConnect()
        {
            bool isSuccConnect = false;

            using (OracleConnection conn = new OracleConnection(_connString))
            {
                try
                {
                    conn.Open();
                    isSuccConnect = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return isSuccConnect;
        }

    }
}
