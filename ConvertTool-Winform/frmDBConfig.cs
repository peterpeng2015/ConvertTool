using CommomUserControls;
using DBHelper;
using IOHelper;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ConvertTool_Winform
{
    public partial class frmDBConfig : Form
    {
        private string _config;
        private DataBaseClass _dataBaseClass = DataBaseClass.SqlServer;
        private string _host;//主机名
        private string _port;//端口号
        private string _dbName;//数据库名
        private string _userName;//用户名
        private string _password;//密码 
        private string _type;//类型

        public frmDBConfig(string type)
        {
            InitializeComponent();

            _type = type;
            _config = ConfigHelper.GetAppConfig($"{_type}ConnectionString");
            _dataBaseClass = (DataBaseClass)Convert.ToInt32(ConfigHelper.GetAppConfig($"{_type}DataBaseType"));
            SplitDBConfigString();
            dbConnect._userName = _userName;
            dbConnect._password = _password;
            dbConnect._port = _port;
            dbConnect._dbName = _dbName;
            dbConnect._host = _host;
        }

        private void frmDBConfig_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();

            foreach (DataBaseClass suit in Enum.GetValues(typeof(DataBaseClass)))
            {
                dict.Add((int)suit, suit.ToString());
            }

            BindingSource bs = new BindingSource();
            bs.DataSource = dict;
            cbb_dataBaseClass.DataSource = bs;
            cbb_dataBaseClass.ValueMember = "Key";
            cbb_dataBaseClass.DisplayMember = "Value";

            cbb_dataBaseClass.SelectedIndex = (int)_dataBaseClass;
        }

        private void tsb_quit_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Clear();
        }

        private void tsb_save_Click(object sender, EventArgs e)
        {
            ConfigHelper.UpdateAppConfig($"{_type}DataBaseType", cbb_dataBaseClass.SelectedIndex.ToString());

            ConfigHelper.UpdateAppConfig($"{_type}ConnectionString", GetDBConfigString());

            MessageBoxHelper.Warning("保存成功！");
        }

        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <returns></returns>
        private string GetDBConfigString()
        {
            switch (_dataBaseClass)
            {
                case DataBaseClass.SqlServer:
                    _config = $"data source={_host};initial catalog={_dbName};user id={_userName};password={_password};";
                    break;
                case DataBaseClass.Oracle:
                    _config = $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={_host})(PORT={_port}))(CONNECT_DATA=(SERVICE_NAME={_dbName})));Persist Security Info=True;user id={_userName};password={_password};";
                    break;
                case DataBaseClass.Mysql:
                    break;
                case DataBaseClass.MongoDB:
                    break;
                case DataBaseClass.DB2:
                    break;
                default:
                    break;
            }

            return _config;
        }

        /// <summary>
        /// 拆分数据库连接字符串
        /// </summary>
        private void SplitDBConfigString()
        {
            if (string.IsNullOrEmpty(_config))
            {
                return;
            }

            _userName = GetSectionValue("user id");
            _password = GetSectionValue("password");

            switch (_dataBaseClass)
            {
                case DataBaseClass.SqlServer:
                    _host = GetSectionValue("data source");
                    _dbName = GetSectionValue("initial catalog");
                    break;
                case DataBaseClass.Oracle:
                    _host = GetSectionValue("HOST", ")");
                    _dbName = GetSectionValue("SERVICE_NAME", ")");
                    _port = GetSectionValue("PORT", ")");
                    break;
                case DataBaseClass.Mysql:
                    break;
                case DataBaseClass.MongoDB:
                    break;
                case DataBaseClass.DB2:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 根据键值获取节点值
        /// </summary>
        /// <param name="sectionName"></param>
        /// <returns></returns>
        public string GetSectionValue(string sectionName, string splitString = ";")
        {
            return Regex.Match(_config, $@"{sectionName}=([^{splitString}]+)").Groups[1].Value;
        }
    }
}
