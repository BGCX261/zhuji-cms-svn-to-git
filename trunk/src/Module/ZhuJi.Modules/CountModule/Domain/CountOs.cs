using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Modules.CountModule.Domain
{
    /// <summary>
	/// 操作系统
    /// </summary>
    public class CountOs
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
		
        private string _os;
        /// <summary>
		/// 操作系统
        /// </summary>
        public virtual string Os
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
					throw new ArgumentOutOfRangeException("操作系统不能大于100字节！", value, value.ToString());
                }
                _os = value;
            }
            get { return _os; }
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


