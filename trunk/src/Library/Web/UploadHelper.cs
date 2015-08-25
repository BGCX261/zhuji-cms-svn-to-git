using System;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using ZhuJi.Library.Globalization;

namespace ZhuJi.Library.Web
{
    /// <summary>
    /// 上传帮助类
    /// </summary>
    public class UploadHelper
    {
        private string _filePath = ConfigHelper.FilePath;
        private int _fileSize = ConfigHelper.FileSize;

        private string _message = string.Empty;

        /// <summary>
        /// 反馈消息
        /// </summary>
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="fileUpload">上传控件</param>
        /// <param name="upPath">上传目录</param>
        public void SaveAs(FileUpload fileUpload, out string upPath)
        {
            if (fileUpload == null)
            {
                throw new ArgumentNullException("fileUpload");
            }

            upPath = string.Empty;

            try
            {
                int size = fileUpload.PostedFile.ContentLength;

                //判断文件大小
                if (size > _fileSize)
                {
                    _message = "文件太大，不能上传！";
                }
                else
                {
                    upPath = _filePath + DateTime.Now.ToShortDateString();
                    //判断目录是否存在，不存在创建目录
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(upPath)))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(upPath));
                    }
                    string filename = string.Concat(upPath, @"/", fileUpload.FileName);

                    upPath = filename;

                    //上传文件
                    fileUpload.SaveAs(HttpContext.Current.Server.MapPath(filename));
                }
            }
            catch (Exception ex)
            {
                _message = "文件上传失败:" + ex.Message;
                throw;
            }
        }
    }
}