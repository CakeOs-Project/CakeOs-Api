using CakeOs.Business.Interfaces.Security;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.SecurityDtos.PermisoDtos;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Security
{
    [Route("api/security/[controller]")]
    public class PermissionController : SecurityCrudController<PermissionListDTO, PermissionCreateDTO, Permission>
    {
        public PermissionController(IPermissionServices service) : base(service)
        {
        }
    }
}
