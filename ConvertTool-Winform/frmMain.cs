using ConvertToolCore;
using DBHelper;
using IOHelper;
using System;
using System.Windows.Forms;

namespace ConvertTool_Winform
{
    public partial class frmMain : Form
    {
        private string _sourceDataBaseType;
        private string _targetDataBaseType;

        public frmMain()
        {
            InitializeComponent();
        }

        private void tsb_quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmi_quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsmi_sourceConfig_Click(object sender, EventArgs e)
        {
            ShowForm(new frmDBConfig("Source"));
        }

        private void tsmi_targetConfig_Click(object sender, EventArgs e)
        {
            ShowForm(new frmDBConfig("Target"));
        }

        private void tsmi_generateConfig_Click(object sender, EventArgs e)
        {
            ShowForm(new frmGenerateConfig());
        }

        private void ShowForm(Form frm)
        {
            panel_main.Controls.Clear();
            frm.TopLevel = false;
            frm.Parent = panel_main;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Show();
        }

        private void tsmi_generate_Click(object sender, EventArgs e)
        {
            if (tsmi_generate.DropDownItems.Count > 0)
            {
                return;
            }

            _sourceDataBaseType = ConfigHelper.GetAppConfig("SourceDataBaseType");

            if (string.IsNullOrEmpty(_sourceDataBaseType))
            {
                MessageBox.Show("源数据库还没有设置！");

                return;
            }

            _targetDataBaseType = ConfigHelper.GetAppConfig("TargetDataBaseType");

            if (string.IsNullOrEmpty(_targetDataBaseType))
            {
                MessageBox.Show("目标数据库还没有设置！");

                return;
            }

            InitMenu();
        }

        private void InitMenu()
        {
            ToolStripMenuItem tsmi = new ToolStripMenuItem("物化视图日志");
            tsmi.Tag = "TAG";
            tsmi.Click += new EventHandler(ClickHandler);
            tsmi_generate.DropDownItems.Add(tsmi);
        }

        private void ClickHandler(object sender, EventArgs e)
        {
            Generate(0);
        }

        private void Generate(DataType dataType)
        {
            try
            {
                var creator = CreatorFactory.CreateInstance((DataBaseClass)Convert.ToInt32(_targetDataBaseType), dataType);

                creator.sourceDataBaseClass = (DataBaseClass)Convert.ToInt32(_sourceDataBaseType);
                creator.targetDataBaseClass = (DataBaseClass)Convert.ToInt32(_targetDataBaseType);
                creator.configFilePath = System.Environment.CurrentDirectory + "\\" + ConfigHelper.GetAppConfig("ConfigFilePath");
                creator.createPath = ConfigHelper.GetAppConfig("CreateFilePath");
                creator.createFileExtend = ConfigHelper.GetAppConfig("CreateFileExtent");
                creator.sourceConnectionString = ConfigHelper.GetAppConfig("SourceConnectionString");
                creator.isCover = !(ConfigHelper.GetAppConfig("IsCover") == "0");
                creator.isInOneFile = !(ConfigHelper.GetAppConfig("IsInOneFile") == "0");
                creator.fileName = ConfigHelper.GetAppConfig("FileName");

                creator.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
