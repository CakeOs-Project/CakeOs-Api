using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.Security.Rol;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Mapping.Registers.Security
{
    public class RolMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Rol, RolListDto>();

            config.NewConfig<RolCreateDto, Rol>()
                .Map(dest => dest.IsActive, src => true)
                .Map(dest => dest.IsDeleted, src => false);

            config.NewConfig<RolUpdateDto, Rol>();
        }
    }
}
