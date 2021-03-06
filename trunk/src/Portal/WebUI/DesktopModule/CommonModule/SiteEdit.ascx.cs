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
using ZhuJi.Library.Web;

namespace ZhuJi.Portal.WebUI.DesktopModule.CommonModule
{
    public partial class SiteEdit : ZhuJi.Portal.WebUI.BaseWebControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化添加/编辑表单
        /// </summary>
        public void Initialize()
        {
            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDel.Visible = false;

            switch (_command)
            {
                case "ADD":
                    Add();
                    break;
                case "EDIT":
                    Edit();
                    break;
            }
        }

        private int _identity;
        /// <summary>
        /// 编号
        /// </summary>
        public int Identity
        {
            set { _identity = value; }
            get { return _identity; }
        }

        private string _command;
        /// <summary>
        /// 添加/编辑键
        /// </summary>
        public string Command
        {
            set { _command = value; }
            get { return _command; }
        }

        /// <summary>
        /// 初始化添加表单
        /// </summary>
        private void Add()
        {
            btnAdd.Visible = true;
        }

        /// <summary>
        /// 初始化编辑表单
        /// </summary>
        private void Edit()
        {
			btnAdd.Visible = true;
			btnAdd.Text = "另存为新记录";
            btnEdit.Visible = true;
            btnDel.Visible = true;

            try
            {
               ZhuJi.Portal.IDAL.ISite site = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.Site)) as ZhuJi.Portal.IDAL.ISite;
                ZhuJi.Portal.Domain.Site domainSite = site.GetObject(_identity);
                UIMapping.BindObjectToControls(domainSite, this);
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }
        }

        /// <summary>
        /// 点击添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    ZhuJi.Portal.Domain.Site domainSite = new ZhuJi.Portal.Domain.Site();
                    UIMapping.BindControlsToObject(domainSite, this);

                   ZhuJi.Portal.IDAL.ISite site = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.Site)) as ZhuJi.Portal.IDAL.ISite;
                    site.Insert(domainSite);

					_identity = domainSite.Id;
					Edit();
                }
                catch (Exception ex)
                {
                    ShowMessage(ex);
                }
            }
        }

        /// <summary>
        /// 点击编辑按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    ZhuJi.Portal.Domain.Site domainSite = new ZhuJi.Portal.Domain.Site();
                    UIMapping.BindControlsToObject(domainSite, this);

                   ZhuJi.Portal.IDAL.ISite site = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.Site)) as ZhuJi.Portal.IDAL.ISite;
                    site.Update(domainSite);
                }
                catch (Exception ex)
                {
                    ShowMessage(ex);
                }
            }
        }

        /// <summary>
        /// 点击删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                ZhuJi.Portal.Domain.Site domainSite = new ZhuJi.Portal.Domain.Site();

                domainSite.Id = int.Parse(Id.Text);

               ZhuJi.Portal.IDAL.ISite site = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.Site)) as ZhuJi.Portal.IDAL.ISite;
                site.Delete(domainSite);
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }
            Response.Redirect(Request.Url.ToString(), true);
        }
    }
}

