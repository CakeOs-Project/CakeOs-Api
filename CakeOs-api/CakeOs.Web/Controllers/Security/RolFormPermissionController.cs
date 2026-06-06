using CakeOs.Business.Interfaces.Security;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.SecurityDtos.RolFormularioPermisoDtos;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Security
{
    [Route("api/security/[controller]")]
    public class RolFormPermissionController : SecurityCrudController<RolFormPermissionListDTO, RolFormPermissionCreateDTO, RolFormPermission>
    {
        private readonly IRolFormPermissionServices _rolFormPermissionService;

        public RolFormPermissionController(IRolFormPermissionServices service) : base(service)
        {
            _rolFormPermissionService = service;
        }

        [HttpGet("by-rol/{rolId:int}")]
        public async Task<IActionResult> GetByRolIdAsync(int rolId)
        {
            var data = await _rolFormPermissionService.GetByRolIdAsync(rolId);
            return Ok(data);
        }
    }
}
