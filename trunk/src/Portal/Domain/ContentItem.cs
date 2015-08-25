using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Portal.Domain
{
    /// <summary>
    /// ����
    /// </summary>
    public class ContentItem
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

        private string _name;
        /// <summary>
        /// ��������
        /// </summary>
        public virtual string Name
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 50)
                {
                    throw new ArgumentOutOfRangeException("�������Ʋ��ܴ���50�ֽڣ�", value, value.ToString());
                }
                _name = value;
            }
            get { return _name; }
        }

        private string _operate;
        /// <summary>
        /// ��������
        /// </summary>
        public virtual string Operate
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("�������ݲ��ܴ���100�ֽڣ�", value, value.ToString());
                }
                _operate = value;
            }
            get { return _operate; }
        }

        private string _view;
        /// <summary>
        /// ��ʾ����
        /// </summary>
        public virtual string View
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("��ʾ���ݲ��ܴ���100�ֽڣ�", value, value.ToString());
                }
                _view = value;
            }
            get { return _view; }
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