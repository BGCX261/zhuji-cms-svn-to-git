using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Modules.VoteModule.Domain
{
    /// <summary>
	/// 投票Ip
    /// </summary>
    public class VoteSubjectIp
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
        /// Ip
        /// </summary>
        public virtual string Ip
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 15)
                {
                    throw new ArgumentOutOfRangeException("Ip不能大于15字节！", value, value.ToString());
                }
                _ip = value;
            }
            get { return _ip; }
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
		
        private int _subjectId;
        /// <summary>
		/// 主题编号
        /// </summary>
        public virtual int SubjectId
        {
			set
            {
                _subjectId = value;
            }
            get { return _subjectId; }
        }

		private VoteSubject _voteSubjectInfo;
		/// <summary>
		/// 投票主题
		/// </summary>
		public virtual VoteSubject VoteSubjectInfo
		{
			set
			{
				_voteSubjectInfo = value;
			}
			get { return _voteSubjectInfo; }
		}
		
    }
}


