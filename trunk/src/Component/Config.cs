using System;
using System.ComponentModel;

namespace ZhuJi.Component
{
	/// <summary>
	/// 控件基本信息
	/// </summary>
	public class Config : System.Web.UI.WebControls.TextBox
	{
		private string _scriptPath = "/zhuji_component/js/";
		/// <summary>
		/// 脚本路径
		/// </summary>
		[Bindable(true), Category("Appearance"), DefaultValue("/zhuji_component/js/")]
		public string ScriptPath
		{
			set {_scriptPath = value;}
			get {return _scriptPath;}
		}
	}

}
