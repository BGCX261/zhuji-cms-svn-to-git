using System.Collections.Generic;
using System.Web.UI;

namespace ZhuJi.UUMS.IDAL
{
	/// <summary>
	/// 资源权限数据层接口
	/// </summary>
    public interface IPermissionByResource : ZhuJi.NH.IBaseDAL<ZhuJi.UUMS.Domain.PermissionByResource>
    {
        /// <summary>
		/// 根据角色判断资源是否有权限
		/// </summary>
		/// <param name="control">控件</param>
		/// <param name="rolesId">角色Id</param>
		void CheckControlResource(Control control, string rolesId);
    }
}
