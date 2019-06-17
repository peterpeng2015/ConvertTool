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
        public MysqlHelper(string source = null)
        {

        }

        DataTable IDBHelper.Execute(string sql)
        {
            throw new NotImplementedException();
        }
    }
}
