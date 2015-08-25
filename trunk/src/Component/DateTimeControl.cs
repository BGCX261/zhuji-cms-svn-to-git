using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace ZhuJi.Component
{
	/// <summary>
	/// 日期控件
	/// </summary>
	[DefaultProperty("Text"), 
		ToolboxData("<{0}:DateTimeControl runat=server></{0}:DateTimeControl>")]
	public class DateTimeControl : Config
	{
		private const string DATETIME_SCRIPT_ID = "{221d4a2a-2abd-4e08-a52b-6bf15ae95209}";
		private const string DATETIME_SCRIPT_BLOCK = "<script src=\"{0}WdatePicker.js\" type=\"text/javascript\"></script>";

		private void RenderJavscript()
		{
			ClientScriptManager scriptManager = Page.ClientScript;
			if (!scriptManager.IsClientScriptBlockRegistered(DATETIME_SCRIPT_ID))
			{
				scriptManager.RegisterClientScriptBlock(this.GetType(),DATETIME_SCRIPT_ID, string.Format(DATETIME_SCRIPT_BLOCK, base.ScriptPath));
			}
		}

		/// <summary>
		/// 将需要为控件呈现的 HTML 属性和样式添加到指定的 HtmlTextWriter 对象。
		/// </summary>
		/// <param name="writer">表示要在客户端呈现 HTML 内容的输出流。</param>
		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
			base.AddAttributesToRender(writer);
			writer.AddAttribute("ondblclick", GetScript());
		}
		/// <summary>
		/// 通过查找文件数据或调用用户事件获取要呈现的广告信息。 
		/// </summary>
		/// <param name="e">包含事件数据的 EventArgs 对象。</param>
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			RenderJavscript();
		}

		/// <summary>
		/// 将服务器控件内容发送到提供的 HtmlTextWriter 对象，此对象编写将在客户端呈现的内容。
		/// </summary>
		/// <param name="output">接收服务器控件内容的 HtmlTextWriter 对象。</param>
		protected override void Render(HtmlTextWriter output)
		{
			if(base.CssClass.Length == 0)
			{
				base.CssClass = "Wdate";
			}
			base.Render(output);
		}

		/// <summary>
		/// 
		/// </summary>
		[Bindable(true), Category("Appearance"), DefaultValue(""), Description("TextBox_Text"), PersistenceMode(PersistenceMode.EncodedInnerDefaultProperty)]
		public override string Text
		{
			get
			{
				string str = (string)this.ViewState["Text"];
				if (str != null)
				{
					return DateTime.Parse(str).ToString(_format);
				}
				return string.Empty;
			}
			set
			{
				this.ViewState["Text"] = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public DateTimeControl() : base()
		{}

        private string _format;
		/// <summary>
		/// 格式设置信息
		/// </summary>
		[Description("格式设置信息"),Bindable(true), Category("Behavior"), DefaultValue("")]
		public string Format
		{
			set { _format = value;}
			get { return _format;}
		}

		private bool _isShowTime;
		/// <summary>
		/// 是否显示时间
		/// </summary>
		[Description("是否显示时间"),Bindable(true), Category("Behavior"), DefaultValue(false)]
		public bool IsShowTime
		{
			set { _isShowTime = value;}
			get {return _isShowTime;}
		}

		private string _skin = "whyGreen";
		/// <summary>
		/// 皮肤的名称
		/// </summary>
		[Description("皮肤名称"),Bindable(true), Category("Behavior"), DefaultValue("whyGreen")]
		public string Skin
		{
			set { _skin = value;}
			get {return _skin;}
		}

		private string GetScript()
		{
			string ret = string.Format("new WdatePicker({0},{1},{2},'{3}')","this",_format == null ? "null" : string.Format("'{0}'",_format.Replace("yyyy","%Y").Replace("MM","%M").Replace("dd","%D").Replace("HH","%h").Replace("mm","%m").Replace("ss","%s")),_isShowTime.ToString().ToLower(),_skin);
			return ret;
		}
	}
}
