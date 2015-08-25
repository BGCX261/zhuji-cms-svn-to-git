using System;
using ZhuJi.Library.Text;

namespace ZhuJi.Log.Domain
{
    /// <summary>
    /// 日志
    /// </summary>
    public class Logging
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
		
        private int _type;
        /// <summary>
        /// 类型
        /// </summary>
        public virtual int Type
        {
			set
            {
                _type = value;
            }
            get { return _type; }
        }
		
        private int _class;
        /// <summary>
        /// 类别
        /// </summary>
        public virtual int Class
        {
			set
            {
                _class = value;
            }
            get { return _class; }
        }
		
        private string _source;
        /// <summary>
        /// 来源
        /// </summary>
        public virtual string Source
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 100)
                {
                    throw new ArgumentOutOfRangeException("来源不能大于100字节！", value, value.ToString());
                }
                _source = value;
            }
            get { return _source; }
        }
		
        private string _description;
        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description
        {
			set
            {
                _description = value;
            }
            get { return _description; }
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
		
        private DateTime _createdByDate;
        /// <summary>
        /// 提交时间
        /// </summary>
        public virtual DateTime CreatedByDate
        {
			set
            {
                _createdByDate = value;
            }
            get { return _createdByDate; }
        }
		
    }
}


