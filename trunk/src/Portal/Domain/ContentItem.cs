using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Portal.Domain
{
    /// <summary>
    /// 内容
    /// </summary>
    public class ContentItem
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

        private string _name;
        /// <summary>
        /// 内容名称
        /// </summary>
        public virtual string Name
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 50)
                {
                    throw new ArgumentOutOfRangeException("内容名称不能大于50字节！", value, value.ToString());
                }
                _name = value;
            }
            get { return _name; }
        }

        private string _operate;
        /// <summary>
        /// 操作内容
        /// </summary>
        public virtual string Operate
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("操作内容不能大于100字节！", value, value.ToString());
                }
                _operate = value;
            }
            get { return _operate; }
        }

        private string _view;
        /// <summary>
        /// 显示内容
        /// </summary>
        public virtual string View
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("显示内容不能大于100字节！", value, value.ToString());
                }
                _view = value;
            }
            get { return _view; }
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