using System.Collections.Generic;

namespace ZhuJi.UUMS.IDAL
{
	/// <summary>
	/// ����Ȩ�����ݲ�ӿ� 
	/// </summary>
    public interface IPermissionByMethods : ZhuJi.NH.IBaseDAL<ZhuJi.UUMS.Domain.PermissionByMethods>
    {
        /// <summary>
		/// ���ݽ�ɫ�жϷ����Ƿ���Ȩ��
		/// </summary>
		/// <param name="className">����</param>
		/// <param name="methodName">������</param>
		/// <param name="rolesId">��ɫId</param>
		/// <returns>�Ƿ���Ȩ��</returns>
		bool CheckClassMethod(string className, string methodName, string rolesId);
    }
}
