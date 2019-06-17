using System;
using System.IO;
using System.Threading;

namespace IOHelper
{
    public class WriteHelper
    {
        public string _path = "C:\\Oracle";
        public string _file;

        static ReaderWriterLockSlim LogWriteLock = new ReaderWriterLockSlim();

        public WriteHelper(string path, string file)
        {
            _file = file;
            _path = path;
        }

        public WriteHelper(string fileName)
        {
            _file = fileName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg">消息记录</param>
        /// <param name="isCover">是否覆盖</param>
        public void Write(string msg, bool isCover = true)
        {
            try
            {
                LogWriteLock.EnterWriteLock();

                if (!Directory.Exists(_path + "\\"))
                {
                    Directory.CreateDirectory(_path + "\\");
                }

                if (isCover)
                {
                    File.Create(_path + "\\" + _file).Close();
                }
                else
                {
                    if (!File.Exists(_path + "\\" + _file))
                    {
                        File.Create(_path + "\\" + _file).Close();
                    }
                }

                FileStream fs = new FileStream(_path + "\\" + _file, FileMode.Append, FileAccess.Write);
                //获得字节数组
                byte[] data = System.Text.Encoding.Default.GetBytes(msg);
                //设置当前流的位置(如果不设置下面的Position属性，执行Write方法的时候是从前往后覆盖)。
                fs.Position = fs.Length;
                //开始写入
                fs.Write(data, 0, data.Length);
                //清空缓冲区、关闭流
                fs.Flush();
                fs.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                LogWriteLock.ExitWriteLock();
            }
        }
    }
}
