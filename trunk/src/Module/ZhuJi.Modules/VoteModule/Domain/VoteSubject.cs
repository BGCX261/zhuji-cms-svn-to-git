using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Modules.VoteModule.Domain
{
    /// <summary>
	/// 投票主题
    /// </summary>
    public class VoteSubject
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
		
        private string _topicType;
        /// <summary>
		/// 主题类型
        /// </summary>
        public virtual string TopicType
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 30)
                {
					throw new ArgumentOutOfRangeException("主题类型不能大于30字节！", value, value.ToString());
                }
                _topicType = value;
            }
            get { return _topicType; }
        }
		
        private int _topicId;
        /// <summary>
		/// 主题编号
        /// </summary>
        public virtual int TopicId
        {
			set
            {
                _topicId = value;
            }
            get { return _topicId; }
        }
		
        private int _voteType;
        /// <summary>
		/// 投票类型
        /// </summary>
        public virtual int VoteType
        {
			set
            {
                _voteType = value;
            }
            get { return _voteType; }
        }
		
        private string _title;
        /// <summary>
		/// 投票标题
        /// </summary>
        public virtual string Title
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
					throw new ArgumentOutOfRangeException("投票标题不能大于100字节！", value, value.ToString());
                }
                _title = value;
            }
            get { return _title; }
        }
		
        private string _content;
        /// <summary>
		/// 投票内容
        /// </summary>
        public virtual string Content
        {
			set
            {
                _content = value;
            }
            get { return _content; }
        }
		
        private DateTime _beginTime;
        /// <summary>
		/// 开始时间
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
		/// 结束时间
        /// </summary>
        public virtual DateTime EndTime
        {
			set
            {
                _endTime = value;
            }
            get { return _endTime; }
        }
		
        private bool _isIp;
        /// <summary>
		/// 是否IP限制
        /// </summary>
        public virtual bool IsIp
        {
			set
            {
                _isIp = value;
            }
            get { return _isIp; }
        }
		
        private bool _passed;
        /// <summary>
		/// 验证通过
        /// </summary>
        public virtual bool Passed
        {
			set
            {
                _passed = value;
            }
            get { return _passed; }
        }

		private VoteSubjectType _voteSubjectTypeInfo;
		/// <summary>
		/// 投票类型
		/// </summary>
		public virtual VoteSubjectType VoteSubjectTypeInfo
		{
			set
			{
				_voteSubjectTypeInfo = value;
			}
			get { return _voteSubjectTypeInfo; }
		}
		
    }
}


