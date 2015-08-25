using System.Web.UI;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace ZhuJi.UUMS.NHibernateDAL
{
	/// <summary>
	/// ��ԴȨ�����ݲ�
	/// </summary>
	public class PermissionByResource : ZhuJi.NH.BaseDAL<ZhuJi.UUMS.Domain.PermissionByResource>, ZhuJi.UUMS.IDAL.IPermissionByResource
    {
		/// <summary>
		/// ���ݽ�ɫ�ж���Դ�Ƿ���Ȩ��
		/// </summary>
		/// <param name="control">�ؼ�</param>
		/// <param name="rolesId">��ɫId</param>
		public void CheckControlResource(Control control, string rolesId)
		{
			string[] controls = control.ToString().Split('.');
			string where = string.Format("tmp.RolesId = {0}", rolesId);
			IList<ZhuJi.UUMS.Domain.PermissionByResource> list = base.GetObjects(where, string.Empty);
			foreach (ZhuJi.UUMS.Domain.PermissionByResource pbr in list)
			{
				string whereControls = string.Format("tmp.ResourcesInfo.Id = {0} And tmp.PageName Like '{1}'", pbr.ResourcesInfo.Id, controls[1]);
				ZhuJi.UUMS.IDAL.IControls controlsService = new ZhuJi.UUMS.NHibernateDAL.Controls();
				IList<ZhuJi.UUMS.Domain.Controls> listControls = controlsService.GetObjects(whereControls, string.Empty);
				foreach (ZhuJi.UUMS.Domain.Controls c in listControls)
				{
					Bind(control, c.ControlsTypeInfo.Value, c.ControlName, c.ControlsAttributeInfo.Value, pbr.Allowed);
				}
			}
		}

		/// <summary>
		/// �󶨿ؼ�����
		/// </summary>
		/// <param name="control">�ؼ�</param>
		/// <param name="controlsType">�ؼ�����</param>
		/// <param name="controlsName">�ؼ�����</param>
		/// <param name="controlsAttribute">�ؼ�����</param>
		/// <param name="allowed">�ؼ�Ȩ��</param>
		private void Bind(Control control, string controlsType, string controlsName, string controlsAttribute, object allowed)
		{
			try
			{
				string assemblyQualifiedName = typeof(Control).AssemblyQualifiedName;
				string assemblyInformation = assemblyQualifiedName.Substring(assemblyQualifiedName.IndexOf(","));
				Type type = Type.GetType(controlsType + assemblyInformation);
				PropertyInfo propertyInfo = type.GetProperty(controlsAttribute);
				Control controlFindControl = control.FindControl(controlsName);
				propertyInfo.SetValue(controlFindControl, allowed, null);
			}
			catch
			{
			}
		}
    }
}
