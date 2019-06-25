using DBHelper;
using IOHelper;
using System;
using System.Data;
using System.Diagnostics;
/// <summary>
/// 命名规则 私有的属性用"_"开头
///               共有的不变
/// </summary>
namespace ConvertToolCore
{
    public abstract class BaseCreator
    {
        private string _configFullPath;//配置文件路径
        protected internal DataTable _sourceDt;//源数据
        protected internal string _template;//模板

        public DataBaseClass sourceDataBaseClass;//源数据库类型
        public DataBaseClass targetDataBaseClass;//目标数据库类型
        public string configFilePath;//配置文件路径
        public string dataTypeString;//数据类型字符串
        public string createPath;//创建文件路径
        public string createFileExtend;//创建文件后缀名
        public string sourceConnectionString;//源数据库连接字符串
        public bool isCover = true;//是否覆盖
        public bool isInOneFile = true;//是否保存为一个文件中
        public string fileName;//isInOneFile=true时要保存到文件的文件名

        /// <summary>
        /// 1.根据配置文件路径，找出配置文件
        /// 2.读取配置文件中的数据源节点，获取sql
        /// 3.执行sql，获取数据源
        /// </summary>
        /// <returns></returns>
        public virtual DataTable GetSource()
        {
            //节点名称
            string sectionName = $"{dataTypeString}_Source";

            //获取sql
            string sql = ConfigHelper.GetOtherConfig(_configFullPath, sectionName);

            return DBHelperFactory.CreateDBHelper(sourceDataBaseClass, sourceConnectionString).Execute(sql);
        }

        /// <summary>
        /// 1.根据配置文件路径，找出配置文件
        /// 2.读取配置文件中的数据源节点，获取模板
        /// </summary>
        /// <returns></returns>
        public virtual string GetTemplate()
        {
            //节点名称
            string sectionName = $"{dataTypeString}_Template";

            return ConfigHelper.GetOtherConfig(_configFullPath, sectionName);
        }

        /// <summary>
        /// 填充模板
        /// </summary>
        /// <returns></returns>
        public abstract string FillTemplate(string tableName);

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="file"></param>
        /// <param name="content"></param>
        public virtual void CreateFile(string file, string content)
        {
            WriteHelper helper = new WriteHelper(createPath, file);

            helper.Write(content, isCover);
        }

        public virtual void Run()
        {
            _configFullPath = $"{ configFilePath}\\{sourceDataBaseClass.ToString()}2{targetDataBaseClass.ToString()}.config";
            Stopwatch sw = new Stopwatch();
            sw.Start();
            _sourceDt = GetSource();
            sw.Stop();//结束计时  
            long times = sw.ElapsedMilliseconds; //获取运行时间[毫秒]  

            _template = GetTemplate();

            DataTable tableDt = _sourceDt.DefaultView.ToTable(true, "TableName");

            for (int i = 0; i < tableDt.Rows.Count; i++)
            {
                string tableName = tableDt.Rows[i]["TableName"].ToString();
                string content = FillTemplate(tableName);
                System.Console.WriteLine($"{tableName}开始创建。");

                if (!isInOneFile)
                {
                    fileName = tableName;
                }

                CreateFile($"{fileName}.{createFileExtend}", content);
                System.Console.WriteLine($"{fileName}创建完成！");
            }

            Console.WriteLine("===========================");
            Console.WriteLine($"获取数据源数据共耗时：{times}毫秒");
        }
    }
}
