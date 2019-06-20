using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConvertTool_Winform
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void tsb_quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsb_baseConfig_Click(object sender, EventArgs e)
        {
            frmBaseConfig frm = new frmBaseConfig();
            frm.TopLevel = false;
            frm.Parent = panel_main;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }
    }
}
