using System.Runtime.Caching;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace DevFramework.Core.CrossCuttingConcerns.Caching.MicrosoftCore
{
    public class MemoryCacheManager : ICacheManager
    {

        protected ObjectCache Cache => MemoryCache.Default;

        public void Add(string key, object data, int cacheTime = 60)
        {
            if (data == null)
            {
                return;
            }

            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime) };
            Cache.Set(key, data, policy);

        }

        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public bool IsAdd(string key)
        {
            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPatternt(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = Cache.Where(d => regex.IsMatch(d.Key)).Select(d => d.Key).ToList();
            foreach (var key in keysToRemove)
            {
                Remove(key);
            }
        }
    }
}
