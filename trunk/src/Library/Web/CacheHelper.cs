using System;
using System.Collections;
using System.Web;

namespace ZhuJi.Library.Web
{
    /// <summary>
    /// 缓存帮助类
    /// </summary>
    public class CacheHelper
    {
        private string HashtableMemoryCache = "HashtableMemoryCacheKey";

        private Hashtable inMemoryCache = Hashtable.Synchronized(new Hashtable());

        /// <summary>
        /// 缓存总数
        /// </summary>
        public int Count
        {
            get { return inMemoryCache.Count; }
        }

        /// <summary>
        /// 缓存项目
        /// </summary>
        private Hashtable CacheItem
        {
            set
            {
                if (HttpRuntime.Cache[HashtableMemoryCache] == null)
                {
                    HttpRuntime.Cache.Insert(HashtableMemoryCache, value);
                }
                else
                {
                    HttpRuntime.Cache[HashtableMemoryCache] = value;
                }
            }
            get { return (Hashtable) HttpRuntime.Cache[HashtableMemoryCache]; }
        }

        /// <summary>
        /// 加入缓存对像
        /// </summary>
        /// <param name="key">缓存标志</param>
        /// <param name="value">缓存对像</param>
        public void Add(string key, object value)
        {
            if (value != null)
            {
                if (CacheItem != null)
                {
                    inMemoryCache = CacheItem;
                }

                inMemoryCache.Add(key, value);

                CacheItem = inMemoryCache;
            }
        }

        /// <summary>
        /// 移除缓存对象
        /// </summary>
        /// <param name="key">缓存标志</param>
        public void Remove(string key)
        {
            ValidateKey(key);

            if (CacheItem != null)
            {
                inMemoryCache = CacheItem;
            }

            inMemoryCache.Remove(key);

            CacheItem = inMemoryCache;
        }

        /// <summary>
        /// 获得缓存对象
        /// </summary>
        /// <param name="key">缓存标志</param>
        /// <returns>缓存对像</returns>
        public object Get(string key)
        {
            ValidateKey(key);

            if (CacheItem != null)
            {
                inMemoryCache = CacheItem;
            }

            return inMemoryCache[key];
        }

        /// <summary>
        /// 清楚缓存
        /// </summary>
        public void Clear()
        {
            inMemoryCache.Clear();

            CacheItem = inMemoryCache;
        }

        /// <summary>
        /// 验证缓存标志
        /// </summary>
        /// <param name="key">缓存标志</param>
        private static void ValidateKey(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentException("缓存标志不能为空.");
            }
        }
    }
}