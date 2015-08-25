using System;
using ZhuJi.Library.Text;

namespace ZhuJi.UUMS.Domain
{
    /// <summary>
    /// 资源信息
    /// </summary>
    public class Resources
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
		
        private string _resourceName;
        /// <summary>
        /// 资源名称
        /// </summary>
        public virtual string ResourceName
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 50)
                {
                    throw new ArgumentOutOfRangeException("资源名称不能大于50字节！", value, value.ToString());
                }
                _resourceName = value;
            }
            get { return _resourceName; }
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


