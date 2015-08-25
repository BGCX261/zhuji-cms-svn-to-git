using System;
using ZhuJi.Library.Text;
using ZhuJi.Library.Security;

namespace ZhuJi.UUMS.Domain
{
    /// <summary>
    /// 用户
    /// </summary>
    public class Users
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

        private int _rolesId;
        /// <summary>
        /// 角色编号
        /// </summary>
        public virtual int RolesId
        {
            set
            {
                _rolesId = value;
            }
            get { return _rolesId; }
        }
		
        private string _username;
        /// <summary>
        /// 用户名称
        /// </summary>
        public virtual string Username
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 30)
                {
                    throw new ArgumentOutOfRangeException("用户名称不能大于30字节！", value, value.ToString());
                }
                _username = value;
            }
            get { return _username; }
        }

        private bool _checkPassword;
        /// <summary>
        /// 是否修改密码
        /// </summary>
        public virtual bool CheckPassword
        {
            set
            {
                _checkPassword = value;
            }
            get { return _checkPassword; }
        }
		
        private string _password;
        /// <summary>
        /// 用户密码
        /// </summary>
        public virtual string Password
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 32)
                {
                    throw new ArgumentOutOfRangeException("用户密码不能大于32字节！", value, value.ToString());
                }
                if (_checkPassword)
                {
                    _password = EncryptHelper.MD5(value, KEY);
                }
                else
                {
                    _password = value;
                }
            }
            get { return _password; }
        }
		
        private string _question;
        /// <summary>
        /// 问题
        /// </summary>
        public virtual string Question
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 50)
                {
                    throw new ArgumentOutOfRangeException("问题不能大于50字节！", value, value.ToString());
                }
                _question = value;
            }
            get { return _question; }
        }
		
        private string _answer;
        /// <summary>
        /// 回答
        /// </summary>
        public virtual string Answer
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 50)
                {
                    throw new ArgumentOutOfRangeException("回答不能大于50字节！", value, value.ToString());
                }
                _answer = value;
            }
            get { return _answer; }
        }
		
        private bool _passed;
        /// <summary>
        /// 通过验证
        /// </summary>
        public virtual bool Passed
        {
			set
            {
                _passed = value;
            }
            get { return _passed; }
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

        private Roles _rolesInfo;
        /// <summary>
        /// 角色
        /// </summary>
        public virtual Roles RolesInfo
        {
            set { _rolesInfo = value; }
            get { return _rolesInfo; }
        }

        #region const
        private const string KEY = "ZhuJi";
        #endregion

    }
}


