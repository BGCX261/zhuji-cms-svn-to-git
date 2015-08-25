using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace ZhuJi.Modules.RssModule.Domain
{
	/// <summary>
	/// 项目
	/// </summary>
	public class RssItem
	{
		private int _id;
		/// <summary>
		/// 标识
		/// </summary>
		public virtual int Id
		{
			set { _id = value; }
			get { return _id; }
		}

		private string _title;
		/// <summary>
		/// 名称
		/// </summary>
		public virtual string Title
		{
			set { _title = value; }
			get { return _title; }
		}

		private string _link;
		/// <summary>
		/// 链接
		/// </summary>
		public virtual string Link
		{
			set { _link = value; }
			get { return _link; }
		}

		private DateTime _pubDate;
		/// <summary>
		/// 发布的时间
		/// </summary>
		public virtual DateTime PubDate
		{
			set { _pubDate = value; }
			get { return _pubDate; }
		}

		private string _source;
		/// <summary>
		/// 来源
		/// </summary>
		public virtual string Source
		{
			set { _source = value; }
			get { return _source; }
		}

		private string _author;
		/// <summary>
		/// 作者
		/// </summary>
		public virtual string Author
		{
			set { _author = value; }
			get { return _author; }
		}

		private string _description;
		/// <summary>
		/// 描述
		/// </summary>
		public virtual string Description
		{
			set { _description = value; }
			get { return _description; }
		}

		private int _channelId;
		/// <summary>
		/// 频道标识
		/// </summary>
		public virtual int ChannelId
		{
			set { _channelId = value; }
			get { return _channelId; }
		}

		//private RssChannel _channelInfo;
		///// <summary>
		///// 频道信息
		///// </summary>
		//public virtual RssChannel ChannelInfo
		//{
		//    set { _channelInfo = value; }
		//    get { return _channelInfo; }
		//}
	}
}
