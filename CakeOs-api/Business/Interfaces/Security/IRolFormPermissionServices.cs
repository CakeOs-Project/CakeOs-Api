using CakeOs.Business.Base;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.SecurityDtos.RolFormularioPermisoDtos;

namespace CakeOs.Business.Interfaces.Security
{
    public interface IRolFormPermissionServices : IServices<RolFormPermissionListDTO, RolFormPermissionCreateDTO, RolFormPermission>
    {
        Task<IEnumerable<RolFormPermissionListDTO>> GetByRolIdAsync(int rolId);
    }
}
