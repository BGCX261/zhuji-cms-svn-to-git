using System;
using System.Reflection;
using System.Reflection.Emit;

namespace ZhuJi.Library.Reflection
{
    /// <summary>
    /// ��ȡֵ
    /// </summary>
    /// <typeparam name="TValue">ֵ����</typeparam>
    /// <param name="entity">ʵ��</param>
    /// <returns>ֵ</returns>
    public delegate TValue Getter<TValue>(object entity);

    /// <summary>
    /// ����ֵ
    /// </summary>
    /// <typeparam name="TValue">ֵ����</typeparam>
    /// <param name="entity">ʵ��</param>
    /// <param name="value">ֵ</param>
    public delegate void Setter<TValue>(object entity, TValue value);

    /// <summary>
    /// ʵ������
    /// </summary>
    /// <typeparam name="TObject">��������</typeparam>
    /// <returns>����</returns>
    public delegate TObject InstantiateObject<TObject>();

    /// <summary>
    /// ��ȡֵ
    /// </summary>
    /// <param name="entity">ʵ��</param>
    /// <returns>ֵ</returns>
    public delegate object Getter(object entity);

    /// <summary>
    /// ����ֵ
    /// </summary>
    /// <param name="entity">ʵ��</param>
    /// <param name="value">ֵ</param>
    public delegate void Setter(object entity, object value);

    /// <summary>
    /// ʵ������
    /// </summary>
    /// <returns>����</returns>
    public delegate object InstantiateObject();

    /// <summary>
    /// ��̬����������
    /// </summary>
    public sealed class DynamicHelper
    {
        private DynamicHelper()
        {
        }

        #region ���󴴽�

        /// <summary>
        /// ���󴴽�
        /// </summary>
        /// <typeparam name="TObject">���Ͷ�������</typeparam>
        /// <returns>����</returns>
        public static InstantiateObject<TObject> CreateInstantiateObject<TObject>()
        {
            Type type = typeof (TObject);
            ConstructorInfo constructorInfo =
                type.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null,
                                    new Type[0], null);
            if (constructorInfo == null)
            {
                throw new ApplicationException(
                    string.Format("��{0}���봴��һ���չ���(private, internal, protected, protected internal, public)", type));
            }

            DynamicMethod dynamicMethod =
                new DynamicMethod("InstantiateObject", MethodAttributes.Static | MethodAttributes.Public,
                                  CallingConventions.Standard, type, null, type, true);
            ILGenerator generator = dynamicMethod.GetILGenerator();

            generator.Emit(OpCodes.Newobj, constructorInfo);
            generator.Emit(OpCodes.Ret);

            return (InstantiateObject<TObject>) dynamicMethod.CreateDelegate(typeof (InstantiateObject<TObject>));
        }

        /// <summary>
        /// ���󴴽�
        /// </summary>
        /// <param name="type">��������</param>
        /// <returns>����</returns>
        public static InstantiateObject CreateInstantiateObject(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            ConstructorInfo constructorInfo =
                type.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null,
                                    new Type[0], null);
            if (constructorInfo == null)
            {
                throw new ApplicationException(
                    string.Format("��{0}���봴��һ���չ���(private, internal, protected, protected internal, public)", type));
            }

            DynamicMethod dynamicMethod =
                new DynamicMethod("InstantiateObject", MethodAttributes.Static | MethodAttributes.Public,
                                  CallingConventions.Standard, typeof (object), null, type, true);
            ILGenerator generator = dynamicMethod.GetILGenerator();
            generator.Emit(OpCodes.Newobj, constructorInfo);
            generator.Emit(OpCodes.Ret);
            return (InstantiateObject) dynamicMethod.CreateDelegate(typeof (InstantiateObject));
        }

        #endregion

        #region ��ȡ����ֵ

        /// <summary>
        /// ��ȡ����ֵ
        /// </summary>
        /// <typeparam name="TObject">���Ͷ�������</typeparam>
        /// <typeparam name="TValue">��������ֵ����</typeparam>
        /// <param name="propertyInfo">����</param>
        /// <returns>����</returns>
        public static Getter<TValue> CreateGetter<TObject, TValue>(PropertyInfo propertyInfo)
        {
            Type type = typeof (TObject);
            return CreateGetter<TValue>(type, propertyInfo);
        }

        /// <summary>
        /// ��ȡ����ֵ
        /// </summary>
        /// <typeparam name="TValue">��������ֵ����</typeparam>
        /// <param name="type">��������</param>
        /// <param name="propertyInfo">����</param>
        /// <returns>����</returns>
        public static Getter<TValue> CreateGetter<TValue>(Type type, PropertyInfo propertyInfo)
        {
            MethodInfo getMethodInfo = propertyInfo.GetGetMethod(true);
            DynamicMethod dynamicGet = CreateGetDynamicMethod<TValue>(type);
            ILGenerator getGenerator = dynamicGet.GetILGenerator();

            getGenerator.Emit(OpCodes.Ldarg_0);
            getGenerator.Emit(OpCodes.Call, getMethodInfo);
            BoxIfNeeded(getMethodInfo.ReturnType, getGenerator);
            getGenerator.Emit(OpCodes.Ret);

            return (Getter<TValue>) dynamicGet.CreateDelegate(typeof (Getter<TValue>));
        }

        /// <summary>
        /// ��ȡ����ֵ
        /// </summary>
        /// <typeparam name="TObject">���Ͷ�������</typeparam>
        /// <param name="propertyInfo">����</param>
        /// <returns>����</returns>
        public static Getter CreateGetter<TObject>(PropertyInfo propertyInfo)
        {
            Type type = typeof (TObject);
            return CreateGetter(type, propertyInfo);
        }

        /// <summary>
        /// ��ȡ����ֵ
        /// </summary>
        /// <param name="type">��������</param>
        /// <param name="propertyInfo">����</param>
        /// <returns>����</returns>
        public static Getter CreateGetter(Type type, PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                throw new ArgumentNullException("propertyInfo");
            }

            MethodInfo getMethodInfo = propertyInfo.GetGetMethod(true);
            DynamicMethod dynamicGet = CreateGetDynamicMethod(type);
            ILGenerator getGenerator = dynamicGet.GetILGenerator();

            getGenerator.Emit(OpCodes.Ldarg_0);
            getGenerator.Emit(OpCodes.Call, getMethodInfo);
            BoxIfNeeded(getMethodInfo.ReturnType, getGenerator);
            getGenerator.Emit(OpCodes.Ret);

            return (Getter) dynamicGet.CreateDelegate(typeof (Getter));
        }

        /// <summary>
        /// ��ȡ����ֵ
        /// </summary>
        /// <typeparam name="TObject">���Ͷ�������</typeparam>
        /// <typeparam name="TValue">��������ֵ����</typeparam>
        /// <param name="fieldInfo">����</param>
        /// <returns>����</returns>
        public static Getter<TValue> CreateGetter<TObject, TValue>(FieldInfo fieldInfo)
        {
            Type type = typeof (TObject);
            return CreateGetter<TValue>(type, fieldInfo);
        }

        /// <summary>
        /// ��ȡ����ֵ
        /// </summary>
        /// <typeparam name="TValue">��������ֵ����</typeparam>
        /// <param name="type">��������</param>
        /// <param name="fieldInfo">����</param>
        /// <returns>����</returns>
        public static Getter<TValue> CreateGetter<TValue>(Type type, FieldInfo fieldInfo)
        {
            DynamicMethod dynamicGet = CreateGetDynamicMethod<TValue>(type);
            ILGenerator getGenerator = dynamicGet.GetILGenerator();

            getGenerator.Emit(OpCodes.Ldarg_0);
            getGenerator.Emit(OpCodes.Ldfld, fieldInfo);
            BoxIfNeeded(fieldInfo.FieldType, getGenerator);
            getGenerator.Emit(OpCodes.Ret);

            return (Getter<TValue>) dynamicGet.CreateDelegate(typeof (Getter<TValue>));
        }

        /// <summary>
        /// ��ȡ����ֵ
        /// </summary>
        /// <typeparam name="TObject">���Ͷ�������</typeparam>
        /// <param name="fieldInfo">����</param>
        /// <returns>����</returns>
        public static Getter CreateGetter<TObject>(FieldInfo fieldInfo)
        {
            Type type = typeof (TObject);
            return CreateGetter(type, fieldInfo);
        }

        /// <summary>
        /// ��ȡ����ֵ
        /// </summary>
        /// <param name="type">��������</param>
        /// <param name="fieldInfo">����</param>
        /// <returns>����</returns>
        public static Getter CreateGetter(Type type, FieldInfo fieldInfo)
        {
            if (fieldInfo == null)
            {
                throw new ArgumentNullException("fieldInfo");
            }

            DynamicMethod dynamicGet = CreateGetDynamicMethod(type);
            ILGenerator getGenerator = dynamicGet.GetILGenerator();

            getGenerator.Emit(OpCodes.Ldarg_0);
            getGenerator.Emit(OpCodes.Ldfld, fieldInfo);
            BoxIfNeeded(fieldInfo.FieldType, getGenerator);
            getGenerator.Emit(OpCodes.Ret);

            return (Getter) dynamicGet.CreateDelegate(typeof (Getter));
        }

        #endregion

        #region ��������ֵ

        /// <summary>
        /// ��������ֵ
        /// </summary>
        /// <typeparam name="TObject">���Ͷ�������</typeparam>
        /// <typeparam name="TValue">��������ֵ����</typeparam>
        /// <param name="propertyInfo">����</param>
        /// <returns>����</returns>
        public static Setter<TValue> CreateSetter<TObject, TValue>(PropertyInfo propertyInfo)
        {
            Type type = typeof (TObject);
            return CreateSetter<TValue>(type, propertyInfo);
        }

        /// <summary>
        /// ��������ֵ
        /// </summary>
        /// <typeparam name="TValue">��������ֵ����</typeparam>
        /// <param name="type">��������</param>
        /// <param name="propertyInfo">����</param>
        /// <returns>����</returns>
        public static Setter<TValue> CreateSetter<TValue>(Type type, PropertyInfo propertyInfo)
        {
            MethodInfo setMethodInfo = propertyInfo.GetSetMethod(true);
            DynamicMethod dynamicSet = CreateSetDynamicMethod<TValue>(type);
            ILGenerator setGenerator = dynamicSet.GetILGenerator();

            setGenerator.Emit(OpCodes.Ldarg_0);
            setGenerator.Emit(OpCodes.Ldarg_1);
            UnboxIfNeeded(setMethodInfo.GetParameters()[0].ParameterType, setGenerator);
            setGenerator.Emit(OpCodes.Call, setMethodInfo);
            setGenerator.Emit(OpCodes.Ret);

            return (Setter<TValue>) dynamicSet.CreateDelegate(typeof (Setter<TValue>));
        }

        /// <summary>
        /// ��������ֵ
        /// </summary>
        /// <typeparam name="TObject">���Ͷ�������</typeparam>
        /// <param name="propertyInfo">����</param>
        /// <returns>����</returns>
        public static Setter CreateSetter<TObject>(PropertyInfo propertyInfo)
        {
            Type type = typeof (TObject);
            return CreateSetter(type, propertyInfo);
        }

        /// <summary>
        /// ��������ֵ
        /// </summary>
        /// <param name="type">��������</param>
        /// <param name="propertyInfo">����</param>
        /// <returns>����</returns>
        public static Setter CreateSetter(Type type, PropertyInfo propertyInfo)
        {
            if (propertyInfo == null)
            {
                throw new ArgumentNullException("propertyInfo");
            }

            MethodInfo setMethodInfo = propertyInfo.GetSetMethod(true);
            DynamicMethod dynamicSet = CreateSetDynamicMethod(type);
            ILGenerator setGenerator = dynamicSet.GetILGenerator();

            setGenerator.Emit(OpCodes.Ldarg_0);
            setGenerator.Emit(OpCodes.Ldarg_1);
            UnboxIfNeeded(setMethodInfo.GetParameters()[0].ParameterType, setGenerator);
            setGenerator.Emit(OpCodes.Call, setMethodInfo);
            setGenerator.Emit(OpCodes.Ret);

            return (Setter) dynamicSet.CreateDelegate(typeof (Setter));
        }

        /// <summary>
        /// ��������ֵ
        /// </summary>
        /// <typeparam name="TObject">���Ͷ�������</typeparam>
        /// <typeparam name="TValue">��������ֵ����</typeparam>
        /// <param name="fieldInfo">����</param>
        /// <returns>����</returns>
        public static Setter<TValue> CreateSetter<TObject, TValue>(FieldInfo fieldInfo)
        {
            Type type = typeof (TObject);
            return CreateSetter<TValue>(type, fieldInfo);
        }

        /// <summary>
        /// ��������ֵ
        /// </summary>
        /// <typeparam name="TValue">��������ֵ����</typeparam>
        /// <param name="type">��������</param>
        /// <param name="fieldInfo">����</param>
        /// <returns>����</returns>
        public static Setter<TValue> CreateSetter<TValue>(Type type, FieldInfo fieldInfo)
        {
            DynamicMethod dynamicSet = CreateSetDynamicMethod<TValue>(type);
            ILGenerator setGenerator = dynamicSet.GetILGenerator();

            setGenerator.Emit(OpCodes.Ldarg_0);
            setGenerator.Emit(OpCodes.Ldarg_1);
            UnboxIfNeeded(fieldInfo.FieldType, setGenerator);
            setGenerator.Emit(OpCodes.Stfld, fieldInfo);
            setGenerator.Emit(OpCodes.Ret);

            return (Setter<TValue>) dynamicSet.CreateDelegate(typeof (Setter<TValue>));
        }

        /// <summary>
        /// ��������ֵ
        /// </summary>
        /// <typeparam name="TObject">���Ͷ�������</typeparam>
        /// <param name="fieldInfo">����</param>
        /// <returns>����</returns>
        public static Setter CreateSetter<TObject>(FieldInfo fieldInfo)
        {
            Type type = typeof (TObject);
            return CreateSetter(type, fieldInfo);
        }

        /// <summary>
        /// ��������ֵ
        /// </summary>
        /// <param name="type">��������</param>
        /// <param name="fieldInfo">����</param>
        /// <returns>����</returns>
        public static Setter CreateSetter(Type type, FieldInfo fieldInfo)
        {
            if (fieldInfo == null)
            {
                throw new ArgumentNullException("fieldInfo");
            }

            DynamicMethod dynamicSet = CreateSetDynamicMethod(type);
            ILGenerator setGenerator = dynamicSet.GetILGenerator();

            setGenerator.Emit(OpCodes.Ldarg_0);
            setGenerator.Emit(OpCodes.Ldarg_1);
            UnboxIfNeeded(fieldInfo.FieldType, setGenerator);
            setGenerator.Emit(OpCodes.Stfld, fieldInfo);
            setGenerator.Emit(OpCodes.Ret);

            return (Setter) dynamicSet.CreateDelegate(typeof (Setter));
        }

        #endregion

        #region �ڲ�����

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <typeparam name="TValue">��������ֵ����</typeparam>
        /// <param name="type">��������</param>
        /// <returns>����</returns>
        private static DynamicMethod CreateGetDynamicMethod<TValue>(Type type)
        {
            return new DynamicMethod("DynamicGet", typeof (TValue), new Type[] {typeof (object)}, type, true);
        }

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="type">��������</param>
        /// <returns>����</returns>
        private static DynamicMethod CreateGetDynamicMethod(Type type)
        {
            return new DynamicMethod("DynamicGet", typeof (object), new Type[] {typeof (object)}, type, true);
        }

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <typeparam name="TValue">��������ֵ����</typeparam>
        /// <param name="type">��������</param>
        /// <returns>����</returns>
        private static DynamicMethod CreateSetDynamicMethod<TValue>(Type type)
        {
            return
                new DynamicMethod("DynamicSet", typeof (void), new Type[] {typeof (object), typeof (TValue)}, type, true);
        }

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="type">��������</param>
        /// <returns>����</returns>
        private static DynamicMethod CreateSetDynamicMethod(Type type)
        {
            return
                new DynamicMethod("DynamicSet", typeof (void), new Type[] {typeof (object), typeof (object)}, type, true);
        }

        private static void BoxIfNeeded(Type type, ILGenerator generator)
        {
            if (type.IsValueType)
            {
                generator.Emit(OpCodes.Box, type);
            }
        }

        private static void UnboxIfNeeded(Type type, ILGenerator generator)
        {
            if (type.IsValueType)
            {
                generator.Emit(OpCodes.Unbox_Any, type);
            }
        }

        #endregion
    }
}