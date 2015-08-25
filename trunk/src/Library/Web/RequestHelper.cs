using System;
using System.Globalization;
using System.Web;

namespace ZhuJi.Library.Web
{
    /// <summary>
    /// 构建安全的Request
    /// </summary>
    public sealed class RequestHelper
    {
        private RequestHelper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static string Param(string paramName)
        {
            string result = String.Empty;

            if (HttpContext.Current.Request.Form.Count != 0)
            {
                result = Convert.ToString(HttpContext.Current.Request.Form[paramName], CultureInfo.InvariantCulture);
            }
            else if (HttpContext.Current.Request.QueryString.Count != 0)
            {
                result =
                    Convert.ToString(HttpContext.Current.Request.QueryString[paramName], CultureInfo.InvariantCulture);
            }

            return (result == null) ? String.Empty : result.Trim();
        }
    }
}