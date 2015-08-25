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
    public partial class MethodsEdit : ZhuJi.Portal.WebUI.BaseWebControl
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
                ZhuJi.UUMS.IDAL.IMethodExplain methodExplain = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.MethodExplain)) as ZhuJi.UUMS.IDAL.IMethodExplain;
                IList<ZhuJi.UUMS.Domain.MethodExplain> listMethodExplain = methodExplain.GetObjects();
                foreach (ZhuJi.UUMS.Domain.MethodExplain domainMethodExplain in listMethodExplain)
                {
                    ExplainId.Items.Add(new ListItem(domainMethodExplain.Title.ToString(), domainMethodExplain.Id.ToString()));
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
                ZhuJi.UUMS.IDAL.IMethods methods = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Methods)) as ZhuJi.UUMS.IDAL.IMethods;
                ZhuJi.UUMS.Domain.Methods domainMethods = methods.GetObject(_identity);
                UIMapping.BindObjectToControls(domainMethods, this);
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
                    ZhuJi.UUMS.Domain.Methods domainMethods = new ZhuJi.UUMS.Domain.Methods();
                    UIMapping.BindControlsToObject(domainMethods, this);

                    ZhuJi.UUMS.IDAL.IMethods methods = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Methods)) as ZhuJi.UUMS.IDAL.IMethods;
                    methods.Insert(domainMethods);

					_identity = domainMethods.Id;
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
                    ZhuJi.UUMS.Domain.Methods domainMethods = new ZhuJi.UUMS.Domain.Methods();
                    UIMapping.BindControlsToObject(domainMethods, this);

                    ZhuJi.UUMS.IDAL.IMethods methods = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Methods)) as ZhuJi.UUMS.IDAL.IMethods;
                    methods.Update(domainMethods);
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
                ZhuJi.UUMS.Domain.Methods domainMethods = new ZhuJi.UUMS.Domain.Methods();

                domainMethods.Id = int.Parse(Id.Text);

                ZhuJi.UUMS.IDAL.IMethods methods = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Methods)) as ZhuJi.UUMS.IDAL.IMethods;
                methods.Delete(domainMethods);
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }
            Response.Redirect(Request.Url.ToString(), true);
        }
    }
}

