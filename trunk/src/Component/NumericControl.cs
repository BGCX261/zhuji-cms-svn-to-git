using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

[assembly: WebResource("ZhuJi.Component.js.numeric.js", "application/x-javascript")]
namespace ZhuJi.Component
{
	/// <summary>
	/// 数字控件。
	/// </summary>
	[DefaultProperty("Text"), 
	ToolboxData("<{0}:NumericControl runat=server></{0}:NumericControl>")]
	public class NumericControl : Config
	{
		private const string NUMERAL_SCRIPT_KEYPRESS = "return NumericControl_Validate_KeyPress(this,{0},{1})";
		private const string NUMERAL_SCRIPT_PASTE = "return NumericControl_Validate_Paste(this)";
		private const string NUMERAL_SCRIPT_DRAGENTER = "return NumericControl_Validate_DragEnter(this)";

		private void RenderJavscript()
		{
			ClientScriptManager scriptManager = Page.ClientScript;
			scriptManager.RegisterClientScriptResource(this.GetType(), "ZhuJi.Component.js.numeric.js");
		}

		/// <summary>
		/// 将需要为控件呈现的 HTML 属性和样式添加到指定的 HtmlTextWriter 对象。
		/// </summary>
		/// <param name="writer">表示要在客户端呈现 HTML 内容的输出流。</param>
		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
			base.AddAttributesToRender(writer);
			writer.AddAttribute("onkeypress", string.Format(NUMERAL_SCRIPT_KEYPRESS,_decimals,AllowNegative.ToString().ToLower()));
			writer.AddAttribute("onpaste",NUMERAL_SCRIPT_PASTE);
			writer.AddAttribute("ondragenter",NUMERAL_SCRIPT_DRAGENTER);
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
		/// 
		/// </summary>
		[Bindable(true), Category("Appearance"), DefaultValue(""), Description("TextBox_Text"), PersistenceMode(PersistenceMode.EncodedInnerDefaultProperty)]
		public override string Text
		{
			get
			{
				string str = (string) this.ViewState["Text"];
				if (str != null)
				{
					return decimal.Parse(str).ToString(_format);
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
		public NumericControl() : base()
		{}

		private string _format;
		/// <summary>
		/// 格式化信息
		/// </summary>
		[Description("格式化信息"),Bindable(true), Category("Behavior"), DefaultValue("")]
		public string Format
		{
			set {_format = value;}
			get {return _format;}
		}

		private int _decimals;
		/// <summary>
		/// 小数点位数
		/// </summary>
		[Description("小数点位数"),Bindable(true), Category("Behavior"), DefaultValue(0)]
		public int Decimals
		{
			set { _decimals = value;}
			get { return _decimals;}
		}

		private bool _allowNegative=true;
		/// <summary>
		/// 是否负数
		/// </summary>
		[Description("是否负数"),Bindable(true), Category("Behavior"), DefaultValue(true)]
		public bool AllowNegative
		{
			set { _allowNegative = value;}
			get { return _allowNegative;}
		}
		
	}
}
