using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOHelper
{
    public class LogHelper
    {
        string filePath = System.Environment.CurrentDirectory + "\\log";

        public LogHelper()
        {

        }

        public void Info(string msg)
        {
            string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            WriteHelper helper = new WriteHelper(filePath, fileName);

            helper.Write($"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")} [INFO] : {msg}{System.Environment.NewLine}", false);
        }
    }
}
