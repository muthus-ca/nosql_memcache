using System;
using System.Collections.Generic;
using Enyim.Caching.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace MemcachedDemo
{
    internal static class ContainerConfiguration
    {
        public static IServiceProvider Configure()
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddEnyimMemcached(o => o.Servers = new List<Server> { new Server { Address = "10.0.0.25", Port = 11211 },
                                                                           new Server { Address = "10.0.0.6", Port = 11211 }});

            
            services.AddSingleton<ICacheProvider, CacheProvider>();
            services.AddSingleton<ICacheRepository, CacheRepository>();
                        
            return services.BuildServiceProvider();
        }
    }
}