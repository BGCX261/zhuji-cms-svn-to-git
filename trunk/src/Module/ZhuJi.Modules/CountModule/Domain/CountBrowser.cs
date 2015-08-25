using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Modules.CountModule.Domain
{
    /// <summary>
	/// 浏览器
    /// </summary>
    public class CountBrowser
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
		
        private string _browser;
        /// <summary>
		/// 浏览器
        /// </summary>
        public virtual string Browser
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
					throw new ArgumentOutOfRangeException("浏览器不能大于100字节！", value, value.ToString());
                }
                _browser = value;
            }
            get { return _browser; }
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
		
        private DateTime _addtime;
        /// <summary>
		/// 更新时间
        /// </summary>
        public virtual DateTime Addtime
        {
			set
            {
                _addtime = value;
            }
            get { return _addtime; }
        }
		
    }
}


