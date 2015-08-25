using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Xml;
using System.Collections.Generic;

namespace ZhuJi.Plugins
{
    /// <summary>
    /// 插件管理
    /// </summary>
    public class AddIn : IAddIn
    {
        #region 常量
        private const string PLUGINS_NAME = "/Plugins/Name";
        private const string PLUGINS_VERSION = "/Plugins/Version";
        private const string PLUGINS_PLUGINITEMS = "/Plugins/PluginItems";
        private const string PLUGINS_PLUGINITEMS_KEY = "Key";
        private const string PLUGINS_PLUGINITEMS_NAME = "Name";
        private const string PLUGINS_PLUGINITEMS_MANAGEPATH = "ManagePath";
        #endregion

        #region 属性
        private string _name;
        /// <summary>
        /// 插件名称
        /// </summary>
        private string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        private string _version;
        /// <summary>
        /// 插件版本
        /// </summary>
        private string Version
        {
            set { _version = value; }
            get { return _version; }
        }

        private Dictionary<string, PluginItem> _pluginItems = new Dictionary<string, PluginItem>();
        /// <summary>
        /// 控件信息集合
        /// </summary>
        private Dictionary<string, PluginItem> PluginItems
        {
            set { _pluginItems = value; }
            get { return _pluginItems; }
        }
        #endregion

        #region 方法
        /// <summary>
        /// 初始化插件
        /// </summary>
        /// <param name="configPath">配置文件路径</param>
        public void Init(string configPath)
        {
            if (File.Exists(configPath))
            {
                XmlDocument doc = LoadXmlDocument(configPath);
                if (doc != null)
                {
                    Name = doc.DocumentElement.SelectSingleNode(PLUGINS_NAME).InnerText.Trim();
                    Version = doc.DocumentElement.SelectSingleNode(PLUGINS_VERSION).InnerText.Trim();

                    XmlNodeList nodeList = doc.DocumentElement.SelectNodes(PLUGINS_PLUGINITEMS);
                    foreach (XmlNode node in nodeList)
                    {
                        PluginItem pluginItem = new PluginItem();

                        foreach (XmlNode childNode in node.ChildNodes)
                        {
                            switch(childNode.Name)
                            {
                                case PLUGINS_PLUGINITEMS_KEY:
                                    pluginItem.Key = childNode.InnerText.Trim();
                                    break;
                                case PLUGINS_PLUGINITEMS_NAME:
                                    pluginItem.Name = childNode.InnerText.Trim();
                                    break;
                                case PLUGINS_PLUGINITEMS_MANAGEPATH:
                                    pluginItem.ManagePath = childNode.InnerText.Trim();
                                    break;
                            }
                        }

                        if (!PluginItems.ContainsKey(pluginItem.Key))
                        {
                            PluginItems.Add(pluginItem.Key, pluginItem);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 获取用户控件
        /// </summary>
        /// <param name="key">关键字</param>
        /// <returns>返回用户控件</returns>
        public Control GetControl(string key)
        {
            Page page = new Page();
            Control control = new Control();
            if (PluginItems.ContainsKey(key))
            {
                PluginItem pluginItem = PluginItems[key];
                control = page.LoadControl(pluginItem.ManagePath);
                control.ID = pluginItem.Key;
            }
            return control;
        }
        #endregion

        /// <summary>
        /// 锁定xml操作
        /// </summary>
        private static object lockXml = new object();

        /// <summary>
        /// 加载Xml文档
        /// </summary>
        /// <param name="configPath">Xml文档路径</param>
        /// <returns></returns>
        private static XmlDocument LoadXmlDocument(string configPath)
        {
            lock (lockXml)
            {
                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(configPath);
                    return doc;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
