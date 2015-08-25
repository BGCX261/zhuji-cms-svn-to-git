using System;
using ZhuJi.Library.Text;
using System.Text;
using ZhuJi.Modules.Core.Domain;

namespace ZhuJi.Modules.ArticleModule.Domain
{
    /// <summary>
    /// 文章
    /// </summary>
    public class Article
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
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("标题不能大于100字节！", value, value.ToString());
                }
                _title = value;
            }
            get { return _title; }
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

        private string _author;
        /// <summary>
        /// 作者
        /// </summary>
        public virtual string Author
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 30)
                {
                    throw new ArgumentOutOfRangeException("作者不能大于30字节！", value, value.ToString());
                }
                _author = value;
            }
            get { return _author; }
        }

        private string _copyFrom;
        /// <summary>
        /// 来源
        /// </summary>
        public virtual string CopyFrom
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 30)
                {
                    throw new ArgumentOutOfRangeException("来源不能大于30字节！", value, value.ToString());
                }
                _copyFrom = value;
            }
            get { return _copyFrom; }
        }

		private ContentBase _contentBaseInto;
        /// <summary>
        /// 基本内容
        /// </summary>
		public virtual ContentBase ContentBaseInfo
        {
            set
            {
                value.ArticleInfo = this;
                _contentBaseInto = value;
            }
            get { return _contentBaseInto; }
        }

    }
}


