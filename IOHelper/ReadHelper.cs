using System;
using System.IO;

namespace IOHelper
{
    public class ReadHelper
    {
        public static string Read(string filePath)
        {
            string file = string.Empty;

            try
            {
                file = File.ReadAllText(filePath, System.Text.Encoding.Default);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return file;
        }
    }
}
