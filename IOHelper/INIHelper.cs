using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IOHelper
{
    public class INIHelper
    {
        public static string iniFileName = AppDomain.CurrentDomain.BaseDirectory + System.IO.Path.DirectorySeparatorChar + "config.ini";

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public static void WriteIni(string Section, string Key, string strValue)
        {
            WritePrivateProfileString(Section, Key, strValue, iniFileName);
        }

        public static string ReadIni(string Section, string Key, string Default)
        {
            StringBuilder temp = new StringBuilder(1024);
            int rec = GetPrivateProfileString(Section, Key, Default, temp, 1024, iniFileName);
            return temp.ToString();
        }

    }
}
