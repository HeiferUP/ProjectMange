using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMange.Infrastructure.AutoMapper
{
    /// <summary>
    /// AutoMaper拓展
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMappers(this IServiceCollection services, string assemblies)
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(delegate (IMapperConfigurationExpression cfg)
            {
                if (!string.IsNullOrEmpty(assemblies))
                {
                    string[] array = assemblies.Split(new char[1]
                    {
                        '|'
                    }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < array.Length; i++)
                    {
                        foreach (Type item in from t in Assembly.Load(array[i]).GetTypes()
                                              where typeof(IMapperConfig).IsAssignableFrom(t)
                                              select t)
                        {
                            ((IMapperConfig)Activator.CreateInstance(item)).Bind(cfg);
                        }
                    }
                }
            });
            services.AddSingleton(mapperConfiguration.CreateMapper());
            return services;
        }
    }
}
