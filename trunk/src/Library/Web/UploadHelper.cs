using System;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using ZhuJi.Library.Globalization;

namespace ZhuJi.Library.Web
{
    /// <summary>
    /// �ϴ�������
    /// </summary>
    public class UploadHelper
    {
        private string _filePath = ConfigHelper.FilePath;
        private int _fileSize = ConfigHelper.FileSize;

        private string _message = string.Empty;

        /// <summary>
        /// ������Ϣ
        /// </summary>
        public string Message
        {
            set { _message = value; }
            get { return _message; }
        }

        /// <summary>
        /// �ϴ��ļ�
        /// </summary>
        /// <param name="fileUpload">�ϴ��ؼ�</param>
        /// <param name="upPath">�ϴ�Ŀ¼</param>
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

                //�ж��ļ���С
                if (size > _fileSize)
                {
                    _message = "�ļ�̫�󣬲����ϴ���";
                }
                else
                {
                    upPath = _filePath + DateTime.Now.ToShortDateString();
                    //�ж�Ŀ¼�Ƿ���ڣ������ڴ���Ŀ¼
                    if (!Directory.Exists(HttpContext.Current.Server.MapPath(upPath)))
                    {
                        Directory.CreateDirectory(HttpContext.Current.Server.MapPath(upPath));
                    }
                    string filename = string.Concat(upPath, @"/", fileUpload.FileName);

                    upPath = filename;

                    //�ϴ��ļ�
                    fileUpload.SaveAs(HttpContext.Current.Server.MapPath(filename));
                }
            }
            catch (Exception ex)
            {
                _message = "�ļ��ϴ�ʧ��:" + ex.Message;
                throw;
            }
        }
    }
}