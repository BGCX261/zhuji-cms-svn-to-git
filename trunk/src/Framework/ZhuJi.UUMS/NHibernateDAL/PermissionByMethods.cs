using System.Collections.Generic;
using ZhuJi.Library.Text;

namespace ZhuJi.UUMS.NHibernateDAL
{
	/// <summary>
	/// ����Ȩ�����ݲ�
	/// </summary>
	public class PermissionByMethods : ZhuJi.NH.BaseDAL<ZhuJi.UUMS.Domain.PermissionByMethods>, ZhuJi.UUMS.IDAL.IPermissionByMethods
    {
		/// <summary>
		/// ���ݽ�ɫ�жϷ����Ƿ���Ȩ��
		/// </summary>
		/// <param name="className">����</param>
		/// <param name="methodName">������</param>
		/// <param name="rolesId">��ɫId</param>
		/// <returns>�Ƿ���Ȩ��</returns>
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
