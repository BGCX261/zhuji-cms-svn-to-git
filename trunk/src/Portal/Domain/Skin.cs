using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Portal.Domain
{
    /// <summary>
    /// 皮肤
    /// </summary>
    public class Skin
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
        /// 皮肤名称
        /// </summary>
        public virtual string Name
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 50)
                {
                    throw new ArgumentOutOfRangeException("皮肤名称不能大于50字节！", value, value.ToString());
                }
                _name = value;
            }
            get { return _name; }
        }

        private string _xsl;
        /// <summary>
        /// Xsl皮肤
        /// </summary>
        public virtual string Xsl
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("Xsl皮肤不能大于100字节！", value, value.ToString());
                }
                _xsl = value;
            }
            get { return _xsl; }
        }

        private string _style;
        /// <summary>
        /// 系统的样式
        /// </summary>
        public virtual string Style
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("系统的样式不能大于100字节！", value, value.ToString());
                }
                _style = value;
            }
            get { return _style; }
        }

        private string _master;
        /// <summary>
        /// 系统母版页
        /// </summary>
        public virtual string Master
        {
            set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("系统母版页不能大于100字节！", value, value.ToString());
                }
                _master = value;
            }
            get { return _master; }
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