using System;
using System.ComponentModel;

namespace ZhuJi.Component
{
	/// <summary>
	/// �ؼ�������Ϣ
	/// </summary>
	public class Config : System.Web.UI.WebControls.TextBox
	{
		private string _scriptPath = "/zhuji_component/js/";
		/// <summary>
		/// �ű�·��
		/// </summary>
		[Bindable(true), Category("Appearance"), DefaultValue("/zhuji_component/js/")]
		public string ScriptPath
		{
			set {_scriptPath = value;}
			get {return _scriptPath;}
		}
	}

}
