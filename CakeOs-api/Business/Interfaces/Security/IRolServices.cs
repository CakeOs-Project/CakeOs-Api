using CakeOs.Business.Base;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.Security.Rol;

namespace CakeOs.Business.Interfaces.Security
{
    public interface IRolServices : IServices<RolListDto, RolCreateDto, Rol>
    {
    }
}
