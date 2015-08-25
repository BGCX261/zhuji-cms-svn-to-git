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
    public partial class VoteItemEdit : ZhuJi.Portal.WebUI.BaseWebControl
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
				ZhuJi.Modules.VoteModule.IDAL.IVoteSubject voteSubject = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.VoteModule.NHibernateDAL.VoteSubject)) as ZhuJi.Modules.VoteModule.IDAL.IVoteSubject;
				IList<ZhuJi.Modules.VoteModule.Domain.VoteSubject> listVoteSubject = voteSubject.GetObjects();
				foreach (ZhuJi.Modules.VoteModule.Domain.VoteSubject domainVoteSubject in listVoteSubject)
				{
					SubjectId.Items.Add(new ListItem(domainVoteSubject.Title.ToString(), domainVoteSubject.Id.ToString()));
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
                ZhuJi.Modules.VoteModule.IDAL.IVoteItem voteItem = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.VoteModule.NHibernateDAL.VoteItem)) as ZhuJi.Modules.VoteModule.IDAL.IVoteItem;
                ZhuJi.Modules.VoteModule.Domain.VoteItem domainVoteItem = voteItem.GetObject(_identity);
                UIMapping.BindObjectToControls(domainVoteItem, this);
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
                    ZhuJi.Modules.VoteModule.Domain.VoteItem domainVoteItem = new ZhuJi.Modules.VoteModule.Domain.VoteItem();
                    UIMapping.BindControlsToObject(domainVoteItem, this);

                    ZhuJi.Modules.VoteModule.IDAL.IVoteItem voteItem = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.VoteModule.NHibernateDAL.VoteItem)) as ZhuJi.Modules.VoteModule.IDAL.IVoteItem;
                    voteItem.Insert(domainVoteItem);

					_identity = domainVoteItem.Id;
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
                    ZhuJi.Modules.VoteModule.Domain.VoteItem domainVoteItem = new ZhuJi.Modules.VoteModule.Domain.VoteItem();
                    UIMapping.BindControlsToObject(domainVoteItem, this);

                    ZhuJi.Modules.VoteModule.IDAL.IVoteItem voteItem = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.VoteModule.NHibernateDAL.VoteItem)) as ZhuJi.Modules.VoteModule.IDAL.IVoteItem;
                    voteItem.Update(domainVoteItem);
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
                ZhuJi.Modules.VoteModule.Domain.VoteItem domainVoteItem = new ZhuJi.Modules.VoteModule.Domain.VoteItem();

                domainVoteItem.Id = int.Parse(Id.Text);

                ZhuJi.Modules.VoteModule.IDAL.IVoteItem voteItem = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Modules.VoteModule.NHibernateDAL.VoteItem)) as ZhuJi.Modules.VoteModule.IDAL.IVoteItem;
                voteItem.Delete(domainVoteItem);
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }
            Response.Redirect(Request.Url.ToString(), true);
        }
    }
}

