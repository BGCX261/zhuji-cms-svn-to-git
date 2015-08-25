using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

namespace ZhuJi.Modules.RssModule.Domain
{
	/// <summary>
	/// 频道
	/// </summary>
	public class RssChannel
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
		/// 频道的名称
		/// </summary>
		public virtual string Title
		{
			set { _title = value; }
			get { return _title; }
		}

		private string _image;
		/// <summary>
		/// 指定一个可以在频道中显示的 GIF、JPEG 或者 PNG 图像
		/// </summary>
		public virtual string Image
		{
			set { _image = value; }
			get { return _image; }
		}

		private string _description;
		/// <summary>
		/// 频道的描述
		/// </summary>
		public virtual string Description
		{
			set { _description = value; }
			get { return _description; }
		}

		private string _link;
		/// <summary>
		/// 与该频道关联的 Web 站点或者站点区域的 URL
		/// </summary>
		public virtual string Link
		{
			set { _link = value; }
			get { return _link; }
		}

		private string _language;
		/// <summary>
		/// 频道使用的语言
		/// </summary>
		public virtual string Language
		{
			set { _language = value; }
			get { return _language; }
		}

		private string _docs;
		/// <summary>
		/// 指向该 RSS 文件所用格式说明文档的URL链接地址
		/// </summary>
		public virtual string Docs
		{
			set { _docs = value; }
			get { return _docs; }
		}

		private string _generator;
		/// <summary>
		/// 表明生成频道的程序名称的字符串
		/// </summary>
		public virtual string Generator
		{
			set { _generator = value; }
			get { return _generator; }
		}

		private string _ttl;
		/// <summary>
		/// 存活时间
		/// </summary>
		public virtual string Ttl
		{
			set { _ttl = value; }
			get { return _ttl; }
		}

		private IList<RssItem> _rssItems = new List<RssItem>();
		/// <summary>
		/// 子项目集合
		/// </summary>
		public virtual IList<RssItem> RssItems
		{
			set { _rssItems = value; }
			get { return _rssItems; }
		}
	}
}
