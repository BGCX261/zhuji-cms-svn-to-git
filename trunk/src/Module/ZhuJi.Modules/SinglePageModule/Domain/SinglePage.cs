using System;
using ZhuJi.Library.Text;
using ZhuJi.Modules.Core.Domain;

namespace ZhuJi.Modules.SinglePageModule.Domain
{
    /// <summary>
    /// ��ҳ
    /// </summary>
    public class SinglePage
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

        private ContentBase _contentBaseInto;
        /// <summary>
        /// ��������
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
