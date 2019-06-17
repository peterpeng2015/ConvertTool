using System.Data;

namespace DBHelper
{
    public interface IDBHelper
    {
        DataTable Execute(string sql);
    }
}
