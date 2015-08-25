using System;
using System.Globalization;
using System.Web;

namespace ZhuJi.Library.Globalization
{
    /// <summary>
    /// 常用变量常量值。
    /// </summary>
    public sealed class GlobalHelper
    {
        private GlobalHelper()
        {
        }

        /// <summary>
        /// 获取IP地址
        /// </summary>
        public static string IP
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    return HttpContext.Current.Request.UserHostAddress;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// 获取当前时间
        /// </summary>
        public static DateTime Time
        {
            get { return DateTime.Now; }
        }

        /// <summary>
        /// 获取当前用户
        /// </summary>
        public static string User
        {
            get
            {
                if (HttpContext.Current != null)
                {
					return HttpContext.Current.User.Identity.Name;
					//return "admin";
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// 获取当前角色Id
        /// </summary>
        public static string RolesId
        {
            get
            {
                if (HttpContext.Current != null)
                {
					if (HttpContext.Current.Request.Cookies["UsersInfo"] != null)
					{
						if (HttpContext.Current.Request.Cookies["UsersInfo"]["RolesId"] != null)
						{
							return HttpContext.Current.Request.Cookies["UsersInfo"]["RolesId"];
						}
					}
					//return "1";
                }
                return "0";
            }
        }

        /// <summary>
        /// 获取随机代码
        /// </summary>
        public static string RndCode
        {
            get
            {
                Random rnd = new Random();
                string rndCode =
                    string.Concat(DateTime.Now.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture),
                                  rnd.Next(1, 1000).ToString(CultureInfo.InvariantCulture));
                return rndCode;
            }
        }
    }
}