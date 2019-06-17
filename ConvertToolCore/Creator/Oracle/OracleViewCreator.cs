using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertToolCore
{
    public class OracleViewCreator : BaseCreator
    {
        public override string FillTemplate(string tableName)
        {
            DataRow[] columnDr = _sourceDt.Select($"TableName='{tableName}'");

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < columnDr.Length; i++)
            {
                string columnName = columnDr[i]["ColumnName"].ToString();

                columnName = Handle(columnDr[i]["DataType"].ToString(), columnName);
                sb.Append("     ");
                if (i != (columnDr.Length - 1))
                {
                    sb.Append(string.Concat(columnName, ","));
                    sb.Append(System.Environment.NewLine);
                }
                else
                {
                    sb.Append(columnName);
                }
            }

            return string.Format(_template, dataTypeString + "_" + tableName, sb.ToString(), tableName);
        }

        private string Handle(string dataType, string columnName)
        {
            if ("date".Equals(dataType.ToLower()) || "datetime".Equals(dataType.ToLower()))
            {
                return $"case when a.{columnName}>=date'1900-01-01' then a.{columnName} end {columnName}";
            }
            else
            {
                return string.Concat("a.", columnName);
            }
        }
    }
}
