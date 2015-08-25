using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using ZhuJi.Library.Text;

namespace ZhuJi.Portal.Domain
{
	/// <summary>
	/// ���λ���
	/// </summary>
    public class TreeBase
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

        private int _parent;
        /// <summary>
        /// ���ڵ�
        /// </summary>
        public virtual int Parent
        {
            set { _parent = value; }
            get { return _parent; }
        }

        private int _depth;
        /// <summary>
        /// ���
        /// </summary>
        public virtual int Depth
        {
            set { _depth = value; }
            get { return _depth; }
        }

        private string _path;
        /// <summary>
        /// ·��
        /// </summary>
        public virtual string Path
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 250)
                {
                    throw new ArgumentOutOfRangeException("·�����ܴ���250�ֽڣ�", value, value.ToString());
                }
                _path = value;
            }
            get { return _path; }
        }

        private int _child;
        /// <summary>
        /// �ӽڵ���
        /// </summary>
        public virtual int Child
        {
            set { _child = value; }
            get { return _child; }
        }

        private string _target;
        /// <summary>
        /// ����Ŀ��
        /// </summary>
        public virtual string Target
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 30)
                {
                    throw new ArgumentOutOfRangeException("����Ŀ�겻�ܴ���30�ֽڣ�", value, value.ToString());
                }
                _target = value;
            }
            get { return _target; }
        }

        private string _remarks;
        /// <summary>
        /// ����
        /// </summary>
        public virtual string Remarks
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 250)
                {
                    throw new ArgumentOutOfRangeException("�������ܴ���250�ֽڣ�", value, value.ToString());
                }
                _remarks = value;
            }
            get { return _remarks; }
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
