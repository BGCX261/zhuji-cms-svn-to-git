using System;
using ZhuJi.Library.Text;

namespace ZhuJi.UUMS.Domain
{
    /// <summary>
    /// PermissionByCommon
    /// </summary>
    public class PermissionByCommon
    {
        private int _id;
        /// <summary>
        /// Id
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
        /// RolesId
        /// </summary>
        public virtual int RolesId
        {
			set
            {
                _rolesId = value;
            }
            get { return _rolesId; }
        }
		
        private bool _searchALL;
        /// <summary>
        /// SearchALL
        /// </summary>
        public virtual bool SearchALL
        {
			set
            {
                _searchALL = value;
            }
            get { return _searchALL; }
        }
		
    }
}


