using DBHelper;
using System;
using System.Reflection;

namespace ConvertToolCore
{
    public class CreatorFactory
    {
        public static BaseCreator CreateInstance(DataBaseClass targetDataBaseClass, DataType dataType)
        {
            //通过类名约束反射出要创建的实体
            //类名=目标库类型+数据类型+“Creator"
            string className = $"{targetDataBaseClass}{dataType.ToString()}Creator";

            Assembly assembly = Assembly.GetExecutingAssembly();

            dynamic obj = assembly.CreateInstance($"ConvertToolCore.{className}"); // 创建类的实例 

            if (obj == null)
            {
                throw new NullReferenceException("没找到对应创建功能的类！");
            }

            BaseCreator creator = (BaseCreator)obj;

            creator.dataTypeString = dataType.ToString();

            return creator;
        }
    }
}
