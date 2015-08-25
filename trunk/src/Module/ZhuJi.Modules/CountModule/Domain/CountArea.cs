using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Modules.CountModule.Domain
{
    /// <summary>
	/// 地域
    /// </summary>
    public class CountArea
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
		
        private string _area;
        /// <summary>
		/// 地区
        /// </summary>
        public virtual string Area
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 50)
                {
					throw new ArgumentOutOfRangeException("地区不能大于50字节！", value, value.ToString());
                }
                _area = value;
            }
            get { return _area; }
        }
		
        private string _province;
        /// <summary>
		/// 省
        /// </summary>
        public virtual string Province
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 50)
                {
					throw new ArgumentOutOfRangeException("省不能大于50字节！", value, value.ToString());
                }
                _province = value;
            }
            get { return _province; }
        }
		
        private string _city;
        /// <summary>
		/// 市
        /// </summary>
        public virtual string City
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 50)
                {
					throw new ArgumentOutOfRangeException("市不能大于50字节！", value, value.ToString());
                }
                _city = value;
            }
            get { return _city; }
        }
		
        private int _visits;
        /// <summary>
		/// 访问量
        /// </summary>
        public virtual int Visits
        {
			set
            {
                _visits = value;
            }
            get { return _visits; }
        }
		
        private DateTime _addTime;
        /// <summary>
		/// 更新时间
        /// </summary>
        public virtual DateTime AddTime
        {
			set
            {
                _addTime = value;
            }
            get { return _addTime; }
        }
		
    }
}


