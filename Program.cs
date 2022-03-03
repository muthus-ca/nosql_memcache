using System;
using System.Threading;
using Microsoft.Extensions.DependencyInjection;

namespace MemcachedDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = ContainerConfiguration.Configure();
            var cacheRepository = provider.GetService<ICacheRepository>();
            var cacheProvider = provider.GetService<ICacheProvider>();
            for (int i = 1; i < 100; i++)
            {
                Console.WriteLine("Set cache for cache Key_"+i);
                
                // Set cache
                cacheRepository.Set("Key_"+i, i);

                Console.WriteLine("Sleep for 10 seconds");
                 //Sleep for 10 Seconds
                Thread.Sleep(1000 * 10 * 1);

                Console.WriteLine("Get cache");
                // Get cache
                
                Console.WriteLine($"Value from cache {cacheProvider.GetCache<string>("Key_"+i)}");
            }
            
            Console.ReadLine();   
        }
    }
}
