using CakeOs.Business.Mapping.Registers.Business;
using CakeOs.Business.Mapping.Registers.Parameter;
using Mapster;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Mapping
{
    public static class MappingConfig
    {
        public static TypeAdapterConfig Register()
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(typeof(ClientMapping).GetTypeInfo().Assembly);

            return config;
        }
    }
}
