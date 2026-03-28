using CakeOs.Business.Base;
using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.DTOs.Parameter.Filled;

namespace CakeOs.Business.Interfaces.Parameter
{
    public interface IFilledServices : IServices<FilledListDto,FilledCreateDto, Filled>
    {
    }
}
