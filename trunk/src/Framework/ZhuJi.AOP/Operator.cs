using System;
using Castle.DynamicProxy;

namespace ZhuJi.AOP
{
    /// <summary>
    /// Aop������
    /// </summary>
    public class Operator
    {
        /// <summary>
        /// ����ʽʵ��������
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
