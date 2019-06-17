using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertToolCore
{
    public class OracleMaterializedViewCreator : BaseCreator
    {
        public override string FillTemplate(string tableName)
        {
            DataRow[] array = _sourceDt.Select($"TableName='{tableName}'");
            string type = string.Empty;
            StringBuilder allColumnType = new StringBuilder();
            StringBuilder allPrimaryColumn = new StringBuilder();
            StringBuilder allNoPriColumn = new StringBuilder();
            StringBuilder allPrimaryColumnWithSrc = new StringBuilder();
            StringBuilder allNoPriColumnWithSrc = new StringBuilder();
            string indexColumn = string.Empty;

            for (int i = 0; i < array.Length; i++)
            {
                //主键处理
                if (array[i][4].ToString() == "1")
                {
                    indexColumn = "have";
                    allPrimaryColumn.Append(array[i][1].ToString());
                    allPrimaryColumnWithSrc.Append($"src.{array[i][1].ToString()}");
                    allPrimaryColumn.Append($",{System.Environment.NewLine}");
                    allPrimaryColumnWithSrc.Append($",{System.Environment.NewLine}");
                }
                else
                {
                    allNoPriColumn.Append(array[i][1].ToString());
                    allNoPriColumnWithSrc.Append($"src.{array[i][1].ToString()}");
                    allNoPriColumn.Append($",{System.Environment.NewLine}");
                    allNoPriColumnWithSrc.Append($",{System.Environment.NewLine}");
                }

                allColumnType.Append($"{array[i][1].ToString()} ");

                if ((array[i][2].ToString().ToUpper().Contains("CHAR") || array[i][2].ToString().ToUpper().ToUpper().Contains("RAW")))
                {
                    allColumnType.Append($"{array[i][2].ToString()}({array[i][3].ToString()})");
                }
                else if (array[i][2].ToString().ToUpper().ToUpper().Contains("NUMBER"))
                {
                    allColumnType.Append($"{array[i][2].ToString()}({array[i][3].ToString()},{array[i][5].ToString()})");
                }
                else
                {
                    allColumnType.Append(array[i][2].ToString());
                }
                allColumnType.Append($",{System.Environment.NewLine}");
            }

            if (indexColumn == string.Empty)
            {
                indexColumn = allNoPriColumn.ToString();
            }
            else
            {
                indexColumn = allPrimaryColumn.ToString();
            }

            return string.Format(_template, tableName, allColumnType.ToString(), allPrimaryColumn.ToString(), allPrimaryColumnWithSrc.ToString(), allNoPriColumnWithSrc.ToString(), indexColumn, type, allNoPriColumn.ToString());
        }
    }
}
