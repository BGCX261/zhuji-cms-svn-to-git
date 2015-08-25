using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ZhuJi.Library.Web;

namespace ZhuJi.Portal.WebUI.DesktopModule.CommonModule
{
    public partial class ChannelEdit : ZhuJi.Portal.WebUI.BaseWebControl
    {
        private const char SYMBOLS = '┣';

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
                ZhuJi.Portal.IDAL.IChannel channel = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.Channel)) as ZhuJi.Portal.IDAL.IChannel;
                IList<ZhuJi.Portal.Domain.Channel> list = channel.TreeNodes();
                Parent.Items.Clear();
                foreach (ZhuJi.Portal.Domain.Channel domainChannel in list)
                {
                    Parent.Items.Add(new ListItem(domainChannel.Title.PadLeft(domainChannel.Title.Length + domainChannel.Depth, SYMBOLS), domainChannel.Id.ToString()));
                }
                Parent.Items.Insert(0, new ListItem("根目录", "0"));

               ZhuJi.Portal.IDAL.ISite site = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.Site)) as ZhuJi.Portal.IDAL.ISite;
                IList<ZhuJi.Portal.Domain.Site> listSite = site.GetObjects("", "tmp.OrderBy");
                foreach (ZhuJi.Portal.Domain.Site domainSite in listSite)
                {
                    SiteId.Items.Add(new ListItem(domainSite.Title.ToString(), domainSite.Id.ToString()));
                }

                ZhuJi.Portal.IDAL.IContentItem contentItem = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.ContentItem)) as ZhuJi.Portal.IDAL.IContentItem;
                IList<ZhuJi.Portal.Domain.ContentItem> listContentItem = contentItem.GetObjects("", "tmp.OrderBy");
                foreach (ZhuJi.Portal.Domain.ContentItem domainContentItem in listContentItem)
                {
                    ContentItemId.Items.Add(new ListItem(domainContentItem.Name.ToString(), domainContentItem.Id.ToString()));
                }

                ZhuJi.Portal.IDAL.ISkin skin = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.Skin)) as ZhuJi.Portal.IDAL.ISkin;
                IList<ZhuJi.Portal.Domain.Skin> listSkin = skin.GetObjects("", "tmp.OrderBy");
                foreach (ZhuJi.Portal.Domain.Skin domainSkin in listSkin)
                {
                    SkinId.Items.Add(new ListItem(domainSkin.Name.ToString(), domainSkin.Id.ToString()));
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
                ZhuJi.Portal.IDAL.IChannel channel = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.Channel)) as ZhuJi.Portal.IDAL.IChannel;
                ZhuJi.Portal.Domain.Channel domainChannel = channel.GetObject(_identity);
                UIMapping.BindObjectToControls(domainChannel, this);
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
                    ZhuJi.Portal.Domain.Channel domainChannel = new ZhuJi.Portal.Domain.Channel();
                    UIMapping.BindControlsToObject(domainChannel, this);

                    ZhuJi.Portal.IDAL.IChannel channel = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.Channel)) as ZhuJi.Portal.IDAL.IChannel;
                    channel.Insert(int.Parse(rblCurrentNode.SelectedValue), domainChannel);

					_identity = domainChannel.Id;
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
                    ZhuJi.Portal.Domain.Channel domainChannel = new ZhuJi.Portal.Domain.Channel();
                    UIMapping.BindControlsToObject(domainChannel, this);

                    ZhuJi.Portal.IDAL.IChannel channel = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.Channel)) as ZhuJi.Portal.IDAL.IChannel;
                    channel.Update(int.Parse(rblCurrentNode.SelectedValue), domainChannel);
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
                ZhuJi.Portal.Domain.Channel domainChannel = new ZhuJi.Portal.Domain.Channel();

                domainChannel.Id = int.Parse(Id.Text);

                ZhuJi.Portal.IDAL.IChannel channel = ZhuJi.AOP.Operator.WrapInterface(typeof(ZhuJi.Portal.NHibernateDAL.Channel)) as ZhuJi.Portal.IDAL.IChannel;
                channel.Delete(domainChannel);
            }
            catch (Exception ex)
            {
                ShowMessage(ex);
            }
            Response.Redirect(Request.Url.ToString(), true);
        }
    }
}

