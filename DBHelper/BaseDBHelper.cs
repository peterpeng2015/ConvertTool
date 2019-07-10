using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper
{
    public abstract class BaseDBHelper
    {
        public abstract DataTable Execute(string sql);

        public BaseDBHelper()
        {

        }

        public BaseDBHelper(string source)
        {

        }
    }
}
