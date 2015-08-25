using System;
using ZhuJi.Library.Text;

namespace ZhuJi.UUMS.Domain
{
    /// <summary>
    /// 资源权限
    /// </summary>
    public class PermissionByResource
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
		
        private int _resourcesId;
        /// <summary>
        /// 资源编号
        /// </summary>
        public virtual int ResourcesId
        {
			set
            {
                _resourcesId = value;
            }
            get { return _resourcesId; }
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

        private Resources _resourcesInfo;
        /// <summary>
        /// 资源
        /// </summary>
        public virtual Resources ResourcesInfo
        {
            set { _resourcesInfo = value; }
            get { return _resourcesInfo; }
        }
		
    }
}


