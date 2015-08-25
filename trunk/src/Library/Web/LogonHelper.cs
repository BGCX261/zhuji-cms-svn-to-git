using System;
using System.Web;
using System.Web.Security;

namespace ZhuJi.Library.Web
{
    /// <summary>
    /// ��¼������
    /// </summary>
    public sealed class LogonHelper
    {
        private LogonHelper()
        {
        }

        /// <summary>
        /// ��¼ϵͳ
        /// </summary>
        /// <param name="userName">�û���</param>
        /// <param name="rolesId">��ɫId</param>
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
        /// �˳�ϵͳ
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