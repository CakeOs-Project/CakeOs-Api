using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Security;
using CakeOs.Data.Interfaces.Security;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.SecurityDtos.PersonaDtos;
using CakeOS.Utilities.Provider;
using MapsterMapper;

namespace CakeOs.Business.Services.Security
{
    public class PersonServices : TenantServicesBase<PersonListDTO, PersonCreateDTO, Person>, IPersonServices
    {
        public PersonServices(IPersonRepository repository, IMapper mapper, ITenantProvider tenantProvider)
            : base(repository, mapper, tenantProvider)
        {
        }
    }
}
