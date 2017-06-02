using ConsoleApp1.Interfaces;
using System;
using System.Runtime.Caching;
using System.Threading;

namespace ConsoleApp1.Classes
{
    /// <summary>
    /// MemoryCache should reference System.Runtime.Caching
    /// </summary>
    public class CacheInMemory : IEntrance
    {
        public void Run()
        {
            MemoryCache mCache = MemoryCache.Default;
            string key = "cacheKey";
            Console.WriteLine($"Get the value of key: \"{key}\" from MemoryCache");
            string value = mCache.Get(key) as string;
            if (string.IsNullOrWhiteSpace(value))
            {
                string stringToCache = "message to cache";
                Console.WriteLine($"value is null add {stringToCache} to MemoryCache for 5 seconds");
                mCache.Add(key, stringToCache, DateTimeOffset.Now.AddSeconds(5));
            }
            Console.WriteLine($"Get the value of key: \"{key}\" from MemoryCache");
            value = mCache.Get(key) as string;
            Console.WriteLine(value);

            Console.WriteLine($"Get the value of key: \"{key}\" from MemoryCache after 3 seconds");
            Thread.Sleep(3000);
            value = mCache.Get(key) as string;
            Console.WriteLine(value);

            Console.WriteLine($"Get the value of key: \"{key}\" from MemoryCache after 3 seconds");
            Thread.Sleep(3000);
            value = mCache.Get(key) as string;
            Console.WriteLine(value);
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("cache expired");
            }
        }
    }
}
