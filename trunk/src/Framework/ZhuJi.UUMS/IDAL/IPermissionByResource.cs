using System.Collections.Generic;
using System.Web.UI;

namespace ZhuJi.UUMS.IDAL
{
	/// <summary>
	/// ��ԴȨ�����ݲ�ӿ�
	/// </summary>
    public interface IPermissionByResource : ZhuJi.NH.IBaseDAL<ZhuJi.UUMS.Domain.PermissionByResource>
    {
        /// <summary>
		/// ���ݽ�ɫ�ж���Դ�Ƿ���Ȩ��
		/// </summary>
		/// <param name="control">�ؼ�</param>
		/// <param name="rolesId">��ɫId</param>
		void CheckControlResource(Control control, string rolesId);
    }
}
