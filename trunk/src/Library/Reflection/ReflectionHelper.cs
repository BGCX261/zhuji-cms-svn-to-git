using System;
using System.Globalization;
using System.Reflection;

namespace ZhuJi.Library.Reflection
{
    /// <summary>
    /// ���������
    /// </summary>
    public sealed class ReflectionHelper
    {
        private ReflectionHelper()
        {
        }

        #region ��������������ʵ��

        /// <summary>
        /// ��ָ��������������Ĭ�ϵĹ���������һ���������͡�
        /// </summary>
        /// <param name="typeName">����������</param>
        /// <returns>���ص�ʵ����</returns>
        public static object CreateInstance(string typeName)
        {
            return CreateInstance(typeName, typeof (object));
        }

        /// <summary>
        /// ��ָ��������������Ĭ�ϵĹ���������һ�����͡�
        /// </summary>
        /// <param name="typeName">����������</param>
        /// <param name="expectedType">����ʵ�ֵ����͡�</param>
        /// <returns>���ص�ʵ����</returns>
        public static object CreateInstance(string typeName, Type expectedType)
        {
            return CreateInstance(typeName, expectedType, null);
        }

        /// <summary>
        /// ��ָ����������������һ�����͡�
        /// </summary>
        /// <param name="typeName">����������</param>
        /// <param name="expectedType">����ʵ�ֵ����͡�</param>
        /// <param name="args">������������</param>
        /// <returns>���ص�ʵ����</returns>
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
                            // ָ��������δʵ������ӿ�
                            throw new ArgumentException(
                                string.Format(CultureInfo.InvariantCulture, "ָ��������({0})δʵ���������Ľӿ�({1})", t.FullName,
                                              expectedType.FullName), "typeName");
                        }
                        else
                        {
                            // ָ�������Ͳ����������͵�������
                            throw new ArgumentException(
                                string.Format(CultureInfo.InvariantCulture, "ָ��������({0})δʵ������������({1})��������", t.FullName,
                                              expectedType.FullName), "typeName");
                        }
                    }
                }
                else
                {
                    // ָ�������Ͳ�����
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "δ�ҵ�ָ��������({0})", typeName),
                                                "typeName");
                }
            }
            else
            {
                // δָ�����ͻ�ӿڵ�ʵ����
                throw new ArgumentException("δָ�������͵�ʵ����", "typeName");
            }
        }

        #endregion

        #region ��������ȡʵ������ֵ

        /// <summary>
        /// ��������ȡʵ������ֵ��
        /// </summary>
        /// <param name="instance">����ʵ����</param>
        /// <param name="propertyName">��������</param>
        /// <returns>��������ֵ��</returns>
        public static object GetProperty(object instance, string propertyName)
        {
            return GetProperty(instance, propertyName, null);
        }

        /// <summary>
        /// ��������ȡʵ������ֵ��
        /// </summary>
        /// <param name="instance">����ʵ����</param>
        /// <param name="propertyName">��������</param>
        /// <param name="args">���Բ�����</param>
        /// <returns>��������ֵ��</returns>
        public static object GetProperty(object instance, string propertyName, params object[] args)
        {
            if (instance == null)
            {
                throw new ArgumentException("��ȡ����ʱʵ������Ϊ�ա���̬���Կ�����Typeʵ��", "instance");
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
                    throw new ArgumentException("δ����ָ�����ƵĹ�������", pn);
                }
            }
            else
            {
                throw new ArgumentException("����������Ϊ�գ����������Ա���ָ���������", "propertyName");
            }
        }

        #endregion

        /// <summary>
        /// ����������ʵ������ֵ��
        /// </summary>
        /// <param name="instance">����ʵ��</param>
        /// <param name="propertyName">������</param>
        /// <param name="propertyValue">����ֵ</param>
        public static void SetProperty(object instance, string propertyName, object propertyValue)
        {
            if (instance == null)
            {
                throw new ArgumentException("��ȡ����ʱʵ������Ϊ�ա���̬���Կ�����Typeʵ��", "instance");
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

        #region ������ִ��ָ������

        /// <summary>
        /// ������ִ��ָ����û�в����ķ�����
        /// </summary>
        /// <param name="instance">����ʵ����</param>
        /// <param name="methodName">��������</param>
        /// <returns>�������ؽ����</returns>
        public static object Invoke(object instance, string methodName)
        {
            return Invoke(instance, methodName, null);
        }

        /// <summary>
        /// ������ִ��ָ��������
        /// </summary>
        /// <param name="instance">����ʵ����</param>
        /// <param name="methodName">��������</param>
        /// <param name="args">����������</param>
        /// <returns>�������ؽ����</returns>
        public static object Invoke(object instance, string methodName, params object[] args)
        {
            if (instance == null)
            {
                throw new ArgumentException("ִ�з���ʱʵ������Ϊ�ա���̬����������Typeʵ��", "instance");
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
                    throw new ArgumentException("δ����ָ�����ƵĹ�������", methodName);
                }
            }
            else
            {
                throw new ArgumentException("����������Ϊ��", "methodName");
            }
        }

        #endregion
    }
}