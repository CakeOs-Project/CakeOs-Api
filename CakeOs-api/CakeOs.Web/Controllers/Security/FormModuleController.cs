using CakeOs.Business.Interfaces.Security;
using CakeOS.Entity.Domain.security;
using CakeOs.Entity.DTOs.Security.FormModuleDtos;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Security
{
    [Route("api/security/[controller]")]
    public class FormModuleController : SecurityCrudController<FormModuleListDTO, FormModuleCreateDTO, FormModule>
    {
        public FormModuleController(IFormModuleServices service) : base(service)
        {
        }
    }
}
