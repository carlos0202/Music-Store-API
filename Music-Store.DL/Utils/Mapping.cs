using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music_Store.DL.Utils
{
    /// <summary>
    /// Self contained Automapper Mapping class created to initialize
    /// profile configuration using Lazy initializer to avoid threading
    /// issues while booting up this configuration when a mapping operation
    /// is needed. The configuration could also be done on the API layer
    /// using dependency injection configuration for that purupose
    /// (see https://docs.automapper.org/en/stable/Configuration.html),
    /// but we wanted to keep all the logic relevant to this class library
    /// on the inside, and not depend on client calling code configuration.
    /// </summary>
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                // Add mapping profile defined in this class library.
                cfg.AddProfile<ServiceMappingProfile>();
            });
            var mapper = config.CreateMapper();

            return mapper;
        });

        public static IMapper Mapper => Lazy.Value;
    }
}
