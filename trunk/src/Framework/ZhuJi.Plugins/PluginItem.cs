using System;
using System.Collections.Generic;
using System.Text;

namespace ZhuJi.Plugins
{
    /// <summary>
    /// �ؼ���Ϣ
    /// </summary>
    public class PluginItem
    {
        private string _key;
        /// <summary>
        /// �û��ؼ�Id
        /// </summary>
        public string Key
        {
            set { _key = value; }
            get { return _key; }
        }

        private string _name;
        /// <summary>
        /// �û��ؼ�����
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        
        private string _managePath;
        /// <summary>
        /// �û��ؼ�·��
        /// </summary>
        public string ManagePath
        {
            set { _managePath = value; }
            get { return _managePath; }
        }
    }
}
