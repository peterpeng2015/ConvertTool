using DBHelper;
using System;
using System.Windows.Forms;

namespace CommomUserControls
{
    public partial class DBConnect : UserControl
    {
        public string _connString;
        //定义关闭窗口委托
        public delegate void CloseHandle(object sender, EventArgs e);
        //定义关闭窗口委托实例
        public event CloseHandle UCClose;

        //定义连接数据源委托
        public delegate void ConnectHandle(bool isTest);
        //定义连接数据源委托实例
        public ConnectHandle Connect;

        public string _host;//主机名
        public string _port;//端口号
        public string _dbName;//数据库名
        public string _userName;//用户名
        public string _password;//密码
        public DataBaseClass _dbClass;

        public DBConnect()
        {
            InitializeComponent();
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (CheckValue())
            {
                if (Connect != null)
                    Connect(false);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (UCClose != null)
                UCClose(sender, e);
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            if (CheckValue())
            {
                if (Connect != null)
                    Connect(true);
            }
        }

        private void OracleConnect_Load(object sender, EventArgs e)
        {
            txt_Host.Text = _host;
            txt_Port.Text = _port;
            txt_DBName.Text = _dbName;
            txt_UserName.Text = _userName;
            txt_Password.Text = _password;
        }

        public bool CheckValue()
        {
            if (string.IsNullOrEmpty(txt_Host.Text.Trim()))
            {
                MessageBox.Show("主机名不能为空！");

                return false;
            }

            if (string.IsNullOrEmpty(txt_Port.Text.Trim()))
            {
                MessageBox.Show("端口号不能为空！");

                return false;
            }

            if (string.IsNullOrEmpty(txt_DBName.Text.Trim()))
            {
                MessageBox.Show("数据库名不能为空！");

                return false;
            }

            if (string.IsNullOrEmpty(txt_UserName.Text.Trim()))
            {
                MessageBox.Show("用户名不能为空！");

                return false;
            }

            if (string.IsNullOrEmpty(txt_Password.Text.Trim()))
            {
                MessageBox.Show("密码不能为空！");

                return false;
            }

            _connString = "";

            _host = txt_Host.Text.Trim();
            _port = txt_Port.Text.Trim();
            _dbName = txt_DBName.Text.Trim();
            _userName = txt_UserName.Text.Trim();
            _password = txt_Password.Text.Trim();

            switch (_dbClass)
            {
                case DataBaseClass.SqlServer:
                    _connString = $" Server={_host};user id={_userName};password={_password};Connect Timeout=;Application Name=;Database={_dbName};";
                    break;
                case DataBaseClass.Oracle:
                    _connString = $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={_host})(PORT={_port}))(CONNECT_DATA=(SERVICE_NAME={_dbName})));Persist Security Info=True;user id={_userName};password={_password};";
                    break;
                case DataBaseClass.Mysql:
                    break;
                case DataBaseClass.DB2:
                    break;
                case DataBaseClass.MongoDB:
                    break;
                default:
                    throw new NotSupportedException("不支持的数据库类型!");
            }

            return true;
        }
    }
}
