using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Modules.CountModule.Domain
{
    /// <summary>
	/// 时段
    /// </summary>
    public class CountHour
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
		
        private string _ip;
        /// <summary>
		/// IP地址
        /// </summary>
        public virtual string Ip
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 15)
                {
					throw new ArgumentOutOfRangeException("IP地址不能大于15字节！", value, value.ToString());
                }
                _ip = value;
            }
            get { return _ip; }
        }
		
        private int _pvs;
        /// <summary>
		/// PV数
        /// </summary>
        public virtual int Pvs
        {
			set
            {
                _pvs = value;
            }
            get { return _pvs; }
        }
		
        private int _ips;
        /// <summary>
		/// IP数
        /// </summary>
        public virtual int Ips
        {
			set
            {
                _ips = value;
            }
            get { return _ips; }
        }
		
        private int _cookies;
        /// <summary>
		/// 独立访客
        /// </summary>
        public virtual int Cookies
        {
			set
            {
                _cookies = value;
            }
            get { return _cookies; }
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


