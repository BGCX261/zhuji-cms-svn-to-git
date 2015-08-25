using System.Collections.Generic;

namespace ZhuJi.UUMS.IDAL
{
	/// <summary>
	/// 方法权限数据层接口 
	/// </summary>
    public interface IPermissionByMethods : ZhuJi.NH.IBaseDAL<ZhuJi.UUMS.Domain.PermissionByMethods>
    {
        /// <summary>
		/// 根据角色判断方法是否有权限
		/// </summary>
		/// <param name="className">类名</param>
		/// <param name="methodName">方法名</param>
		/// <param name="rolesId">角色Id</param>
		/// <returns>是否有权限</returns>
		bool CheckClassMethod(string className, string methodName, string rolesId);
    }
}
