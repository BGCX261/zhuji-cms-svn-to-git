using System;
using Castle.DynamicProxy;

namespace ZhuJi.AOP
{
    /// <summary>
    /// Aop操作类
    /// </summary>
    public class Operator
    {
        /// <summary>
        /// 代理方式实例化对象
        /// </summary>
        /// <param name="engine"></param>
        /// <returns></returns>
        public static object WrapInterface(Type engine)
        {
            ProxyInterceptor proxyInterceptor = new ProxyInterceptor();
            ProxyGenerator generator = new ProxyGenerator();
            object proxy = generator.CreateClassProxy(engine, proxyInterceptor);
            return proxy;
        }
    }
}
