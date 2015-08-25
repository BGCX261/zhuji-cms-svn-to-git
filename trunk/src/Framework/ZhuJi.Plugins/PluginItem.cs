using System;
using System.Collections.Generic;
using System.Text;

namespace ZhuJi.Plugins
{
    /// <summary>
    /// 控件信息
    /// </summary>
    public class PluginItem
    {
        private string _key;
        /// <summary>
        /// 用户控件Id
        /// </summary>
        public string Key
        {
            set { _key = value; }
            get { return _key; }
        }

        private string _name;
        /// <summary>
        /// 用户控件名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        
        private string _managePath;
        /// <summary>
        /// 用户控件路径
        /// </summary>
        public string ManagePath
        {
            set { _managePath = value; }
            get { return _managePath; }
        }
    }
}
