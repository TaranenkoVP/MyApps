using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Web;
using AutoMapper;

namespace MyForum.Web.MVC.Infrastructure.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using AutoMapper;

    public class AutoMapperConfigViewModel
    {
        public static MapperConfiguration Configuration { get; private set; }

        public void RegisterMappings(params string[] assemblies)
        {
            var types = new List<Type>();
            foreach (var assembly in assemblies.Select(Assembly.Load))
            {
                types.AddRange(assembly.GetExportedTypes());
            }

            Configuration = new MapperConfiguration(
                cfg =>
                {
                    LoadStandardMappings(types, cfg);
                    LoadCustomMappings(types, cfg);
                });
        }

        private static void LoadStandardMappings(IEnumerable<Type> types, IMapperConfigurationExpression mapperConfiguration)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();

            foreach (var map in maps)
            {
                mapperConfiguration.CreateMap(map.Source, map.Destination);
                mapperConfiguration.CreateMap(map.Destination, map.Source);
                Debug.WriteLine(map.Source + "    " + map.Destination);
            }
        }

        private static void LoadCustomMappings(IEnumerable<Type> types, IMapperConfigurationExpression mapperConfiguration)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(mapperConfiguration);
            }
        }
    }
}