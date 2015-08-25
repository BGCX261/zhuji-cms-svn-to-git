using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Modules.CountModule.Domain
{
    /// <summary>
	/// 来路站点
    /// </summary>
    public class CountReferSite
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
		
        private string _referSite;
        /// <summary>
		/// 来路站点
        /// </summary>
        public virtual string ReferSite
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
					throw new ArgumentOutOfRangeException("来路站点不能大于100字节！", value, value.ToString());
                }
                _referSite = value;
            }
            get { return _referSite; }
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


