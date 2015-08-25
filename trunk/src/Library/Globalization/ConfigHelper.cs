using System;
using System.Configuration;
using System.Globalization;

namespace ZhuJi.Library.Globalization
{
    /// <summary>
    /// 配置文件处理帮助类
    /// </summary>
    public sealed class ConfigHelper
    {
        private ConfigHelper()
        {
        }        

        #region 文件上传

        /// <summary>
        /// 上传大小限制,默认500K
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
        /// 上传文件目录
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
        /// ORM配置文件路径
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
        /// 获取配置AppSettings
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns></returns>
        public static string GetAppSettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}