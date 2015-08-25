using System;
using ZhuJi.Library.Text;

namespace ZhuJi.UUMS.Domain
{
    /// <summary>
    /// 控件类型
    /// </summary>
    public class ControlsType
    {
        private int _id;
        /// <summary>
        /// 标识
        /// </summary>
        public virtual int Id
        {
			set
            {
                _id = value;
            }
            get { return _id; }
        }
		
        private string _text;
        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Text
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 30)
                {
                    throw new ArgumentOutOfRangeException("名称不能大于30字节！", value, value.ToString());
                }
                _text = value;
            }
            get { return _text; }
        }
		
        private string _value;
        /// <summary>
        /// 值
        /// </summary>
        public virtual string Value
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 50)
                {
                    throw new ArgumentOutOfRangeException("值不能大于50字节！", value, value.ToString());
                }
                _value = value;
            }
            get { return _value; }
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


