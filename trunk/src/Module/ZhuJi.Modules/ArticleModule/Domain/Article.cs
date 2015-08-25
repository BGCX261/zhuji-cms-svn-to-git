using System;
using ZhuJi.Library.Text;
using System.Text;
using ZhuJi.Modules.Core.Domain;

namespace ZhuJi.Modules.ArticleModule.Domain
{
    /// <summary>
    /// ����
    /// </summary>
    public class Article
    {
        private int _id;
        /// <summary>
        /// ��ʶ
        /// </summary>
        public virtual int Id
        {
            set { _id = value; }
            get { return _id; }
        }

        private string _title;
        /// <summary>
        /// ����
        /// </summary>
        public virtual string Title
        {
            
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("���ⲻ�ܴ���100�ֽڣ�", value, value.ToString());
                }
                _title = value;
            }
            get { return _title; }
        }

        private string _summary;
        /// <summary>
        /// ժҪ
        /// </summary>
        public virtual string Summary
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 250)
                {
                    throw new ArgumentOutOfRangeException("ժҪ���ܴ���250�ֽڣ�", value, value.ToString());
                }
                _summary = value;
            }
            get { return _summary; }
        }

        private string _content;
        /// <summary>
        /// ����
        /// </summary>
        public virtual string Content
        {
            set { _content = value; }
            get { return _content; }
        }

        private string _author;
        /// <summary>
        /// ����
        /// </summary>
        public virtual string Author
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 30)
                {
                    throw new ArgumentOutOfRangeException("���߲��ܴ���30�ֽڣ�", value, value.ToString());
                }
                _author = value;
            }
            get { return _author; }
        }

        private string _copyFrom;
        /// <summary>
        /// ��Դ
        /// </summary>
        public virtual string CopyFrom
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 30)
                {
                    throw new ArgumentOutOfRangeException("��Դ���ܴ���30�ֽڣ�", value, value.ToString());
                }
                _copyFrom = value;
            }
            get { return _copyFrom; }
        }

		private ContentBase _contentBaseInto;
        /// <summary>
        /// ��������
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


