using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Modules.CountModule.Domain
{
    /// <summary>
	/// 概况
    /// </summary>
    public class CountProfiles
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
		
        private string _sitename;
        /// <summary>
		/// 站点名称
        /// </summary>
        public virtual string Sitename
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 50)
                {
					throw new ArgumentOutOfRangeException("站点名称不能大于50字节！", value, value.ToString());
                }
                _sitename = value;
            }
            get { return _sitename; }
        }
		
        private string _siteurl;
        /// <summary>
		/// 站点地址
        /// </summary>
        public virtual string Siteurl
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
					throw new ArgumentOutOfRangeException("站点地址不能大于100字节！", value, value.ToString());
                }
                _siteurl = value;
            }
            get { return _siteurl; }
        }
		
        private int _todaypvs;
        /// <summary>
		/// 当天PV
        /// </summary>
        public virtual int Todaypvs
        {
			set
            {
                _todaypvs = value;
            }
            get { return _todaypvs; }
        }
		
        private int _todayips;
        /// <summary>
		/// 当天IP
        /// </summary>
        public virtual int Todayips
        {
			set
            {
                _todayips = value;
            }
            get { return _todayips; }
        }
		
        private int _todaycookies;
        /// <summary>
		/// 当天独立访客
        /// </summary>
        public virtual int Todaycookies
        {
			set
            {
                _todaycookies = value;
            }
            get { return _todaycookies; }
        }
		
        private int _yesterdaypvs;
        /// <summary>
		/// 昨日PV
        /// </summary>
        public virtual int Yesterdaypvs
        {
			set
            {
                _yesterdaypvs = value;
            }
            get { return _yesterdaypvs; }
        }
		
        private int _yesterdayips;
        /// <summary>
		/// 昨日IP
        /// </summary>
        public virtual int Yesterdayips
        {
			set
            {
                _yesterdayips = value;
            }
            get { return _yesterdayips; }
        }
		
        private int _yesterdaycookies;
        /// <summary>
		/// 昨日独立访客
        /// </summary>
        public virtual int Yesterdaycookies
        {
			set
            {
                _yesterdaycookies = value;
            }
            get { return _yesterdaycookies; }
        }
		
        private int _maxpvs;
        /// <summary>
		/// 历史最高PV
        /// </summary>
        public virtual int Maxpvs
        {
			set
            {
                _maxpvs = value;
            }
            get { return _maxpvs; }
        }
		
        private int _maxips;
        /// <summary>
		/// 历史最高IP
        /// </summary>
        public virtual int Maxips
        {
			set
            {
                _maxips = value;
            }
            get { return _maxips; }
        }
		
        private int _maxcookies;
        /// <summary>
		/// 历史最高独立访客
        /// </summary>
        public virtual int Maxcookies
        {
			set
            {
                _maxcookies = value;
            }
            get { return _maxcookies; }
        }
		
        private int _averagepvs;
        /// <summary>
		/// 平均PV
        /// </summary>
        public virtual int Averagepvs
        {
			set
            {
                _averagepvs = value;
            }
            get { return _averagepvs; }
        }
		
        private int _averageips;
        /// <summary>
		/// 平均IP
        /// </summary>
        public virtual int Averageips
        {
			set
            {
                _averageips = value;
            }
            get { return _averageips; }
        }
		
        private int _averagecookies;
        /// <summary>
		/// 平均独立访客
        /// </summary>
        public virtual int Averagecookies
        {
			set
            {
                _averagecookies = value;
            }
            get { return _averagecookies; }
        }
		
        private int _totalpvs;
        /// <summary>
		/// 总PV
        /// </summary>
        public virtual int Totalpvs
        {
			set
            {
                _totalpvs = value;
            }
            get { return _totalpvs; }
        }
		
        private int _totalips;
        /// <summary>
		/// 总IP
        /// </summary>
        public virtual int Totalips
        {
			set
            {
                _totalips = value;
            }
            get { return _totalips; }
        }
		
        private int _totalcookies;
        /// <summary>
		/// 总独立访客
        /// </summary>
        public virtual int Totalcookies
        {
			set
            {
                _totalcookies = value;
            }
            get { return _totalcookies; }
        }
		
        private DateTime _beginDate;
        /// <summary>
		/// 开通日期
        /// </summary>
        public virtual DateTime BeginDate
        {
			set
            {
                _beginDate = value;
            }
            get { return _beginDate; }
        }
		
    }
}


