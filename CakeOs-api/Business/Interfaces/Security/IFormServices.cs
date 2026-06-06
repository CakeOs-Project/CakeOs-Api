using CakeOs.Business.Base;
using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.Security.Form;

namespace CakeOs.Business.Interfaces.Security
{
    public interface IFormServices : IServices<FormListDto, FormCreateDto, Form>
    {
        Task<IEnumerable<FormListDto>> GetByModuleIdAsync(int moduleId);
        Task<IEnumerable<FormListDto>> GetActiveFormsAsync();
    }
}
