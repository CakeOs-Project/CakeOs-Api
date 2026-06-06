using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Security;
using CakeOs.Data.Interfaces.Security;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.SecurityDtos.ModuloDtos;
using MapsterMapper;

namespace CakeOs.Business.Services.Security
{
    public class ModuleServices : ServicesBase<ModuleListDTO, ModuleCreateDTO, Module>, IModuleServices
    {
        public ModuleServices(IModuleRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
