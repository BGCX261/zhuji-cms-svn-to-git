using System;
using ZhuJi.Library.Text;
using ZhuJi.Modules.Core.Domain;

namespace ZhuJi.Modules.SinglePageModule.Domain
{
    /// <summary>
    /// 单页
    /// </summary>
    public class SinglePage
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

        private string _summary;
        /// <summary>
        /// 摘要
        /// </summary>
        public virtual string Summary
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 250)
                {
                    throw new ArgumentOutOfRangeException("摘要不能大于250字节！", value, value.ToString());
                }
                _summary = value;
            }
            get { return _summary; }
        }

        private string _content;
        /// <summary>
        /// 内容
        /// </summary>
        public virtual string Content
        {
            set { _content = value; }
            get { return _content; }
        }

        private ContentBase _contentBaseInto;
        /// <summary>
        /// 基本内容
        /// </summary>
        public virtual ContentBase ContentBaseInfo
        {
            set
            {
                value.SinglePageInfo = this;
                _contentBaseInto = value;
            }
            get { return _contentBaseInto; }
        }
    }
}
