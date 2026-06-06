using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Security;
using CakeOs.Data.Interfaces.Security;
using CakeOS.Entity.Domain.security;
using CakeOs.Entity.DTOs.Security.FormModuleDtos;
using MapsterMapper;

namespace CakeOs.Business.Services.Security
{
    public class FormModuleServices : ServicesBase<FormModuleListDTO, FormModuleCreateDTO, FormModule>, IFormModuleServices
    {
        public FormModuleServices(IFormModuleRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
