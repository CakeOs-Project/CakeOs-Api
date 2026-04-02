using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.SecurityDtos.ModuloDtos;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Mapping.Registers.Security
{
    public class ModuleMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Module, ModuleListDTO>();

            config.NewConfig<ModuleCreateDTO, Module>()
                .Map(dest => dest.IsActive, src => true)
                .Map(dest => dest.IsDeleted, src => false);

            config.NewConfig<ModuleUpdateDTO, Module>();
        }
    }
}
