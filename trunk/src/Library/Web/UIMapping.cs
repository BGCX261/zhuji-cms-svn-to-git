using System;
using System.Globalization;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZhuJi.Library.Web
{
    /// <summary>
    /// ����ʵ��ӳ����
    /// </summary>
    public sealed class UIMapping
    {
        private UIMapping()
        {
        }

        /// <summary>
        /// ��ʵ�嵽�ؼ�
        /// </summary>
        /// <param name="entity">ʵ��</param>
        /// <param name="container">�ؼ�</param>
        public static void BindObjectToControls(object entity, Control container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (entity == null) return;

            Type type = entity.GetType();
            PropertyInfo[] propertiesArray = type.GetProperties();

            foreach (PropertyInfo property in propertiesArray)
            {
                Control control = container.FindControl(property.Name);
                if (control == null) continue;

                if (control is ListControl)
                {
                    SetListControl(entity, property, control);
                }
                else
                {
                    SetGeneralControl(entity, property, control);
                }
            }
        }

        /// <summary>
        /// ������ͨ�ؼ�
        /// </summary>
        /// <param name="entity">ʵ��</param>
        /// <param name="property">����</param>
        /// <param name="control">�ؼ�</param>
        private static void SetGeneralControl(object entity, PropertyInfo property, Control control)
        {
            Type controlType = control.GetType();
            PropertyInfo[] controlPropertiesArray = controlType.GetProperties();

            bool success;
            success =
                FindAndSetControlProperty(entity, property, control, controlPropertiesArray, "SelectedDate",
                                          typeof (DateTime));

            if (!success)
                success =
                    FindAndSetControlProperty(entity, property, control, controlPropertiesArray, "Checked",
                                              typeof (bool));

            if (!success)
                success =
                    FindAndSetControlProperty(entity, property, control, controlPropertiesArray, "Value",
                                              typeof (String));

            if (!success)
                FindAndSetControlProperty(entity, property, control, controlPropertiesArray, "Text", typeof (String));
        }

        /// <summary>
        /// �����б����Ϳؼ�
        /// </summary>
        /// <param name="entity">ʵ��</param>
        /// <param name="property">����</param>
        /// <param name="control">�ؼ�</param>
        private static void SetListControl(object entity, PropertyInfo property, Control control)
        {
            try
            {
                ListControl listControl = (ListControl) control;
                listControl.SelectedIndex = -1;
                string propertyValue = property.GetValue(entity, null).ToString();
                ListItem listItem = listControl.Items.FindByValue(propertyValue);
                if (listItem != null) listItem.Selected = true;
            }
            catch
            {
            }
        }

        /// <summary>
        /// �ҵ���Ӧ�ؼ������ÿؼ�����
        /// </summary>
        /// <param name="entity">ʵ��</param>
        /// <param name="property">ʵ������</param>
        /// <param name="control">�ؼ�</param>
        /// <param name="controlPropertiesArray">�ؼ�����</param>
        /// <param name="propertyName">������</param>
        /// <param name="type">��������</param>
        /// <returns></returns>
        private static bool FindAndSetControlProperty(object entity, PropertyInfo property, Control control,
                                                      PropertyInfo[] controlPropertiesArray, string propertyName,
                                                      Type type)
        {
            foreach (PropertyInfo controlProperty in controlPropertiesArray)
            {
                if (controlProperty.Name == propertyName && controlProperty.PropertyType == type)
                {
                    try
                    {
                        controlProperty.SetValue(control,
                                                 Convert.ChangeType(property.GetValue(entity, null), type,
                                                                    CultureInfo.InvariantCulture), null);
                        return true;
                    }
                    catch
                    {
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// �󶨿ؼ���ʵ��
        /// </summary>
        /// <param name="entity">ʵ��</param>
        /// <param name="container">�ؼ�</param>
        public static void BindControlsToObject(object entity, Control container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            if (entity == null) return;

            Type objType = entity.GetType();
            PropertyInfo[] objPropertiesArray = objType.GetProperties();

            foreach (PropertyInfo objProperty in objPropertiesArray)
            {
                Control control = container.FindControl(objProperty.Name.ToLower(CultureInfo.InvariantCulture));
                if (control == null) continue;
                if (control is ListControl)
                {
                    SetListObject(entity, objProperty, control);
                }
                else
                {
                    SetGeneralObject(entity, objProperty, control);
                }
            }
        }

        /// <summary>
        /// ������ͨʵ��
        /// </summary>
        /// <param name="entity">ʵ��</param>
        /// <param name="property">����</param>
        /// <param name="control">�ؼ�</param>
        private static void SetGeneralObject(object entity, PropertyInfo property, Control control)
        {
            Type controlType = control.GetType();
            PropertyInfo[] controlPropertiesArray = controlType.GetProperties();

            bool success;
            success =
                FindAndGetControlProperty(entity, property, control, controlPropertiesArray, "SelectedDate",
                                          typeof (DateTime));

            if (!success)
                success =
                    FindAndGetControlProperty(entity, property, control, controlPropertiesArray, "Checked",
                                              typeof (bool));

            if (!success)
                success =
                    FindAndGetControlProperty(entity, property, control, controlPropertiesArray, "Value",
                                              typeof (String));

            if (!success)
                FindAndGetControlProperty(entity, property, control, controlPropertiesArray, "Text", typeof (String));
        }

        /// <summary>
        /// �����б�����ʵ��
        /// </summary>
        /// <param name="entity">ʵ��</param>
        /// <param name="property">����</param>
        /// <param name="control">�ؼ�</param>
        private static void SetListObject(object entity, PropertyInfo property, Control control)
        {
            ListControl listControl = (ListControl) control;
            if (listControl.SelectedItem != null)
                property.SetValue(entity,
                                  Convert.ChangeType(listControl.SelectedItem.Value, property.PropertyType,
                                                     CultureInfo.InvariantCulture), null);
        }

        /// <summary>
        /// �ҵ���Ӧ�ؼ����õ��ؼ�����
        /// </summary>
        /// <param name="entity">ʵ��</param>
        /// <param name="property">ʵ������</param>
        /// <param name="control">�ؼ�</param>
        /// <param name="controlPropertiesArray">�ؼ�����</param>
        /// <param name="propertyName">������</param>
        /// <param name="type">��������</param>
        /// <returns></returns>
        private static bool FindAndGetControlProperty(object entity, PropertyInfo property, Control control,
                                                      PropertyInfo[] controlPropertiesArray, string propertyName,
                                                      Type type)
        {
            foreach (PropertyInfo controlProperty in controlPropertiesArray)
            {
                if (controlProperty.Name == propertyName && controlProperty.PropertyType == type)
                {
                    try
                    {
                        property.SetValue(entity,
                                          Convert.ChangeType(controlProperty.GetValue(control, null),
                                                             property.PropertyType, CultureInfo.InvariantCulture), null);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}