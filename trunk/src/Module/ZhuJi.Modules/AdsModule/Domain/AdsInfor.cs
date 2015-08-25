using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Modules.AdsModule.Domain
{
    /// <summary>
	/// 广告信息
    /// </summary>
    public class AdsInfor
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
		
        private int _location;
        /// <summary>
		/// 所属广告版位
        /// </summary>
        public virtual int Location
        {
			set
            {
                _location = value;
            }
            get { return _location; }
        }
		
        private string _name;
        /// <summary>
		/// 广告名称
        /// </summary>
        public virtual string Name
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 50)
                {
					throw new ArgumentOutOfRangeException("广告名称不能大于50字节！", value, value.ToString());
                }
                _name = value;
            }
            get { return _name; }
        }
		
        private string _content;
        /// <summary>
		/// 广告内容
        /// </summary>
        public virtual string Content
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 300)
                {
					throw new ArgumentOutOfRangeException("广告内容不能大于300字节！", value, value.ToString());
                }
                _content = value;
            }
            get { return _content; }
        }
		
        private int _hots;
        /// <summary>
		/// 权重
        /// </summary>
        public virtual int Hots
        {
			set
            {
                _hots = value;
            }
            get { return _hots; }
        }
		
        private DateTime _registerTime;
        /// <summary>
		/// 受理日期
        /// </summary>
        public virtual DateTime RegisterTime
        {
			set
            {
                _registerTime = value;
            }
            get { return _registerTime; }
        }
		
        private DateTime _beginTime;
        /// <summary>
		/// 开播日期
        /// </summary>
        public virtual DateTime BeginTime
        {
			set
            {
                _beginTime = value;
            }
            get { return _beginTime; }
        }
		
        private DateTime _endTime;
        /// <summary>
		/// 停播日期
        /// </summary>
        public virtual DateTime EndTime
        {
			set
            {
                _endTime = value;
            }
            get { return _endTime; }
        }
		
        private string _customerUnits;
        /// <summary>
		/// 客户单位
        /// </summary>
        public virtual string CustomerUnits
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 50)
                {
					throw new ArgumentOutOfRangeException("客户单位不能大于50字节！", value, value.ToString());
                }
                _customerUnits = value;
            }
            get { return _customerUnits; }
        }
		
        private string _customerPerson;
        /// <summary>
		/// 客户联系人
        /// </summary>
        public virtual string CustomerPerson
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 50)
                {
					throw new ArgumentOutOfRangeException("客户联系人不能大于50字节！", value, value.ToString());
                }
                _customerPerson = value;
            }
            get { return _customerPerson; }
        }
		
        private string _customerContact;
        /// <summary>
		/// 客户联系方法
        /// </summary>
        public virtual string CustomerContact
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 250)
                {
					throw new ArgumentOutOfRangeException("客户联系方法不能大于250字节！", value, value.ToString());
                }
                _customerContact = value;
            }
            get { return _customerContact; }
        }

		private AdsLocation _adsLocationInfo;
		/// <summary>
		/// 广告版位
		/// </summary>
		public virtual AdsLocation AdsLocationInfo
		{
			set
			{
				_adsLocationInfo = value;
			}
			get { return _adsLocationInfo; }
		}
		
    }
}


