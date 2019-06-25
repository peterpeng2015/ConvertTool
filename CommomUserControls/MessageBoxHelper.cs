using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommomUserControls
{
    public class MessageBoxHelper
    {
        public static void Warning(string msg)
        {
            System.Windows.Forms.MessageBox.Show(msg, "提醒", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }

        public static void Infor(string msg)
        {
            System.Windows.Forms.MessageBox.Show(msg, "提醒", System.Windows.Forms.MessageBoxButtons.OKCancel, System.Windows.Forms.MessageBoxIcon.Information);
        }
    }
}
