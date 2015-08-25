using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Modules.VoteModule.Domain
{
    /// <summary>
	/// 投票选项
    /// </summary>
    public class VoteItem
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
		
        private string _title;
        /// <summary>
		/// 选项标题
        /// </summary>
        public virtual string Title
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
					throw new ArgumentOutOfRangeException("选项标题不能大于100字节！", value, value.ToString());
                }
                _title = value;
            }
            get { return _title; }
        }
		
        private int _votes;
        /// <summary>
		/// 投票数
        /// </summary>
        public virtual int Votes
        {
			set
            {
                _votes = value;
            }
            get { return _votes; }
        }
		
        private int _orders;
        /// <summary>
		/// 排序
        /// </summary>
        public virtual int Orders
        {
			set
            {
                _orders = value;
            }
            get { return _orders; }
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


