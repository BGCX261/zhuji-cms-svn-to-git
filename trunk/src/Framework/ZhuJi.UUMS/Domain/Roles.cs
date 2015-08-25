using System;
using ZhuJi.Library.Text;

namespace ZhuJi.UUMS.Domain
{
    /// <summary>
    /// 角色
    /// </summary>
    public class Roles
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
		
        private string _roleName;
        /// <summary>
        /// 角色名称
        /// </summary>
        public virtual string RoleName
        {
			set
            {
                if (value != null && ValidHelper.BytesSize(value) > 30)
                {
                    throw new ArgumentOutOfRangeException("角色名称不能大于30字节！", value, value.ToString());
                }
                _roleName = value;
            }
            get { return _roleName; }
        }

		private int _orderBy;
		/// <summary>
		/// 排序
		/// </summary>
		public virtual int OrderBy
		{
			set { _orderBy = value; }
			get { return _orderBy; }
		}		
    }
}


