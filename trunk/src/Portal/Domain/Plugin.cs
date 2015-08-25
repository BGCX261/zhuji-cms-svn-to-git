using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using ZhuJi.Library.Text;

namespace ZhuJi.Portal.Domain
{
    /// <summary>
    /// 插件
    /// </summary>
    public class Plugin : TreeBase
    {        

        private string _keyword;
        /// <summary>
        /// 关键字
        /// </summary>
        public virtual string Keyword
        {
            set 
            {
                if (value != null && ValidHelper.BytesSize(value) > 30)
                {
                    throw new ArgumentOutOfRangeException("关键字不能大于30字节！", value, value.ToString());
                }
                _keyword = value; 
            }
            get { return _keyword; }
        }
		
        private string _configure;
        /// <summary>
        /// 配置文件
        /// </summary>
        public virtual string Configure
        {
            set 
            {
                if (value != null && ValidHelper.BytesSize(value) > 250)
                {
                    throw new ArgumentOutOfRangeException("配置文件不能大于250字节！", value, value.ToString());
                }
                _configure = value; 
            }
            get { return _configure; }
        }

        private bool _isSystem;
        /// <summary>
        /// 是否系统
        /// </summary>
        public virtual bool IsSystem
        {
            set { _isSystem = value; }
            get { return _isSystem; }
        }
    }

	/// <summary>
	/// 插件集合
	/// </summary>
    public class PluginCollection
    {
        private Dictionary<string, Plugin> _dic = new Dictionary<string, Plugin>();
        private IList<Plugin> _plugins = new List<Plugin>();

		/// <summary>
		/// 构建树形插件列表
		/// </summary>
		/// <param name="list">插件列表</param>
		/// <returns>插件列表</returns>
        public IList<Plugin> Tree(IList<Plugin> list)
        {
            DataTable dt = CreateDateTable(list);

            CreateTree(dt, "0");

            return _plugins;
        }

		/// <summary>
		/// 建立DataTable
		/// </summary>
		/// <param name="list">插件列表</param>
		/// <returns>DataTable</returns>
        public DataTable CreateDateTable(IList<Plugin> list)
        {
            DataTable dt = new DataTable("Plugin");
            dt.Columns.Add("Id", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Title", System.Type.GetType("System.String"));
            dt.Columns.Add("Parent", System.Type.GetType("System.Int32"));

            foreach (Plugin plugin in list)
            {
                DataRow dr = dt.NewRow();
                dr[0] = plugin.Id;
                dr[1] = plugin.Title;
                dr[2] = plugin.Parent;
                dt.Rows.Add(dr);

                _dic.Add(plugin.Id.ToString(), plugin);
            }
            return dt;
        }

        private void CreateTree(DataTable dt, string parent)
        {
            DataRow[] drs = dt.Select(string.Format("[Parent] = {0}", parent));
            if (drs.Length == 0)
            {
                return;
            }
            else
            {
                foreach (DataRow dr in drs)
                {
                    string id = dr["Id"].ToString();
                    CreateTree(dt, id);
                    if (_dic.ContainsKey(id))
                    {
                        _plugins.Insert(0,_dic[id]);
                    }
                }
            }
        }
    }
}


