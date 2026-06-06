using CakeOs.Business.Base;
using CakeOS.Entity.Domain.security;
using CakeOs.Entity.DTOs.Security.FormModuleDtos;

namespace CakeOs.Business.Interfaces.Security
{
    public interface IFormModuleServices : IServices<FormModuleListDTO, FormModuleCreateDTO, FormModule>
    {
    }
}
