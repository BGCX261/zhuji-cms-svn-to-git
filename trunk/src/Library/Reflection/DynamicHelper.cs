using System;
using System.Reflection;
using System.Reflection.Emit;

namespace ZhuJi.Library.Reflection
{
    /// <summary>
    /// 获取值
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="entity">实体</param>
    /// <returns>值</returns>
    public delegate TValue Getter<TValue>(object entity);

    /// <summary>
    /// 设置值
    /// </summary>
    /// <typeparam name="TValue">值类型</typeparam>
    /// <param name="entity">实体</param>
    /// <param name="value">值</param>
    public delegate void Setter<TValue>(object entity, TValue value);

    /// <summary>
    /// 实例对象
    /// </summary>
    /// <typeparam name="TObject">对象类型</typeparam>
    /// <returns>对象</returns>
    public delegate TObject InstantiateObject<TObject>();

    /// <summary>
    /// 获取值
    /// </summary>
    /// <param name="entity">实体</param>
    /// <returns>值</returns>
    public delegate object Getter(object entity);

    /// <summary>
    /// 设置值
    /// </summary>
    /// <param name="entity">实体</param>
    /// <param name="value">值</param>
    public delegate void Setter(object entity, object value);

    /// <summary>
    /// 实例对象
    /// </summary>
    /// <returns>对象</returns>
    public delegate object InstantiateObject();

    /// <summary>
    /// 动态方法帮助类
    /// </summary>
    public sealed class DynamicHelper
    {
        private DynamicHelper()
        {
        }

        #region 对象创建

        /// <summary>
        /// 对象创建
        /// </summary>
        /// <typeparam name="TObject">泛型对象类型</typeparam>
        /// <returns>对象</returns>
        public static InstantiateObject<TObject> CreateInstantiateObject<TObject>()
        {
            Type type = typeof (TObject);
            ConstructorInfo constructorInfo =
                type.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance, null,
                                    new Type[0], null);
            if (constructorInfo == null)
            {
                throw new ApplicationException(
                    string.Format("类{0}必须创建一个空构造(private, internal, protected, protected internal, public)", type));
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
        /// 对象创建
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <returns>对象</returns>
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
                    string.Format("类{0}必须创建一个空构造(private, internal, protected, protected internal, public)", type));
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

        #region 获取属性值

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <typeparam name="TObject">泛型对象类型</typeparam>
        /// <typeparam name="TValue">泛型属性值类型</typeparam>
        /// <param name="propertyInfo">属性</param>
        /// <returns>属性</returns>
        public static Getter<TValue> CreateGetter<TObject, TValue>(PropertyInfo propertyInfo)
        {
            Type type = typeof (TObject);
            return CreateGetter<TValue>(type, propertyInfo);
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <typeparam name="TValue">泛型属性值类型</typeparam>
        /// <param name="type">对象类型</param>
        /// <param name="propertyInfo">属性</param>
        /// <returns>属性</returns>
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
        /// 获取属性值
        /// </summary>
        /// <typeparam name="TObject">泛型对象类型</typeparam>
        /// <param name="propertyInfo">属性</param>
        /// <returns>属性</returns>
        public static Getter CreateGetter<TObject>(PropertyInfo propertyInfo)
        {
            Type type = typeof (TObject);
            return CreateGetter(type, propertyInfo);
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="propertyInfo">属性</param>
        /// <returns>属性</returns>
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
        /// 获取属性值
        /// </summary>
        /// <typeparam name="TObject">泛型对象类型</typeparam>
        /// <typeparam name="TValue">泛型属性值类型</typeparam>
        /// <param name="fieldInfo">属性</param>
        /// <returns>属性</returns>
        public static Getter<TValue> CreateGetter<TObject, TValue>(FieldInfo fieldInfo)
        {
            Type type = typeof (TObject);
            return CreateGetter<TValue>(type, fieldInfo);
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <typeparam name="TValue">泛型属性值类型</typeparam>
        /// <param name="type">对象类型</param>
        /// <param name="fieldInfo">属性</param>
        /// <returns>属性</returns>
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
        /// 获取属性值
        /// </summary>
        /// <typeparam name="TObject">泛型对象类型</typeparam>
        /// <param name="fieldInfo">属性</param>
        /// <returns>属性</returns>
        public static Getter CreateGetter<TObject>(FieldInfo fieldInfo)
        {
            Type type = typeof (TObject);
            return CreateGetter(type, fieldInfo);
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="fieldInfo">属性</param>
        /// <returns>属性</returns>
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

        #region 设置属性值

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <typeparam name="TObject">泛型对象类型</typeparam>
        /// <typeparam name="TValue">泛型属性值类型</typeparam>
        /// <param name="propertyInfo">属性</param>
        /// <returns>属性</returns>
        public static Setter<TValue> CreateSetter<TObject, TValue>(PropertyInfo propertyInfo)
        {
            Type type = typeof (TObject);
            return CreateSetter<TValue>(type, propertyInfo);
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <typeparam name="TValue">泛型属性值类型</typeparam>
        /// <param name="type">对象类型</param>
        /// <param name="propertyInfo">属性</param>
        /// <returns>属性</returns>
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
        /// 设置属性值
        /// </summary>
        /// <typeparam name="TObject">泛型对象类型</typeparam>
        /// <param name="propertyInfo">属性</param>
        /// <returns>属性</returns>
        public static Setter CreateSetter<TObject>(PropertyInfo propertyInfo)
        {
            Type type = typeof (TObject);
            return CreateSetter(type, propertyInfo);
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="propertyInfo">属性</param>
        /// <returns>属性</returns>
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
        /// 设置属性值
        /// </summary>
        /// <typeparam name="TObject">泛型对象类型</typeparam>
        /// <typeparam name="TValue">泛型属性值类型</typeparam>
        /// <param name="fieldInfo">属性</param>
        /// <returns>属性</returns>
        public static Setter<TValue> CreateSetter<TObject, TValue>(FieldInfo fieldInfo)
        {
            Type type = typeof (TObject);
            return CreateSetter<TValue>(type, fieldInfo);
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <typeparam name="TValue">泛型属性值类型</typeparam>
        /// <param name="type">对象类型</param>
        /// <param name="fieldInfo">属性</param>
        /// <returns>属性</returns>
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
        /// 设置属性值
        /// </summary>
        /// <typeparam name="TObject">泛型对象类型</typeparam>
        /// <param name="fieldInfo">属性</param>
        /// <returns>属性</returns>
        public static Setter CreateSetter<TObject>(FieldInfo fieldInfo)
        {
            Type type = typeof (TObject);
            return CreateSetter(type, fieldInfo);
        }

        /// <summary>
        /// 设置属性值
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="fieldInfo">属性</param>
        /// <returns>属性</returns>
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

        #region 内部方法

        /// <summary>
        /// 获取设置属性
        /// </summary>
        /// <typeparam name="TValue">泛型属性值类型</typeparam>
        /// <param name="type">对象类型</param>
        /// <returns>属性</returns>
        private static DynamicMethod CreateGetDynamicMethod<TValue>(Type type)
        {
            return new DynamicMethod("DynamicGet", typeof (TValue), new Type[] {typeof (object)}, type, true);
        }

        /// <summary>
        /// 获取设置属性
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <returns>属性</returns>
        private static DynamicMethod CreateGetDynamicMethod(Type type)
        {
            return new DynamicMethod("DynamicGet", typeof (object), new Type[] {typeof (object)}, type, true);
        }

        /// <summary>
        /// 获取设置属性
        /// </summary>
        /// <typeparam name="TValue">泛型属性值类型</typeparam>
        /// <param name="type">对象类型</param>
        /// <returns>属性</returns>
        private static DynamicMethod CreateSetDynamicMethod<TValue>(Type type)
        {
            return
                new DynamicMethod("DynamicSet", typeof (void), new Type[] {typeof (object), typeof (TValue)}, type, true);
        }

        /// <summary>
        /// 获取设置属性
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <returns>属性</returns>
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