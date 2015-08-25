using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Portal.Domain
{
    /// <summary>
    /// 站点
    /// </summary>
    public class Site
    {
        private int _id;
        /// <summary>
        /// 标识
        /// </summary>
        public virtual int Id
        {
            set { _id = value; }
            get { return _id; }
        }

        private string _title;
        /// <summary>
        /// 标题
        /// </summary>
        public virtual string Title
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 50)
                {
                    throw new ArgumentOutOfRangeException("标题不能大于50字节！", value, value.ToString());
                }
                _title = value;
            }
            get { return _title; }
        }

        private string _url;
        /// <summary>
        /// 连接地址
        /// </summary>
        public virtual string Url
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("连接地址不能大于100字节！", value, value.ToString());
                }
                _url = value;
            }
            get { return _url; }
        }

        private int _orderBy;
        /// <summary>
        /// 排序
        /// </summary>
        public virtual int OrderBy
        {
            set { _orderBy = value; }
            get { return _orderBy; }
        }

    }
}
