using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Security;
using CakeOs.Data.Interfaces.Security;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.Security.Form;
using MapsterMapper;

namespace CakeOs.Business.Services.Security
{
    public class FormServices : ServicesBase<FormListDto, FormCreateDto, Form>, IFormServices
    {
        private readonly IFormRepository _repository;
        private readonly IMapper _mapper;

        public FormServices(IFormRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FormListDto>> GetByModuleIdAsync(int moduleId)
        {
            if (moduleId <= 0)
                throw new ArgumentOutOfRangeException(nameof(moduleId), "El moduleId debe ser mayor que cero.");

            var entities = await _repository.GetByModuleIdAsync(moduleId);
            return _mapper.Map<IEnumerable<FormListDto>>(entities);
        }

        public async Task<IEnumerable<FormListDto>> GetActiveFormsAsync()
        {
            var entities = await _repository.GetActiveFormsAsync();
            return _mapper.Map<IEnumerable<FormListDto>>(entities);
        }
    }
}
