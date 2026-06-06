using CakeOs.Business.Interfaces.Security;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.SecurityDtos.ModuloDtos;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Security
{
    [Route("api/security/[controller]")]
    public class ModuleController : SecurityCrudController<ModuleListDTO, ModuleCreateDTO, Module>
    {
        public ModuleController(IModuleServices service) : base(service)
        {
        }
    }
}
