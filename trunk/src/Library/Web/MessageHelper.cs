using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZhuJi.Library.Web
{
    /// <summary>
    /// 信息处理帮助类
    /// </summary>
    public sealed class MessageHelper
    {
        private MessageHelper()
        {
        }

        /// <summary>
        /// 获取提示信息
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string GetMessage(string key)
        {
            string ret = string.Empty;
            switch (key)
            {
                case "INSERT":
                    ret = "您已经成功新增了这条信息！";
                    break;
                case "UPDATE":
                    ret = "您已经成功更新了这条信息！";
                    break;
                case "DELETE":
                    ret = "您已经成功删除了这条信息！";
                    break;
                case "NOCHECK":
                    ret = "未选择ID！";
                    break;
                case "MORECHECK":
                    ret = "不要选择多个ID！";
                    break;
                case "NotLogin":
                    ret = "登录失败！";
                    break;
            }
            return ret;
        }

        /// <summary>
        /// 显示消息提示对话框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void Show(Page page, string msg)
        {
            if (page != null)
            {
                ClientScriptManager cs = page.ClientScript;
                cs.RegisterClientScriptBlock(page.GetType(), "message",
                                             "<script language='javascript' defer>alert('" + msg + "');</script>");
            }
        }

        /// <summary>
        /// 控件点击 消息确认提示框
        /// </summary>
        /// <param name="control">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowConfirm(WebControl control, string msg)
        {
            if (control != null)
            {
                control.Attributes.Add("onclick", "return confirm('" + msg + "');");
            }
        }

        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void ShowAndRedirect(Page page, string msg, string url)
        {
            if (page != null)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("<script language='javascript' defer>");
                builder.AppendFormat("alert('{0}');", msg);
                builder.AppendFormat("location.href='{0}'", url);
                builder.Append("</script>");
                ClientScriptManager cs = page.ClientScript;
                cs.RegisterStartupScript(page.GetType(), "message", builder.ToString());
            }
        }

        /// <summary>
        /// 显示消息提示对话框，并进行页面后退
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowAndBack(Page page, string msg)
        {
            if (page != null)
            {
                StringBuilder Builder = new StringBuilder();
                Builder.Append("<script language='javascript' defer>");
                Builder.AppendFormat("alert('{0}');", msg);
                Builder.Append("history.go(-1);");
                Builder.Append("</script>");
                ClientScriptManager cs = page.ClientScript;
                cs.RegisterStartupScript(page.GetType(), "message", Builder.ToString());
            }
        }

        /// <summary>
        /// 输出自定义脚本信息
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="script">输出脚本</param>
        public static void ResponseScript(Page page, string script)
        {
            if (page != null)
            {
                ClientScriptManager cs = page.ClientScript;
                cs.RegisterStartupScript(page.GetType(), "message",
                                         "<script language='javascript' defer>" + script + "</script>");
            }
        }
    }
}