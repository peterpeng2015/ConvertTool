using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertToolCore
{
    public class OracleMaterializedViewLogCreator : BaseCreator
    {
        public override string FillTemplate(string tableName)
        {
            DataRow[] array = _sourceDt.Select($"TableName='{tableName}'");
            string primaryKey = string.Empty;
            StringBuilder sb = new StringBuilder();

            int count = 0;
            for (int i = 0; i < array.Length; i++)
            {
                //主键处理
                if (array[i][4].ToString() == "1")
                {
                    if (primaryKey == string.Empty)
                    {
                        primaryKey = "primary key,";
                    }
                }
                else
                {
                    if (count > 0)
                    {
                        sb.Append($",{System.Environment.NewLine}");
                    }

                    sb.Append("     ");
                    count++;
                    sb.Append(array[i][1].ToString());
                }
            }

            return string.Format(_template, tableName, primaryKey, sb.ToString());
        }
    }
}
