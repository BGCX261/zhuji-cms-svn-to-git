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
using ZhuJi.Library.Globalization;

namespace ZhuJi.UUMS.WebUI
{
    public partial class UsersEdit : ZhuJi.Portal.WebUI.BaseWebControl
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


            CreatedByIp.Text = GlobalHelper.IP;
            CreatedByUser.Text = GlobalHelper.User;
            CreatedByDate.Text = GlobalHelper.Time.ToString();
            try
            {
                ZhuJi.UUMS.IDAL.IRoles roles = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Roles)) as ZhuJi.UUMS.IDAL.IRoles;
                IList<ZhuJi.UUMS.Domain.Roles> listRoles = roles.GetObjects();
                foreach (ZhuJi.UUMS.Domain.Roles domainRoles in listRoles)
                {
                    RolesId.Items.Add(new ListItem(domainRoles.RoleName.ToString(), domainRoles.Id.ToString()));
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
                ZhuJi.UUMS.IDAL.IUsers users = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Users)) as ZhuJi.UUMS.IDAL.IUsers;
                ZhuJi.UUMS.Domain.Users domainUsers = users.GetObject(_identity);
                UIMapping.BindObjectToControls(domainUsers, this);

                Password.Enabled = false;
                cbPassword.Visible = true;
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
                    ZhuJi.UUMS.Domain.Users domainUsers = new ZhuJi.UUMS.Domain.Users();
                    domainUsers.CheckPassword = true;
                    UIMapping.BindControlsToObject(domainUsers, this);

                    ZhuJi.UUMS.IDAL.IUsers users = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Users)) as ZhuJi.UUMS.IDAL.IUsers;
                    users.Insert(domainUsers);

					_identity = domainUsers.Id;
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
                    ZhuJi.UUMS.Domain.Users domainUsers = new ZhuJi.UUMS.Domain.Users();
                    domainUsers.CheckPassword = Password.Enabled;
                    UIMapping.BindControlsToObject(domainUsers, this);

                    ZhuJi.UUMS.IDAL.IUsers users = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Users)) as ZhuJi.UUMS.IDAL.IUsers;
                    users.Update(domainUsers);
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
                ZhuJi.UUMS.Domain.Users domainUsers = new ZhuJi.UUMS.Domain.Users();

                domainUsers.Id = int.Parse(Id.Text);

                ZhuJi.UUMS.IDAL.IUsers users = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.UUMS.NHibernateDAL.Users)) as ZhuJi.UUMS.IDAL.IUsers;
                users.Delete(domainUsers);
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }
            Response.Redirect(Request.Url.ToString(), true);
        }

        protected void cbPassword_CheckedChanged(object sender, EventArgs e)
        {
            Password.Enabled = cbPassword.Checked;
        }
    }
}

