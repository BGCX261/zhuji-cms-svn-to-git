using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using ZhuJi.Library.Text;

namespace ZhuJi.Portal.Domain
{
    /// <summary>
    /// ��վ��Ŀ
    /// </summary>
    public class Channel : TreeBase
    {
        private int _siteId;
        /// <summary>
        /// ��վ��ʶ
        /// </summary>
        public virtual int SiteId
        {
            set { _siteId = value; }
            get { return _siteId; }
        }

        private Site _siteInfo;
        /// <summary>
        /// ��վ
        /// </summary>
        public virtual Site SiteInfo
        {
            set { _siteInfo = value; }
            get { return _siteInfo; }
        }

        private int _contentItemId;
        /// <summary>
        /// ���ݱ�ʶ
        /// </summary>
        public virtual int ContentItemId
        {
            set { _contentItemId = value; }
            get { return _contentItemId; }
        }

        private ContentItem _contentItemInfo;
        /// <summary>
        /// ����
        /// </summary>
        public virtual ContentItem ContentItemInfo
        {
            set { _contentItemInfo = value; }
            get { return _contentItemInfo; }
        }

        private int _skinId;
        /// <summary>
        /// Ƥ����ʶ
        /// </summary>
        public virtual int SkinId
        {
            set { _skinId = value; }
            get { return _skinId; }
        }

        private Skin _skinInfo;
        /// <summary>
        /// Ƥ��
        /// </summary>
        public virtual Skin SkinInfo
        {
            set { _skinInfo = value; }
            get { return _skinInfo; }
        }
    }

	/// <summary>
	/// ��վ��Ŀ����
	/// </summary>
    public class ChannelCollection
    {
        private Dictionary<string, Channel> _dic = new Dictionary<string, Channel>();
        private IList<Channel> _channels = new List<Channel>();

		/// <summary>
		/// ����������վ��Ŀ�б�
		/// </summary>
		/// <param name="list">��վ��Ŀ�б�</param>
		/// <returns>��վ��Ŀ�б�</returns>
        public IList<Channel> Tree(IList<Channel> list)
        {
            DataTable dt = CreateDateTable(list);

            CreateTree(dt, "0");

            return _channels;
        }

		/// <summary>
		/// ����DataTable
		/// </summary>
		/// <param name="list">��վ��Ŀ�б�</param>
		/// <returns>DataTable</returns>
        public DataTable CreateDateTable(IList<Channel> list)
        {
            DataTable dt = new DataTable("Channel");
            dt.Columns.Add("Id", System.Type.GetType("System.Int32"));
            dt.Columns.Add("Title", System.Type.GetType("System.String"));
            dt.Columns.Add("Parent", System.Type.GetType("System.Int32"));

            foreach (Channel channel in list)
            {
                DataRow dr = dt.NewRow();
                dr[0] = channel.Id;
                dr[1] = channel.Title;
                dr[2] = channel.Parent;
                dt.Rows.Add(dr);

                _dic.Add(channel.Id.ToString(), channel);
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
                        _channels.Insert(0, _dic[id]);
                    }
                }
            }
        }
    }
}
