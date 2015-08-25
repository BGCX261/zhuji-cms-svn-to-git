using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Modules.CommentModule.Domain
{
    /// <summary>
	/// 评论
    /// </summary>
    public class Review
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
		
        private string _title;
        /// <summary>
		/// 标题
        /// </summary>
        public virtual string Title
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
					throw new ArgumentOutOfRangeException("标题不能大于100字节！", value, value.ToString());
                }
                _title = value;
            }
            get { return _title; }
        }
		
        private string _content;
        /// <summary>
		/// 内容
        /// </summary>
        public virtual string Content
        {
			set
            {
                _content = value;
            }
            get { return _content; }
        }
		
        private DateTime _postDate;
        /// <summary>
		/// 发表时间
        /// </summary>
        public virtual DateTime PostDate
        {
			set
            {
                _postDate = value;
            }
            get { return _postDate; }
        }
		
        private DateTime _lastDate;
        /// <summary>
		/// 最后更新
        /// </summary>
        public virtual DateTime LastDate
        {
			set
            {
                _lastDate = value;
            }
            get { return _lastDate; }
        }
		
        private int _tops;
        /// <summary>
		/// 置顶数
        /// </summary>
        public virtual int Tops
        {
			set
            {
                _tops = value;
            }
            get { return _tops; }
        }
		
        private bool _isHidden;
        /// <summary>
		/// 是否隐藏内容
        /// </summary>
        public virtual bool IsHidden
        {
			set
            {
                _isHidden = value;
            }
            get { return _isHidden; }
        }
		
        private bool _isClose;
        /// <summary>
		/// 是否关闭回复
        /// </summary>
        public virtual bool IsClose
        {
			set
            {
                _isClose = value;
            }
            get { return _isClose; }
        }
		
        private string _createdByUser;
        /// <summary>
		/// 提交用户
        /// </summary>
        public virtual string CreatedByUser
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 30)
                {
					throw new ArgumentOutOfRangeException("提交用户不能大于30字节！", value, value.ToString());
                }
                _createdByUser = value;
            }
            get { return _createdByUser; }
        }
		
        private string _createdByIp;
        /// <summary>
		/// 提交IP
        /// </summary>
        public virtual string CreatedByIp
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 15)
                {
					throw new ArgumentOutOfRangeException("提交IP不能大于15字节！", value, value.ToString());
                }
                _createdByIp = value;
            }
            get { return _createdByIp; }
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
		
    }
}


