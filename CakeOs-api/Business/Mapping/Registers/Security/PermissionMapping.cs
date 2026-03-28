using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.SecurityDtos.PermisoDtos;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Mapping.Registers.Security
{
    public class PermissionMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Permission, PermissionListDTO>();

            config.NewConfig<PermissionCreateDTO, Permission>()
                .Map(dest => dest.IsActive, src => true)
                .Map(dest => dest.IsDeleted, src => false);

            config.NewConfig<PermissionUpdateDTO, Permission>();
        }
    }
}
