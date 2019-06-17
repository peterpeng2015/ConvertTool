using System;
using System.Reflection;

namespace DBHelper
{
    public class DBHelperFactory
    {
        public static IDBHelper CreateDBHelper(DataBaseClass dataBaseClass, string sourceConnectionString)
        {
            IDBHelper dbHelper = null;

            //通过类名约束反射出要创建的实体
            string className = $"{dataBaseClass.ToString()}Helper";

            Assembly assembly = Assembly.GetExecutingAssembly();

            object[] parameters = new object[1];
            parameters[0] = sourceConnectionString;

            dynamic obj = assembly.CreateInstance($"DBHelper.{className}", true, System.Reflection.BindingFlags.Default, null, parameters, null, null);// 创建类的实例 


            if (obj == null)
            {
                throw new NullReferenceException("没找到对应数据库访问的类！");
            }

            dbHelper = (IDBHelper)obj;

            return dbHelper;
        }
    }
}
