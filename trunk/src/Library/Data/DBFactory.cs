using System;
using System.Globalization;
using System.Configuration;
using ZhuJi.Library.Reflection;
using ZhuJi.Library.Web;

namespace ZhuJi.Library.Data
{
    /// <summary>
    /// 数据库工厂类
    /// </summary>
    public sealed class DBFactory
    {
        private DBFactory()
        {
        }

        #region 属性

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static readonly string DBConnectionString =
            ConfigurationManager.ConnectionStrings["ZhuJi.Library.Data.DBProvider"].ConnectionString;

        /// <summary>
        /// 数据库操作类名
        /// </summary>
        public static readonly string DBProviderName =
            ConfigurationManager.ConnectionStrings["ZhuJi.Library.Data.DBProvider"].ProviderName;

        /// <summary>
        /// 数据库工厂是否缓存
        /// </summary>
        public static bool CacheFactory
        {
            get
            {
                string cacheFactory = ConfigurationManager.AppSettings["ZhuJi.Library.Data.CacheFactory"];
                return
                    string.IsNullOrEmpty(cacheFactory)
                        ? false
                        : Convert.ToBoolean(cacheFactory, CultureInfo.InvariantCulture);
            }
        }

        #endregion

        /// <summary>
        /// 工厂创建方法
        /// </summary>
        /// <returns>创建方法对象</returns>
        public static IDBHelper CreateFactory()
        {
            if (CacheFactory)
            {
                return CreateFactoryByCache();
            }
            else
            {
                return CreateFactoryByNoCache();
            }
        }

        /// <summary>
        /// 不带缓存工厂创建方法
        /// </summary>
        /// <returns>创建方法对象</returns>
        public static IDBHelper CreateFactoryByNoCache()
        {
            string typeName = DBProviderName;
            return (IDBHelper) ReflectionHelper.CreateInstance(typeName);
        }

        /// <summary>
        /// 带缓存工厂创建方法
        /// </summary>
        /// <returns>创建方法对象</returns>
        public static IDBHelper CreateFactoryByCache()
        {
            string typeName = DBProviderName;
            string cacheKey = string.Format(CultureInfo.InvariantCulture, "Reflection.CreateInstance.{0}", typeName);

            object db;

            CacheHelper cache = new CacheHelper();
            if (cache.Get(cacheKey) == null)
            {
                db = ReflectionHelper.CreateInstance(typeName);
                cache.Add(cacheKey, db);
            }
            else
            {
                db = cache.Get(cacheKey);
            }
            return (IDBHelper) db;
        }
    }
}