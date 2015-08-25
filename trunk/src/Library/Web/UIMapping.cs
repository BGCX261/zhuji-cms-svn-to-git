using System;
using System.Globalization;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZhuJi.Library.Web
{
    /// <summary>
    /// 界面实体映射类
    /// </summary>
    public sealed class UIMapping
    {
        private UIMapping()
        {
        }

        /// <summary>
        /// 绑定实体到控件
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="container">控件</param>
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
        /// 设置普通控件
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="property">属性</param>
        /// <param name="control">控件</param>
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
        /// 设置列表类型控件
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="property">属性</param>
        /// <param name="control">控件</param>
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
        /// 找到对应控件并设置控件属性
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="property">实体属性</param>
        /// <param name="control">控件</param>
        /// <param name="controlPropertiesArray">控件属性</param>
        /// <param name="propertyName">属性名</param>
        /// <param name="type">属性类型</param>
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
        /// 绑定控件到实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="container">控件</param>
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
        /// 设置普通实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="property">属性</param>
        /// <param name="control">控件</param>
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
        /// 设置列表类型实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="property">属性</param>
        /// <param name="control">控件</param>
        private static void SetListObject(object entity, PropertyInfo property, Control control)
        {
            ListControl listControl = (ListControl) control;
            if (listControl.SelectedItem != null)
                property.SetValue(entity,
                                  Convert.ChangeType(listControl.SelectedItem.Value, property.PropertyType,
                                                     CultureInfo.InvariantCulture), null);
        }

        /// <summary>
        /// 找到对应控件并得到控件属性
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="property">实体属性</param>
        /// <param name="control">控件</param>
        /// <param name="controlPropertiesArray">控件属性</param>
        /// <param name="propertyName">属性名</param>
        /// <param name="type">属性类型</param>
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