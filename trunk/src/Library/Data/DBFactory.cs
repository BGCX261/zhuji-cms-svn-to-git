using System;
using System.Globalization;
using System.Configuration;
using ZhuJi.Library.Reflection;
using ZhuJi.Library.Web;

namespace ZhuJi.Library.Data
{
    /// <summary>
    /// ���ݿ⹤����
    /// </summary>
    public sealed class DBFactory
    {
        private DBFactory()
        {
        }

        #region ����

        /// <summary>
        /// ���ݿ������ַ���
        /// </summary>
        public static readonly string DBConnectionString =
            ConfigurationManager.ConnectionStrings["ZhuJi.Library.Data.DBProvider"].ConnectionString;

        /// <summary>
        /// ���ݿ��������
        /// </summary>
        public static readonly string DBProviderName =
            ConfigurationManager.ConnectionStrings["ZhuJi.Library.Data.DBProvider"].ProviderName;

        /// <summary>
        /// ���ݿ⹤���Ƿ񻺴�
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
        /// ������������
        /// </summary>
        /// <returns>������������</returns>
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
        /// �������湤����������
        /// </summary>
        /// <returns>������������</returns>
        public static IDBHelper CreateFactoryByNoCache()
        {
            string typeName = DBProviderName;
            return (IDBHelper) ReflectionHelper.CreateInstance(typeName);
        }

        /// <summary>
        /// �����湤����������
        /// </summary>
        /// <returns>������������</returns>
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