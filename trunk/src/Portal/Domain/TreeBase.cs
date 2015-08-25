using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using ZhuJi.Library.Text;

namespace ZhuJi.Portal.Domain
{
	/// <summary>
	/// 树形基类
	/// </summary>
    public class TreeBase
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

        private int _parent;
        /// <summary>
        /// 父节点
        /// </summary>
        public virtual int Parent
        {
            set { _parent = value; }
            get { return _parent; }
        }

        private int _depth;
        /// <summary>
        /// 深度
        /// </summary>
        public virtual int Depth
        {
            set { _depth = value; }
            get { return _depth; }
        }

        private string _path;
        /// <summary>
        /// 路径
        /// </summary>
        public virtual string Path
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 250)
                {
                    throw new ArgumentOutOfRangeException("路径不能大于250字节！", value, value.ToString());
                }
                _path = value;
            }
            get { return _path; }
        }

        private int _child;
        /// <summary>
        /// 子节点数
        /// </summary>
        public virtual int Child
        {
            set { _child = value; }
            get { return _child; }
        }

        private string _target;
        /// <summary>
        /// 连接目标
        /// </summary>
        public virtual string Target
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 30)
                {
                    throw new ArgumentOutOfRangeException("连接目标不能大于30字节！", value, value.ToString());
                }
                _target = value;
            }
            get { return _target; }
        }

        private string _remarks;
        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Remarks
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 250)
                {
                    throw new ArgumentOutOfRangeException("描述不能大于250字节！", value, value.ToString());
                }
                _remarks = value;
            }
            get { return _remarks; }
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
