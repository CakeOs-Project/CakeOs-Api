using CakeOs.Entity.DTOs.Security.FormModuleDtos;
using CakeOS.Entity.Domain.security;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Mapping.Registers.Security
{
    public class FormModuleMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<FormModule, FormModuleListDTO>()
                .Map(dest => dest.FormName, src => src.Form != null ? src.Form.Name : string.Empty)
                .Map(dest => dest.ModuleName, src => src.Module != null ? src.Module.Name : string.Empty);

            config.NewConfig<FormModuleCreateDTO, FormModule>()
                .Map(dest => dest.IsActive, src => true)
                .Map(dest => dest.IsDeleted, src => false);
        }
    }
}
