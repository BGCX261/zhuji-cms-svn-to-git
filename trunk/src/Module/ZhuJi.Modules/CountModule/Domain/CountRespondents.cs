using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Modules.CountModule.Domain
{
    /// <summary>
	/// 受访页
    /// </summary>
    public class CountRespondents
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
		
        private string _respondents;
        /// <summary>
		/// 受访页
        /// </summary>
        public virtual string Respondents
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("Respondents不能大于100字节！", value, value.ToString());
                }
                _respondents = value;
            }
            get { return _respondents; }
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


