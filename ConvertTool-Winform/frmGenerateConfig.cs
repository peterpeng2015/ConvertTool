using CommomUserControls;
using IOHelper;
using System;
using System.Windows.Forms;

namespace ConvertTool_Winform
{
    public partial class frmGenerateConfig : Form
    {
        public string path;//生成文件存放路径
        public string ext;//生成文件后缀名
        public int isCover;//生成时是否覆盖同名文件
        public int isInOneFile;//生成时是否生成一个文件
        public string fileName;//生成一个文件时的文件名

        public frmGenerateConfig()
        {
            InitializeComponent();
        }

        private void frmGenerateConfig_Load(object sender, EventArgs e)
        {
            path = ConfigHelper.GetAppConfig("CreateFilePath");
            ext = ConfigHelper.GetAppConfig("CreateFileExtent");
            isCover = Convert.ToInt32(ConfigHelper.GetAppConfig("IsCover"));
            isInOneFile = Convert.ToInt32(ConfigHelper.GetAppConfig("IsInOneFile"));
            fileName = ConfigHelper.GetAppConfig("FileName");

            txt_path.Text = path;
            txt_ext.Text = ext;
            cbb_isCover.SelectedIndex = isCover;
            cbb_isOneFile.SelectedIndex = isInOneFile;
            txt_fileName.Text = fileName;
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txt_path.Text = dialog.SelectedPath;
            }
        }

        private void tsb_quit_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Clear();
        }

        private void tsb_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_path.Text.Replace(@"\", @"\\")))
            {
                MessageBox.Show("生成文件路径不能为空！");

                return;
            }

            if (string.IsNullOrEmpty(txt_ext.Text))
            {
                MessageBox.Show("生成文件后缀名不能为空！");

                return;
            }

            if (cbb_isCover.SelectedItem == null)
            {
                MessageBox.Show("没有选择是否覆盖同名文件！");

                return;
            }

            if (cbb_isOneFile.SelectedItem == null)
            {
                MessageBox.Show("没有选择是否生成一个文件！");

                return;
            }

            if (cbb_isOneFile.SelectedIndex == 1 && string.IsNullOrEmpty(txt_fileName.Text.Trim()))
            {
                MessageBox.Show("当选择生成一个文件时，文件名不能为空！");

                return;
            }

            path = txt_path.Text.Replace(@"\", @"\\");
            ext = txt_ext.Text.Trim();
            isCover = cbb_isCover.SelectedIndex;
            isInOneFile = cbb_isOneFile.SelectedIndex;
            fileName = txt_fileName.Text;

            ConfigHelper.UpdateAppConfig("CreateFilePath", path);
            ConfigHelper.UpdateAppConfig("CreateFileExtent", ext);
            ConfigHelper.UpdateAppConfig("IsCover", isCover.ToString());
            ConfigHelper.UpdateAppConfig("IsInOneFile", isInOneFile.ToString());
            ConfigHelper.UpdateAppConfig("FileName", fileName);

            MessageBoxHelper.Warning("保存成功！");
        }
    }
}
