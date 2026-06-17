using CakeOs.Business.Interfaces.Security;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.SecurityDtos.ModuloDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Security
{
    [ApiController]
    [Route("api/security/[controller]")]
    [Authorize]
    [Produces("application/json")]
    public class ModuleController : SecurityCrudController<ModuleListDTO, ModuleCreateDTO, Module>
    {
        public ModuleController(IModuleServices service) : base(service)
        {
        }
    }
}
