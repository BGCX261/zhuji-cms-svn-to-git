using System;
using System.Globalization;
using System.Web;

namespace ZhuJi.Library.Globalization
{
    /// <summary>
    /// ���ñ�������ֵ��
    /// </summary>
    public sealed class GlobalHelper
    {
        private GlobalHelper()
        {
        }

        /// <summary>
        /// ��ȡIP��ַ
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
        /// ��ȡ��ǰʱ��
        /// </summary>
        public static DateTime Time
        {
            get { return DateTime.Now; }
        }

        /// <summary>
        /// ��ȡ��ǰ�û�
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
        /// ��ȡ��ǰ��ɫId
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
        /// ��ȡ�������
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