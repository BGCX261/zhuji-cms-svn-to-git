using System;
using System.Globalization;
using System.Reflection;

namespace ZhuJi.Library.Reflection
{
    /// <summary>
    /// 反射帮助类
    /// </summary>
    public sealed class ReflectionHelper
    {
        private ReflectionHelper()
        {
        }

        #region 按描述建立对象实例

        /// <summary>
        /// 按指定的类型描述以默认的构造器建立一个任意类型。
        /// </summary>
        /// <param name="typeName">类型描述。</param>
        /// <returns>返回的实例。</returns>
        public static object CreateInstance(string typeName)
        {
            return CreateInstance(typeName, typeof (object));
        }

        /// <summary>
        /// 按指定的类型描述以默认的构造器建立一个类型。
        /// </summary>
        /// <param name="typeName">类型描述。</param>
        /// <param name="expectedType">期望实现的类型。</param>
        /// <returns>返回的实例。</returns>
        public static object CreateInstance(string typeName, Type expectedType)
        {
            return CreateInstance(typeName, expectedType, null);
        }

        /// <summary>
        /// 按指定的类型描述建立一个类型。
        /// </summary>
        /// <param name="typeName">类型描述。</param>
        /// <param name="expectedType">期望实现的类型。</param>
        /// <param name="args">构造器参数。</param>
        /// <returns>返回的实例。</returns>
        public static object CreateInstance(string typeName, Type expectedType, params object[] args)
        {
            if (expectedType == null)
            {
                throw new ArgumentNullException("expectedType");
            }

            if (typeName != null)
            {
                Type t = Type.GetType(typeName);
                if (t != null)
                {
                    if (expectedType.IsAssignableFrom(t))
                    {
                        if (args == null)
                        {
                            return Activator.CreateInstance(t);
                        }
                        else
                        {
                            return Activator.CreateInstance(t, args);
                        }
                    }
                    else
                    {
                        if (expectedType.IsInterface)
                        {
                            // 指定的类型未实现所需接口
                            throw new ArgumentException(
                                string.Format(CultureInfo.InvariantCulture, "指定的类型({0})未实现所期望的接口({1})", t.FullName,
                                              expectedType.FullName), "typeName");
                        }
                        else
                        {
                            // 指定的类型不是期望类型的派生类
                            throw new ArgumentException(
                                string.Format(CultureInfo.InvariantCulture, "指定的类型({0})未实现期望的类型({1})的派生类", t.FullName,
                                              expectedType.FullName), "typeName");
                        }
                    }
                }
                else
                {
                    // 指定的类型不存在
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "未找到指定的类型({0})", typeName),
                                                "typeName");
                }
            }
            else
            {
                // 未指定类型或接口的实现者
                throw new ArgumentException("未指定的类型的实现者", "typeName");
            }
        }

        #endregion

        #region 按描述读取实例属性值

        /// <summary>
        /// 按描述读取实例属性值。
        /// </summary>
        /// <param name="instance">对象实例。</param>
        /// <param name="propertyName">属性名。</param>
        /// <returns>返回属性值。</returns>
        public static object GetProperty(object instance, string propertyName)
        {
            return GetProperty(instance, propertyName, null);
        }

        /// <summary>
        /// 按描述读取实例属性值。
        /// </summary>
        /// <param name="instance">对象实例。</param>
        /// <param name="propertyName">属性名。</param>
        /// <param name="args">属性参数表。</param>
        /// <returns>返回属性值。</returns>
        public static object GetProperty(object instance, string propertyName, params object[] args)
        {
            if (instance == null)
            {
                throw new ArgumentException("获取属性时实例不能为空。静态属性可用其Type实例", "instance");
            }
            Type type;
            BindingFlags flag = BindingFlags.IgnoreCase | BindingFlags.Public;
            object inst;
            if (instance is Type)
            {
                type = (Type) instance;
                flag |= BindingFlags.Static;
                inst = null;
            }
            else
            {
                type = instance.GetType();
                flag |= BindingFlags.Instance;
                inst = instance;
            }
            string pn = propertyName;
            if ((args != null && args.Length > 0) && (pn == null || pn.Trim().Length == 0))
            {
                pn = "Item";
            }
            if (pn != null)
            {
                PropertyInfo pi = type.GetProperty(pn, flag);
                if (pi != null)
                {
                    return pi.GetValue(inst, args);
                }
                else
                {
                    throw new ArgumentException("未发现指定名称的公共属性", pn);
                }
            }
            else
            {
                throw new ArgumentException("属性名不可为空，索引器属性必须指定索引序号", "propertyName");
            }
        }

        #endregion

        /// <summary>
        /// 按描述设置实例属性值。
        /// </summary>
        /// <param name="instance">对象实例</param>
        /// <param name="propertyName">属性名</param>
        /// <param name="propertyValue">属性值</param>
        public static void SetProperty(object instance, string propertyName, object propertyValue)
        {
            if (instance == null)
            {
                throw new ArgumentException("获取属性时实例不能为空。静态属性可用其Type实例", "instance");
            }
            Type type = instance.GetType();
            PropertyInfo prop = type.GetProperty(propertyName);
            if (prop != null)
            {
                if (propertyValue == DBNull.Value)
                {
                    propertyValue = null;
                }
                else
                {
                    if (prop.PropertyType != typeof (object))
                    {
                        propertyValue =
                            Convert.ChangeType(propertyValue, prop.PropertyType, CultureInfo.InvariantCulture);
                    }
                }
                type.InvokeMember(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty,
                                  null, instance, new object[] {propertyValue});
            }
        }

        #region 按描述执行指定方法

        /// <summary>
        /// 按描述执行指定的没有参数的方法。
        /// </summary>
        /// <param name="instance">对象实例。</param>
        /// <param name="methodName">方法名。</param>
        /// <returns>方法返回结果。</returns>
        public static object Invoke(object instance, string methodName)
        {
            return Invoke(instance, methodName, null);
        }

        /// <summary>
        /// 按描述执行指定方法。
        /// </summary>
        /// <param name="instance">对象实例。</param>
        /// <param name="methodName">方法名。</param>
        /// <param name="args">方法参数。</param>
        /// <returns>方法返回结果。</returns>
        public static object Invoke(object instance, string methodName, params object[] args)
        {
            if (instance == null)
            {
                throw new ArgumentException("执行方法时实例不能为空。静态方法可用其Type实例", "instance");
            }
            Type t;
            BindingFlags flag = BindingFlags.IgnoreCase | BindingFlags.Public;
            object inst;
            if (instance is Type)
            {
                t = (Type) instance;
                flag |= BindingFlags.Static;
                inst = null;
            }
            else
            {
                t = instance.GetType();
                flag |= BindingFlags.Instance;
                inst = instance;
            }
            if (methodName != null)
            {
                MethodInfo mi = t.GetMethod(methodName, flag);
                if (mi != null)
                {
                    if (args == null)
                    {
                        ParameterInfo[] pis = mi.GetParameters();
                        if (pis.Length == 1)
                        {
                            if (!pis[0].ParameterType.IsValueType)
                            {
                                args = new object[] {null};
                            }
                        }
                    }
                    return mi.Invoke(inst, args);
                }
                else
                {
                    throw new ArgumentException("未发现指定名称的公共方法", methodName);
                }
            }
            else
            {
                throw new ArgumentException("方法名不可为空", "methodName");
            }
        }

        #endregion
    }
}