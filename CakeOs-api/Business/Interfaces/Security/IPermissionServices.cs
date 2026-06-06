using CakeOs.Business.Base;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.SecurityDtos.PermisoDtos;

namespace CakeOs.Business.Interfaces.Security
{
    public interface IPermissionServices : IServices<PermissionListDTO, PermissionCreateDTO, Permission>
    {
    }
}
