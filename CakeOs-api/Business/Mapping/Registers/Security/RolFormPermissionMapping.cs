using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.SecurityDtos.RolFormularioPermisoDtos;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Mapping.Registers.Security
{
    public class RolFormPermissionMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RolFormPermission, RolFormPermissionListDTO>()
                .Map(dest => dest.RolName, src => src.Rol != null ? src.Rol.Name : string.Empty)
                .Map(dest => dest.FormName, src => src.Form != null ? src.Form.Name : string.Empty)
                .Map(dest => dest.PermissionName, src => src.Permission != null ? src.Permission.Name : string.Empty);

            config.NewConfig<RolFormPermissionCreateDTO, RolFormPermission>()
                .Map(dest => dest.IsActive, src => true)
                .Map(dest => dest.IsDeleted, src => false);
        }
    }
}
