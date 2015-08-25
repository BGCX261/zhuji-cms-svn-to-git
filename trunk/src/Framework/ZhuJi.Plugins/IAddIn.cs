using System.Web.UI;

namespace ZhuJi.Plugins
{
	/// <summary>
	/// 插件管理接口
	/// </summary>
    public interface IAddIn
    {
        /// <summary>
        /// 初始化插件
        /// </summary>
        /// <param name="configPath">配置文件路径</param>
        void Init(string configPath);

        /// <summary>
        /// 获取用户控件
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns>返回用户控件</returns>
        Control GetControl(string key);
    }
}
