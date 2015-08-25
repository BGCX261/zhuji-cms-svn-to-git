using System.Collections.Generic;
using ZhuJi.Library.Text;

namespace ZhuJi.UUMS.NHibernateDAL
{
	/// <summary>
	/// 方法权限数据层
	/// </summary>
	public class PermissionByMethods : ZhuJi.NH.BaseDAL<ZhuJi.UUMS.Domain.PermissionByMethods>, ZhuJi.UUMS.IDAL.IPermissionByMethods
    {
		/// <summary>
		/// 根据角色判断方法是否有权限
		/// </summary>
		/// <param name="className">类名</param>
		/// <param name="methodName">方法名</param>
		/// <param name="rolesId">角色Id</param>
		/// <returns>是否有权限</returns>
		public bool CheckClassMethod(string className, string methodName, string rolesId)
		{
			bool ret = false;
			string where = string.Format("tmp.RolesId = {0}", rolesId);
			IList<ZhuJi.UUMS.Domain.PermissionByMethods> list = base.GetObjects(where, string.Empty);
			foreach (ZhuJi.UUMS.Domain.PermissionByMethods pbm in list)
			{
				string whereMethods = SqlStringHelper.ClearInput(string.Format("tmp.ExplainInfo.Id = {0} And tmp.ClassName Like '{1}' And tmp.MethodName Like '{2}'", pbm.ExplainInfo.Id, className, methodName));
				ZhuJi.UUMS.NHibernateDAL.Methods methodsService = new ZhuJi.UUMS.NHibernateDAL.Methods();
				IList<ZhuJi.UUMS.Domain.Methods> listMethods = methodsService.GetObjects(whereMethods, string.Empty);
				if (listMethods.Count > 0)
				{
					ret = pbm.Allowed;
					break;
				}
			}
			return ret;

		}
    }
}
