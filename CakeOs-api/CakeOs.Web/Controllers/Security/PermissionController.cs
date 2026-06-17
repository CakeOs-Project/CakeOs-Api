using CakeOs.Business.Interfaces.Security;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.SecurityDtos.PermisoDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Security
{
    [ApiController]
    [Route("api/security/[controller]")]
    [Authorize]
    [Produces("application/json")]
    public class PermissionController : SecurityCrudController<PermissionListDTO, PermissionCreateDTO, Permission>
    {
        public PermissionController(IPermissionServices service) : base(service)
        {
        }
    }
}
