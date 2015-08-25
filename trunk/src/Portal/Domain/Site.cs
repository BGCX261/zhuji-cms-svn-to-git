using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Portal.Domain
{
    /// <summary>
    /// վ��
    /// </summary>
    public class Site
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
                if (value != null && ValidHelper.BytesSize(value) > 50)
                {
                    throw new ArgumentOutOfRangeException("���ⲻ�ܴ���50�ֽڣ�", value, value.ToString());
                }
                _title = value;
            }
            get { return _title; }
        }

        private string _url;
        /// <summary>
        /// ���ӵ�ַ
        /// </summary>
        public virtual string Url
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("���ӵ�ַ���ܴ���100�ֽڣ�", value, value.ToString());
                }
                _url = value;
            }
            get { return _url; }
        }

        private int _orderBy;
        /// <summary>
        /// ����
        /// </summary>
        public virtual int OrderBy
        {
            set { _orderBy = value; }
            get { return _orderBy; }
        }

    }
}
