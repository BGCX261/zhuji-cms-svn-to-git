using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Modules.CountModule.Domain
{
    /// <summary>
	/// 分辨率
    /// </summary>
    public class CountResolution
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
		
        private string _resolution;
        /// <summary>
		/// 分辨率
        /// </summary>
        public virtual string Resolution
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
					throw new ArgumentOutOfRangeException("分辨率不能大于100字节！", value, value.ToString());
                }
                _resolution = value;
            }
            get { return _resolution; }
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


