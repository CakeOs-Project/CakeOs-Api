using CakeOs.Business.Interfaces.Security;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.Security.Form;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Security
{
    [Route("api/security/[controller]")]
    public class FormController : SecurityCrudController<FormListDto, FormCreateDto, Form>
    {
        private readonly IFormServices _formService;

        public FormController(IFormServices service) : base(service)
        {
            _formService = service;
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetActiveAsync()
        {
            var data = await _formService.GetActiveFormsAsync();
            return Ok(data);
        }

        [HttpGet("by-module/{moduleId:int}")]
        public async Task<IActionResult> GetByModuleAsync(int moduleId)
        {
            var data = await _formService.GetByModuleIdAsync(moduleId);
            return Ok(data);
        }
    }
}
