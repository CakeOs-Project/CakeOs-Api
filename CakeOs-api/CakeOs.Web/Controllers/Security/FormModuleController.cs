using CakeOs.Business.Interfaces.Security;
using CakeOs.Entity.DTOs.Security.FormModuleDtos;
using CakeOS.Entity.Domain.security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Security
{
    [ApiController]
    [Route("api/security/[controller]")]
    [Authorize]
    [Produces("application/json")]
    public class FormModuleController : SecurityCrudController<FormModuleListDTO, FormModuleCreateDTO, FormModule>
    {
        public FormModuleController(IFormModuleServices service) : base(service)
        {
        }
    }
}
