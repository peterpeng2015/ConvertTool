using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertToolCore
{
    public class SqlServerViewCreator : BaseCreator
    {
        public override string FillTemplate(string tableName)
        {
            DataRow[] columnDr = _sourceDt.Select($"TableName='{tableName}'");

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < columnDr.Length; i++)
            {
                string columnName = columnDr[i]["ColumnName"].ToString();

                sb.Append("     ");
                if (i != (columnDr.Length - 1))
                {
                    sb.Append($"a.{columnName},");
                    sb.Append(System.Environment.NewLine);
                }
                else
                {
                    sb.Append($"a.{columnName}");
                }
            }

            return string.Format(_template, dataTypeString + "_" + tableName, sb.ToString(), tableName);
        }
    }
}
