using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Portal.Domain
{
    /// <summary>
    /// Ƥ��
    /// </summary>
    public class Skin
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
        /// Ƥ������
        /// </summary>
        public virtual string Name
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 50)
                {
                    throw new ArgumentOutOfRangeException("Ƥ�����Ʋ��ܴ���50�ֽڣ�", value, value.ToString());
                }
                _name = value;
            }
            get { return _name; }
        }

        private string _xsl;
        /// <summary>
        /// XslƤ��
        /// </summary>
        public virtual string Xsl
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("XslƤ�����ܴ���100�ֽڣ�", value, value.ToString());
                }
                _xsl = value;
            }
            get { return _xsl; }
        }

        private string _style;
        /// <summary>
        /// ϵͳ����ʽ
        /// </summary>
        public virtual string Style
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("ϵͳ����ʽ���ܴ���100�ֽڣ�", value, value.ToString());
                }
                _style = value;
            }
            get { return _style; }
        }

        private string _master;
        /// <summary>
        /// ϵͳĸ��ҳ
        /// </summary>
        public virtual string Master
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("ϵͳĸ��ҳ���ܴ���100�ֽڣ�", value, value.ToString());
                }
                _master = value;
            }
            get { return _master; }
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