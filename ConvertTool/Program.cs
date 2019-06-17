using ConvertToolCore;
using DBHelper;
using IOHelper;
using System;
using System.Diagnostics;

namespace ConvertTool
{
    class Program
    {
        /// <summary>
        ///  程序入口
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("0=Oracle视图,1=SqlServer无主键表结构,2=SqlServer主键,3=SqlServer索引,4=Oracle物化视图日志,5=Oracle物化视图");
            Console.WriteLine("请对应输入要选择的功能的数字：");

            string result = Console.ReadLine().Trim();

            int index = 0;

            if (!int.TryParse(result, out index))
            {
                Console.WriteLine("请输入正确的数字！");

                return;
            }

            if (index < 0 || index > 5)
            {
                Console.WriteLine("请输入符合的数字！");
                return;
            }

            Console.WriteLine("任务开始");
            Console.WriteLine("===========================");

            Stopwatch sw = new Stopwatch();
            sw.Start();

            DataBaseClass sourceDataBaseClass = (DataBaseClass)Convert.ToInt32(ConfigHelper.GetAppConfig("SourceDataBaseType"));

            DataBaseClass targetDataBaseClass = (DataBaseClass)Convert.ToInt32(ConfigHelper.GetAppConfig("TargetDataBaseType"));

            //DataType dataType = (DataType)Convert.ToInt32(ConfigHelper.GetAppConfig("CreateDataType"));

            DataType dataType = (DataType)index;

            try
            {
                var creator = CreatorFactory.CreateInstance(targetDataBaseClass, dataType);

                creator.sourceDataBaseClass = sourceDataBaseClass;
                creator.targetDataBaseClass = targetDataBaseClass;
                creator.configFilePath = System.Environment.CurrentDirectory + "\\" + ConfigHelper.GetAppConfig("ConfigFilePath");
                creator.createPath = ConfigHelper.GetAppConfig("CreateFilePath");
                creator.createFileExtend = ConfigHelper.GetAppConfig("CreateFileExtent");
                creator.sourceConnectionString = ConfigHelper.GetAppConfig("SourceConnectionString");
                creator.isCover = !(ConfigHelper.GetAppConfig("IsCover") == "0");

                creator.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            sw.Stop();

            Console.WriteLine("===========================");
            long times = sw.ElapsedMilliseconds; //获取运行时间[毫秒]  
            Console.WriteLine($"生成全程总耗时：{times}毫秒");
            Console.WriteLine("全部生成完成！");
            Console.ReadLine();

        }
    }
}
