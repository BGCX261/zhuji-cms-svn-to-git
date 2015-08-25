using System;
using ZhuJi.Library.Text;

namespace ZhuJi.UUMS.Domain
{
    /// <summary>
    /// 方法权限
    /// </summary>
    public class PermissionByMethods
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
		
        private int _explainId;
        /// <summary>
        /// 方法说明编号
        /// </summary>
        public virtual int ExplainId
        {
			set
            {
                _explainId = value;
            }
            get { return _explainId; }
        }
		
        private bool _allowed;
        /// <summary>
        /// 是否允许
        /// </summary>
        public virtual bool Allowed
        {
			set
            {
                _allowed = value;
            }
            get { return _allowed; }
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

        private MethodExplain _explainInfo;
        /// <summary>
        /// 方法说明
        /// </summary>
        public virtual MethodExplain ExplainInfo
        {
            set
            {
                _explainInfo = value;
            }
            get { return _explainInfo; }
        }
		
    }
}


