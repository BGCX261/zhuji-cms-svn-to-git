using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Xml;
using System.Collections.Generic;

namespace ZhuJi.Plugins
{
    /// <summary>
    /// �������
    /// </summary>
    public class AddIn : IAddIn
    {
        #region ����
        private const string PLUGINS_NAME = "/Plugins/Name";
        private const string PLUGINS_VERSION = "/Plugins/Version";
        private const string PLUGINS_PLUGINITEMS = "/Plugins/PluginItems";
        private const string PLUGINS_PLUGINITEMS_KEY = "Key";
        private const string PLUGINS_PLUGINITEMS_NAME = "Name";
        private const string PLUGINS_PLUGINITEMS_MANAGEPATH = "ManagePath";
        #endregion

        #region ����
        private string _name;
        /// <summary>
        /// �������
        /// </summary>
        private string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        private string _version;
        /// <summary>
        /// ����汾
        /// </summary>
        private string Version
        {
            set { _version = value; }
            get { return _version; }
        }

        private Dictionary<string, PluginItem> _pluginItems = new Dictionary<string, PluginItem>();
        /// <summary>
        /// �ؼ���Ϣ����
        /// </summary>
        private Dictionary<string, PluginItem> PluginItems
        {
            set { _pluginItems = value; }
            get { return _pluginItems; }
        }
        #endregion

        #region ����
        /// <summary>
        /// ��ʼ�����
        /// </summary>
        /// <param name="configPath">�����ļ�·��</param>
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
        /// ��ȡ�û��ؼ�
        /// </summary>
        /// <param name="key">�ؼ���</param>
        /// <returns>�����û��ؼ�</returns>
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
        /// ����xml����
        /// </summary>
        private static object lockXml = new object();

        /// <summary>
        /// ����Xml�ĵ�
        /// </summary>
        /// <param name="configPath">Xml�ĵ�·��</param>
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
