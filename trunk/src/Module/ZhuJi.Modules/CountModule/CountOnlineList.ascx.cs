﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace ZhuJi.Modules.CountModule.WebUI
{
    public partial class CountOnlineList : ZhuJi.Portal.WebUI.BaseWebControl
    {
		private int _onlineTime = 15;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List();
            }
        }

		private DateTime _beginTime = DateTime.Parse(string.Format("{0}-1-1", DateTime.Now.Year));
		/// <summary>
		/// 开始日期
		/// </summary>
		public DateTime BeginTime
		{
			set { _beginTime = value; }
			get { return _beginTime; }
		}

		private DateTime _endTime = DateTime.Today.AddDays(1);
		/// <summary>
		/// 结束日期
		/// </summary>
		public DateTime EndTime
		{
			set { _endTime = value; }
			get { return _endTime; }
		}

        /// <summary>
        /// 初始化查询列表
        /// </summary>
        public void List()
        {
            try
            {
				ZhuJi.Modules.CountModule.IDAL.ICountOnline countOnline = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.CountModule.SQLServerDAL.CountOnline)) as ZhuJi.Modules.CountModule.IDAL.ICountOnline;
				rptList.DataSource = countOnline.GetObjects(_onlineTime, _beginTime, _endTime);
                rptList.DataBind();
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }
        }
    }
}

