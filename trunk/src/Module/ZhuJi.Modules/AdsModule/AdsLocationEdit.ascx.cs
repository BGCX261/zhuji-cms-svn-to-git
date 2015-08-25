using System;
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
using System.Collections.Generic;

namespace ZhuJi.Modules.AdsModule.WebUI
{
    public partial class AdsLocationEdit : ZhuJi.Portal.WebUI.BaseWebControl
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

			try
			{
				ZhuJi.Modules.AdsModule.IDAL.IAdsLocationType adsLocationType = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.AdsModule.NHibernateDAL.AdsLocationType)) as ZhuJi.Modules.AdsModule.IDAL.IAdsLocationType;
				IList<ZhuJi.Modules.AdsModule.Domain.AdsLocationType> listAdsLocationType = adsLocationType.GetObjects(string.Empty,"tmp.OrderBy");
				foreach (ZhuJi.Modules.AdsModule.Domain.AdsLocationType domainAdsLocationType in listAdsLocationType)
				{
					Type.Items.Add(new ListItem(domainAdsLocationType.Text.ToString(), domainAdsLocationType.Id.ToString()));
				}
			}
			catch (Exception ex)
			{
				ShowMessage(ex);
			}

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
                ZhuJi.Modules.AdsModule.IDAL.IAdsLocation adsLocation = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.AdsModule.NHibernateDAL.AdsLocation)) as ZhuJi.Modules.AdsModule.IDAL.IAdsLocation;
                ZhuJi.Modules.AdsModule.Domain.AdsLocation domainAdsLocation = adsLocation.GetObject(_identity);
                UIMapping.BindObjectToControls(domainAdsLocation, this);
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
                    ZhuJi.Modules.AdsModule.Domain.AdsLocation domainAdsLocation = new ZhuJi.Modules.AdsModule.Domain.AdsLocation();
                    UIMapping.BindControlsToObject(domainAdsLocation, this);

                    ZhuJi.Modules.AdsModule.IDAL.IAdsLocation adsLocation = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.AdsModule.NHibernateDAL.AdsLocation)) as ZhuJi.Modules.AdsModule.IDAL.IAdsLocation;
                    adsLocation.Insert(domainAdsLocation);

					_identity = domainAdsLocation.Id;
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
                    ZhuJi.Modules.AdsModule.Domain.AdsLocation domainAdsLocation = new ZhuJi.Modules.AdsModule.Domain.AdsLocation();
                    UIMapping.BindControlsToObject(domainAdsLocation, this);

                    ZhuJi.Modules.AdsModule.IDAL.IAdsLocation adsLocation = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.AdsModule.NHibernateDAL.AdsLocation)) as ZhuJi.Modules.AdsModule.IDAL.IAdsLocation;
                    adsLocation.Update(domainAdsLocation);
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
                ZhuJi.Modules.AdsModule.Domain.AdsLocation domainAdsLocation = new ZhuJi.Modules.AdsModule.Domain.AdsLocation();

                domainAdsLocation.Id = int.Parse(Id.Text);

                ZhuJi.Modules.AdsModule.IDAL.IAdsLocation adsLocation = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.AdsModule.NHibernateDAL.AdsLocation)) as ZhuJi.Modules.AdsModule.IDAL.IAdsLocation;
                adsLocation.Delete(domainAdsLocation);
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }
            Response.Redirect(Request.Url.ToString(), true);
        }
    }
}

