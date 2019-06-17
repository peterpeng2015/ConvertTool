using IOHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertToolCore
{
    public class SqlServerTableCreator : BaseCreator
    {
        private static List<Relation> _relation;

        public override string FillTemplate(string tableName)
        {
            DataRow[] columnDr = _sourceDt.Select($"TableName='{tableName}'");

            StringBuilder builder = new StringBuilder();
            string type = string.Empty;

            if (_relation == null)
            {
                _relation = GetTypeRelation();
            }

            for (int i = 0; i < columnDr.Length; i++)
            {

                //如果不是第一列，则在后面加入","隔开
                if (i > 0)
                {
                    builder.Append(",");
                    builder.Append(System.Environment.NewLine);
                }

                builder.Append("    ");
                //列名
                builder.Append($"[{columnDr[i][1].ToString()}]");

                //列类型
                type = columnDr[i][2].ToString().ToUpper();

                //列类型转换
                for (int j = 0; j < _relation.Count; j++)
                {
                    if (_relation[j].SourceType.ToUpper().Equals(type))
                    {
                        type = _relation[j].TargetType;

                        break;
                    }
                }
                builder.Append($" [{type}]");
                //列类型

                //字符类型-特殊处理
                if (type.ToUpper().Contains("CHAR"))
                {
                    builder.Append($"({columnDr[i][3].ToString()})");
                }
                //数量类型-特殊处理
                if (type.ToUpper().Contains("NUMERIC"))
                {
                    builder.Append($"({columnDr[i][3].ToString()},{columnDr[i][4].ToString()})");
                }

                //是否允许为null
                builder.Append($" {columnDr[i][5].ToString()}");
            }

            return string.Format(_template, tableName, builder.ToString());
        }

        /// <summary>
        /// 获取数据库类型映射
        /// </summary>
        /// <returns></returns>
        public List<Relation> GetTypeRelation()
        {
            string configFullPath = $"{ configFilePath}\\{sourceDataBaseClass.ToString()}2{targetDataBaseClass.ToString()}TypeRelation.json";

            string json = ReadHelper.Read(configFullPath);

            return JsonHelper.Json2List<Relation>(json);
        }
    }
}
