using System;
using System.Web;
using System.Web.Security;

namespace ZhuJi.Library.Web
{
    /// <summary>
    /// 登录帮助类
    /// </summary>
    public sealed class LogonHelper
    {
        private LogonHelper()
        {
        }

        /// <summary>
        /// 登录系统
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="rolesId">角色Id</param>
        public static void Login(string userName, string rolesId)
        {
            FormsAuthentication.RedirectFromLoginPage(userName, true);

            HttpCookie usersInfo = new HttpCookie("UsersInfo");
            usersInfo["User"] = userName;
            usersInfo["RolesId"] = rolesId;
            usersInfo.Expires = DateTime.Now.AddDays(1d);
            HttpContext.Current.Response.Cookies.Add(usersInfo);
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        public static void Logout()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();

            if (HttpContext.Current.Request.Cookies["UsersInfo"] != null)
            {
                HttpCookie usersInfo = new HttpCookie("UsersInfo");
                usersInfo.Expires = DateTime.Now.AddDays(-1d);
                HttpContext.Current.Response.Cookies.Add(usersInfo);
            }
        }
    }
}