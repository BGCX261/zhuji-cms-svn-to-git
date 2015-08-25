using System.Web.UI;
using System;
using System.Reflection;
using ZhuJi.Library.Globalization;
using System.Text;

namespace ZhuJi.Portal.WebUI
{
    /// <summary>
    /// WebControl����
    /// </summary>
    public class BaseWebControl : UserControl
    {
        /// <summary>
        ///	����Onload����
        /// </summary>
        /// <param name="e">�¼�����</param>
        protected override void OnLoad(EventArgs e)
        {
            CheckControlResource();
            base.OnLoad(e);
        }

        /// <summary>
        /// ��дRender����
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
		/// ת�����ַ�Ϊ��δ֪��
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
				rets = "δ֪";
			}
			return rets;
		}

        #region ��־����Ϣ
        /// <summary>
        /// ��ʾ��Ϣ��ʾ�Ի��򣬲�����ҳ�����
        /// </summary>
        /// <param name="ex">������Ϣ</param>
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

        #region Ȩ��
        /// <summary>
        /// �����Դ�Ƿ���Ȩ��
        /// </summary>
        public void CheckControlResource()
        {
            ZhuJi.UUMS.IDAL.IPermissionByResource pbr = new ZhuJi.UUMS.NHibernateDAL.PermissionByResource();
            pbr.CheckControlResource(this, GlobalHelper.RolesId);
        }        
        #endregion

        #region �б�
        private bool isShowPager;
        /// <summary>
        /// �Ƿ���ʾ��ҳ
        /// </summary>
        public bool IsShowPager
        {
            set { isShowPager = value; }
            get { return isShowPager; }
        }

        private int _pageNo = 1;
        /// <summary>
        /// ��ǰҳ��
        /// </summary>
        public int PageNo
        {
            set { _pageNo = value; }
            get { return _pageNo; }
        }

        private int _pageSize = 12;
        /// <summary>
        /// ҳ��
        /// </summary>
        public int PageSize
        {
            set { _pageSize = value; }
            get { return _pageSize; }
        }

        private string _where;
        /// <summary>
        /// ��ѯ����
        /// </summary>
        public string Where
        {
            set { _where = value; }
            get { return _where; }
        }

        private string _orderNo;
        /// <summary>
        /// ����
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
        /// �Ƿ����Xml
        /// </summary>
        public bool IsOutXml
        {
            set { _isOutXml = value; }
            get { return _isOutXml; }
        }

        private string _outXml;
        /// <summary>
        /// Xml����
        /// </summary>
        public string OutXml
        {
            set { _outXml = value; }
            get { return _outXml; }
        }
        #endregion
    }
}