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
using System.Collections.Generic;
using ZhuJi.Library.Web;

namespace ZhuJi.Modules.VoteModule.WebUI
{
    public partial class VoteSubjectEdit : ZhuJi.Portal.WebUI.BaseWebControl
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
				ZhuJi.Modules.VoteModule.IDAL.IVoteSubjectType voteSubjectType = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.VoteModule.NHibernateDAL.VoteSubjectType)) as ZhuJi.Modules.VoteModule.IDAL.IVoteSubjectType;
				IList<ZhuJi.Modules.VoteModule.Domain.VoteSubjectType> listVoteSubjectType = voteSubjectType.GetObjects(string.Empty,"tmp.OrderBy Asc");
				foreach (ZhuJi.Modules.VoteModule.Domain.VoteSubjectType domainVoteSubjectType in listVoteSubjectType)
				{
					VoteType.Items.Add(new ListItem(domainVoteSubjectType.Text.ToString(), domainVoteSubjectType.Id.ToString()));
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
                ZhuJi.Modules.VoteModule.IDAL.IVoteSubject voteSubject = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.VoteModule.NHibernateDAL.VoteSubject)) as ZhuJi.Modules.VoteModule.IDAL.IVoteSubject;
                ZhuJi.Modules.VoteModule.Domain.VoteSubject domainVoteSubject = voteSubject.GetObject(_identity);
                UIMapping.BindObjectToControls(domainVoteSubject, this);
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
                    ZhuJi.Modules.VoteModule.Domain.VoteSubject domainVoteSubject = new ZhuJi.Modules.VoteModule.Domain.VoteSubject();
                    UIMapping.BindControlsToObject(domainVoteSubject, this);

                    ZhuJi.Modules.VoteModule.IDAL.IVoteSubject voteSubject = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.VoteModule.NHibernateDAL.VoteSubject)) as ZhuJi.Modules.VoteModule.IDAL.IVoteSubject;
                    voteSubject.Insert(domainVoteSubject);

					_identity = domainVoteSubject.Id;
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
                    ZhuJi.Modules.VoteModule.Domain.VoteSubject domainVoteSubject = new ZhuJi.Modules.VoteModule.Domain.VoteSubject();
                    UIMapping.BindControlsToObject(domainVoteSubject, this);

                    ZhuJi.Modules.VoteModule.IDAL.IVoteSubject voteSubject = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.VoteModule.NHibernateDAL.VoteSubject)) as ZhuJi.Modules.VoteModule.IDAL.IVoteSubject;
                    voteSubject.Update(domainVoteSubject);
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
                ZhuJi.Modules.VoteModule.Domain.VoteSubject domainVoteSubject = new ZhuJi.Modules.VoteModule.Domain.VoteSubject();

                domainVoteSubject.Id = int.Parse(Id.Text);

                ZhuJi.Modules.VoteModule.IDAL.IVoteSubject voteSubject = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.VoteModule.NHibernateDAL.VoteSubject)) as ZhuJi.Modules.VoteModule.IDAL.IVoteSubject;
                voteSubject.Delete(domainVoteSubject);
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }
            Response.Redirect(Request.Url.ToString(), true);
        }
    }
}

