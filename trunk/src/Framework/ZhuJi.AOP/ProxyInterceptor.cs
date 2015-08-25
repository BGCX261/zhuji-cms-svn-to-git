using System;
using System.Globalization;
using System.Configuration;
using Castle.DynamicProxy;
using ZhuJi.Library.Globalization;
using System.Transactions;

namespace ZhuJi.AOP
{
	/// <summary>
	/// 拦截器
	/// </summary>
    public class ProxyInterceptor : StandardInterceptor
    {
        #region 属性
        /// <summary>
        /// 是否开启记录日志
        /// </summary>
        public bool IsOperateLog
        {
            get
            {
                string isOperateLog = ConfigurationManager.AppSettings["ZhuJi.AOP.IsOperateLog"];
                return string.IsNullOrEmpty(isOperateLog) ? false : Convert.ToBoolean(isOperateLog, CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// 是否开启记录日志
        /// </summary>
        public bool IsErrorLog
        {
            get
            {
                string isErrorLog = ConfigurationManager.AppSettings["ZhuJi.AOP.IsErrorLog"];
                return string.IsNullOrEmpty(isErrorLog) ? false : Convert.ToBoolean(isErrorLog, CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// 是否开启应用事务
        /// </summary>
        public bool IsTransaction
        {
            get
            {
                string isTransaction = ConfigurationManager.AppSettings["ZhuJi.AOP.IsTransaction"];
                return string.IsNullOrEmpty(isTransaction) ? false : Convert.ToBoolean(isTransaction, CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// 是否开启权限判断
        /// </summary>
        public bool IsPermission
        {
            get
            {
                string isPermission = ConfigurationManager.AppSettings["ZhuJi.AOP.IsPermission"];
                return string.IsNullOrEmpty(isPermission) ? false : Convert.ToBoolean(isPermission, CultureInfo.InvariantCulture);
            }
        }
        #endregion

        /// <summary>
        /// 前置拦截
        /// </summary>
        /// <param name="invocation">IInvocation</param>
        /// <param name="args">参数</param>
        protected override void PreProceed(IInvocation invocation, params object[] args)
        {
            
            //日志判断
            if (IsOperateLog)
            {
				ZhuJi.Log.IDAL.ILogging log = new ZhuJi.Log.NHibernateDAL.Logging();
                log.WriteEntry(string.Format("{0} {1}.{2}", "PreProceed", invocation.Method.DeclaringType, invocation.Method.Name));
            }

            //权限判断类
            if (IsPermission)
            {
                ZhuJi.UUMS.IDAL.IPermissionByMethods permission = new ZhuJi.UUMS.NHibernateDAL.PermissionByMethods();
                string className = invocation.Method.DeclaringType.ToString();
                string methodName = invocation.Method.Name;
                if (permission.CheckClassMethod(className, methodName, GlobalHelper.RolesId))
                {
                    base.PreProceed(invocation, args);
                }
                else
                {
                    throw new Exception("您没有相应权限！");
                }
            }
            else
            {
                base.PreProceed(invocation, args);
            }
        }

        /// <summary>
        /// 后置拦截
        /// </summary>
        /// <param name="invocation">IInvocation</param>
        /// <param name="returnValue">方法</param>
        /// <param name="arguments">参数</param>
        protected override void PostProceed(IInvocation invocation, ref object returnValue, params object[] arguments)
        {
            
            //日志判断
            if (IsOperateLog)
            {
                ZhuJi.Log.IDAL.ILogging log = new ZhuJi.Log.NHibernateDAL.Logging();
                log.WriteEntry(string.Format("{0} {1}.{2}", "PostProceed", invocation.Method.DeclaringType, invocation.Method.Name));
            }
            base.PostProceed(invocation, ref returnValue, arguments);
        }

        /// <summary>
        /// 拦截
        /// </summary>
        /// <param name="invocation">IInvocation</param>
        /// <param name="args">参数</param>
        /// <returns></returns>
        public override object Intercept(IInvocation invocation, params object[] args)
        {
            try
            {
                PreProceed(invocation, args);

                object ret;
                //事务判断
                if (IsTransaction)
                {
                    using (TransactionScope ts = new TransactionScope())
                    {
                        try
                        {
                            ret = invocation.Proceed(args);
                            ts.Complete();
                        }
                        catch (Exception ex)
                        {
                            throw (ex);
                        }
                    }
                }
                else
                {
                    ret = invocation.Proceed(args);
                }

                PostProceed(invocation, ref ret, args);
                return ret;
            }
            catch (Exception ex)
            {
                //日志判断
                if (IsErrorLog)
                {
                    ZhuJi.Log.IDAL.ILogging log = new ZhuJi.Log.NHibernateDAL.Logging();
                    log.WriteException(ex);
                }
                throw ex;
            }
        }
    }
}
