using System.Data;

namespace DBHelper
{
    public interface IDBHelper
    {
        DataTable Execute(string sql);
        object ExecuteScalar(string sql);
        int ExecuteNoQuery(string sql);
    }
}
