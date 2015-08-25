using System;
using System.Configuration;
using System.Globalization;

namespace ZhuJi.Library.Globalization
{
    /// <summary>
    /// �����ļ����������
    /// </summary>
    public sealed class ConfigHelper
    {
        private ConfigHelper()
        {
        }        

        #region �ļ��ϴ�

        /// <summary>
        /// �ϴ���С����,Ĭ��500K
        /// </summary>
        public static int FileSize
        {
            get
            {
                int defaultSize = 500*1024;
                string fileSize = GetAppSettings("ZhuJi.Library.Web.Upload.FileSize");
                return
                    string.IsNullOrEmpty(fileSize)
                        ? defaultSize
                        : Convert.ToInt32(fileSize, CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// �ϴ��ļ�Ŀ¼
        /// </summary>
        public static string FilePath
        {
            get
            {
                string defaultPath = @"~/UploadFiles/";
                string filePath = GetAppSettings("ZhuJi.Library.Web.Upload.FilePath");
                return string.IsNullOrEmpty(filePath) ? defaultPath : filePath;
            }
        }

        #endregion        

        #region ORM

        /// <summary>
        /// ORM�����ļ�·��
        /// </summary>
        public static string OrmConfigure
        {
            get
            {
                string defaultPath = @"c:\orm";
                string configure = GetAppSettings("ZhuJi.ORM.Configure");
                return string.IsNullOrEmpty(configure) ? defaultPath : configure;
            }
        }

        #endregion

        /// <summary>
        /// ��ȡ����AppSettings
        /// </summary>
        /// <param name="key">�ؼ���</param>
        /// <returns></returns>
        public static string GetAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}