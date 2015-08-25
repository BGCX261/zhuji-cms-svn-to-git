using System;
using ZhuJi.Library.Text;

namespace ZhuJi.UUMS.Domain
{
    /// <summary>
    /// 方法说明
    /// </summary>
    public class MethodExplain
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
		
        private string _title;
        /// <summary>
        /// 说明
        /// </summary>
        public virtual string Title
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 50)
                {
                    throw new ArgumentOutOfRangeException("说明不能大于50字节！", value, value.ToString());
                }
                _title = value;
            }
            get { return _title; }
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


