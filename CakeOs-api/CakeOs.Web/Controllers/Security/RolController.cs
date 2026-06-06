using CakeOs.Business.Interfaces.Security;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.Security.Rol;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Security
{
    [Route("api/security/[controller]")]
    public class RolController : SecurityCrudController<RolListDto, RolCreateDto, Rol>
    {
        public RolController(IRolServices service) : base(service)
        {
        }
    }
}
