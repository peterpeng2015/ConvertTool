using System.Data;
using System.Text;

namespace ConvertToolCore
{
    public class SqlServerIndexCreator : BaseCreator
    {
        public override string FillTemplate(string tableName)
        {
            //该表的所有索引集合
            DataTable dt = _sourceDt.Select($"TableName='{tableName}'").CopyToDataTable();

            //不同的索引名称的集合
            DataTable indexDt = dt.DefaultView.ToTable(true, "index_name");

            StringBuilder builder = new StringBuilder();

            //不同的索引
            for (int i = 0; i < indexDt.Rows.Count; i++)
            {
                StringBuilder sb = new StringBuilder();
                string indexName = indexDt.Rows[i][0].ToString();

                //同一索引的字段集合
                DataRow[] indexArray = dt.Select($"index_name='{indexName}'");

                string unique = string.Empty;
                for (int j = 0; j < indexArray.Length; j++)
                {
                    unique = indexArray[j][5].ToString();

                    if (!unique.ToUpper().Equals("UNIQUE"))
                    {
                        unique = "";
                    }

                    if (j > 0)
                    {
                        sb.Append(",");
                        sb.Append(System.Environment.NewLine);
                    }

                    sb.Append("    ");
                    sb.Append($"[{indexArray[j][2].ToString()}] ");
                    sb.Append($"{indexArray[j][4].ToString()} ");
                }

                builder.Append(string.Format(_template, unique, indexName, tableName, sb.ToString()));
                builder.Append(System.Environment.NewLine);
            }

            return builder.ToString();
        }
    }
}
