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

namespace ZhuJi.UUMS.WebUI
{
    public partial class ControlsEdit : ZhuJi.Portal.WebUI.BaseWebControl
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
                ZhuJi.UUMS.IDAL.IResources resources = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Resources)) as ZhuJi.UUMS.IDAL.IResources;
                IList<ZhuJi.UUMS.Domain.Resources> listResources = resources.GetObjects();
                foreach (ZhuJi.UUMS.Domain.Resources domainResources in listResources)
                {
                    ResourcesId.Items.Add(new ListItem(domainResources.ResourceName.ToString(), domainResources.Id.ToString()));
                }

                ZhuJi.UUMS.IDAL.IControlsType controlsType = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.ControlsType)) as ZhuJi.UUMS.IDAL.IControlsType;
                IList<ZhuJi.UUMS.Domain.ControlsType> listControlsType = controlsType.GetObjects();
                foreach (ZhuJi.UUMS.Domain.ControlsType domainControlsType in listControlsType)
                {
                    ControlType.Items.Add(new ListItem(domainControlsType.Text.ToString(), domainControlsType.Id.ToString()));
                }

                ZhuJi.UUMS.IDAL.IControlsAttribute controlsAttribute = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.ControlsAttribute)) as ZhuJi.UUMS.IDAL.IControlsAttribute;
                IList<ZhuJi.UUMS.Domain.ControlsAttribute> listControlsAttribute = controlsAttribute.GetObjects();
                foreach (ZhuJi.UUMS.Domain.ControlsAttribute domainControlsAttribute in listControlsAttribute)
                {
                    Attribute.Items.Add(new ListItem(domainControlsAttribute.Text.ToString(), domainControlsAttribute.Id.ToString()));
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
                ZhuJi.UUMS.IDAL.IControls controls = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Controls)) as ZhuJi.UUMS.IDAL.IControls;
                ZhuJi.UUMS.Domain.Controls domainControls = controls.GetObject(_identity);
                UIMapping.BindObjectToControls(domainControls, this);
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
                    ZhuJi.UUMS.Domain.Controls domainControls = new ZhuJi.UUMS.Domain.Controls();
                    UIMapping.BindControlsToObject(domainControls, this);

                    ZhuJi.UUMS.IDAL.IControls controls = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Controls)) as ZhuJi.UUMS.IDAL.IControls;
                    controls.Insert(domainControls);

					_identity = domainControls.Id;
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
                    ZhuJi.UUMS.Domain.Controls domainControls = new ZhuJi.UUMS.Domain.Controls();
                    UIMapping.BindControlsToObject(domainControls, this);

                    ZhuJi.UUMS.IDAL.IControls controls = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Controls)) as ZhuJi.UUMS.IDAL.IControls;
                    controls.Update(domainControls);
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
                ZhuJi.UUMS.Domain.Controls domainControls = new ZhuJi.UUMS.Domain.Controls();

                domainControls.Id = int.Parse(Id.Text);

                ZhuJi.UUMS.IDAL.IControls controls = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Controls)) as ZhuJi.UUMS.IDAL.IControls;
                controls.Delete(domainControls);
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }
            Response.Redirect(Request.Url.ToString(), true);
        }
    }
}

