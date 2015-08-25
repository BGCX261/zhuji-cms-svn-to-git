using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace ZhuJi.Component
{
	/// <summary>
	/// ���ڿؼ�
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
		/// ����ҪΪ�ؼ����ֵ� HTML ���Ժ���ʽ��ӵ�ָ���� HtmlTextWriter ����
		/// </summary>
		/// <param name="writer">��ʾҪ�ڿͻ��˳��� HTML ���ݵ��������</param>
		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
			base.AddAttributesToRender(writer);
			writer.AddAttribute("ondblclick", GetScript());
		}
		/// <summary>
		/// ͨ�������ļ����ݻ�����û��¼���ȡҪ���ֵĹ����Ϣ�� 
		/// </summary>
		/// <param name="e">�����¼����ݵ� EventArgs ����</param>
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			RenderJavscript();
		}

		/// <summary>
		/// ���������ؼ����ݷ��͵��ṩ�� HtmlTextWriter ���󣬴˶����д���ڿͻ��˳��ֵ����ݡ�
		/// </summary>
		/// <param name="output">���շ������ؼ����ݵ� HtmlTextWriter ����</param>
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
		/// ��ʽ������Ϣ
		/// </summary>
		[Description("��ʽ������Ϣ"),Bindable(true), Category("Behavior"), DefaultValue("")]
		public string Format
		{
			set { _format = value;}
			get { return _format;}
		}

		private bool _isShowTime;
		/// <summary>
		/// �Ƿ���ʾʱ��
		/// </summary>
		[Description("�Ƿ���ʾʱ��"),Bindable(true), Category("Behavior"), DefaultValue(false)]
		public bool IsShowTime
		{
			set { _isShowTime = value;}
			get {return _isShowTime;}
		}

		private string _skin = "whyGreen";
		/// <summary>
		/// Ƥ��������
		/// </summary>
		[Description("Ƥ������"),Bindable(true), Category("Behavior"), DefaultValue("whyGreen")]
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
