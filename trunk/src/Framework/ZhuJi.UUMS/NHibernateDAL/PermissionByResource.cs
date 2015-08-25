using System.Web.UI;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace ZhuJi.UUMS.NHibernateDAL
{
	/// <summary>
	/// 资源权限数据层
	/// </summary>
	public class PermissionByResource : ZhuJi.NH.BaseDAL<ZhuJi.UUMS.Domain.PermissionByResource>, ZhuJi.UUMS.IDAL.IPermissionByResource
    {
		/// <summary>
		/// 根据角色判断资源是否有权限
		/// </summary>
		/// <param name="control">控件</param>
		/// <param name="rolesId">角色Id</param>
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
		/// 绑定控件属性
		/// </summary>
		/// <param name="control">控件</param>
		/// <param name="controlsType">控件类型</param>
		/// <param name="controlsName">控件名称</param>
		/// <param name="controlsAttribute">控件属性</param>
		/// <param name="allowed">控件权限</param>
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
