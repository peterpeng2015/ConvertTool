using System.Data;
using System.Text;

namespace ConvertToolCore
{
    public class SqlServerPrimaryKeyCreator : BaseCreator
    {
        public override string FillTemplate(string tableName)
        {
            DataRow[] array = _sourceDt.Select($"TableName='{tableName}'");

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < array.Length; i++)
            {
                if (i > 0)
                {
                    builder.Append(",");
                    builder.Append(System.Environment.NewLine);
                }
                builder.Append("    ");
                builder.Append($"[{array[i][2].ToString()}]");
                builder.Append($" {array[i][4].ToString()}");
            }

            return string.Format(_template, tableName, builder.ToString());
        }
    }
}
