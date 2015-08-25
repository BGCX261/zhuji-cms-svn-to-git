using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Modules.AdsModule.Domain
{
    /// <summary>
	/// 版位类型
    /// </summary>
    public class AdsLocationType
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
		
        private int _value;
        /// <summary>
        /// 值
        /// </summary>
        public virtual int Value
        {
			set
            {
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
			set
            {
                _orderBy = value;
            }
            get { return _orderBy; }
        }
		
    }
}


