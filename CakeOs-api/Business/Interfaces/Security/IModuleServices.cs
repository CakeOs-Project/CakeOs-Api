using CakeOs.Business.Base;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.SecurityDtos.ModuloDtos;

namespace CakeOs.Business.Interfaces.Security
{
    public interface IModuleServices : IServices<ModuleListDTO, ModuleCreateDTO, Module>
    {
    }
}
