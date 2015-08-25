using System.Web.UI;
using System;
using System.Reflection;
using ZhuJi.Library.Globalization;
using System.Text;

namespace ZhuJi.Portal.WebUI
{
    /// <summary>
    /// WebControl基类
    /// </summary>
    public class BaseWebControl : UserControl
    {
        /// <summary>
        ///	重载Onload方法
        /// </summary>
        /// <param name="e">事件参数</param>
        protected override void OnLoad(EventArgs e)
        {
            CheckControlResource();
            base.OnLoad(e);
        }

        /// <summary>
        /// 重写Render方法
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (IsOutXml)
            {
                writer.Write("<{0}>{1}</{0}>", base.ID, _outXml);
            }
            else
            {
                base.Render(writer);
            }
        }

		/// <summary>
		/// 转换空字符为“未知”
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public string EvalEmpty(object input)
		{
			string rets = string.Empty;
			if (input != DBNull.Value)
			{
				rets = (string)input;
			}
			if (rets.Trim().Length == 0)
			{
				rets = "未知";
			}
			return rets;
		}

        #region 日志及消息
        /// <summary>
        /// 显示消息提示对话框，并进行页面后退
        /// </summary>
        /// <param name="ex">错误信息</param>
        public void ShowMessage(Exception ex)
        {
            ZhuJi.Log.IDAL.ILogging logging = new ZhuJi.Log.NHibernateDAL.Logging();
            logging.WriteException(ex);

            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language=\"javascript\" defer>");
            Builder.AppendFormat("alert(\"{0}\");", ex.Message.Replace("\r", "").Replace("\n", "\\r\\n"));
            Builder.Append("history.go(-1);");
            Builder.Append("</script>");
            ClientScriptManager cs = this.Page.ClientScript;
            cs.RegisterStartupScript(this.Page.GetType(), "message", Builder.ToString());
        }
        #endregion

        #region 权限
        /// <summary>
        /// 检查资源是否有权限
        /// </summary>
        public void CheckControlResource()
        {
            ZhuJi.UUMS.IDAL.IPermissionByResource pbr = new ZhuJi.UUMS.NHibernateDAL.PermissionByResource();
            pbr.CheckControlResource(this, GlobalHelper.RolesId);
        }        
        #endregion

        #region 列表
        private bool isShowPager;
        /// <summary>
        /// 是否显示分页
        /// </summary>
        public bool IsShowPager
        {
            set { isShowPager = value; }
            get { return isShowPager; }
        }

        private int _pageNo = 1;
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageNo
        {
            set { _pageNo = value; }
            get { return _pageNo; }
        }

        private int _pageSize = 12;
        /// <summary>
        /// 页长
        /// </summary>
        public int PageSize
        {
            set { _pageSize = value; }
            get { return _pageSize; }
        }

        private string _where;
        /// <summary>
        /// 查询条件
        /// </summary>
        public string Where
        {
            set { _where = value; }
            get { return _where; }
        }

        private string _orderNo;
        /// <summary>
        /// 排序
        /// </summary>
        public string OrderNo
        {
            set { _orderNo = value; }
            get { return _orderNo; }
        }
        #endregion

        #region XML
        private bool _isOutXml;
        /// <summary>
        /// 是否输出Xml
        /// </summary>
        public bool IsOutXml
        {
            set { _isOutXml = value; }
            get { return _isOutXml; }
        }

        private string _outXml;
        /// <summary>
        /// Xml内容
        /// </summary>
        public string OutXml
        {
            set { _outXml = value; }
            get { return _outXml; }
        }
        #endregion
    }
}