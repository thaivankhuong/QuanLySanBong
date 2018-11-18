using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootballGround.Core.Cache
{
    public static  class CacheExtensions
    {
        private const int DefaultCacheTime = 60 * 24 * 2; // 2 days

        public static T Get<T>(this ICacheManager cacheManager, string key, Func<T> acquire)
        {
            return Get(cacheManager, key, DefaultCacheTime, acquire);
        }


        public static T Get<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<T> acquire)
        {
            if (cacheManager.IsSet(key))
            {
                return cacheManager.Get<T>(key);
            }
            else
            {
                var result = acquire();
                if (cacheTime > 0)
                {
                    if (result == null)
                    {
                        cacheManager.Set(key, "", cacheTime);
                    }
                    else
                    {
                        cacheManager.Set(key, result, cacheTime);
                    }
                }
                return result;
            }
        }

        public static List<T> GetByPrefix<T>(this ICacheManager cacheManager, string prefix, Func<List<T>> acquire)
        {
            var result = cacheManager.GetByPrefix<T>(prefix, acquire);
            return result;
        }


        public static void RemoveByPattern(this ICacheManager cacheManager, string pattern, IEnumerable<string> keys)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (var key in keys.Where(p => regex.IsMatch(p.ToString())).ToList())
                cacheManager.Remove(key);
        }

  

      
    }
}
