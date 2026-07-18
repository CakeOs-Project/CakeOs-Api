using CakeOs.Business.Base;
using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.DTOs.Parameter.Extras;

namespace CakeOs.Business.Interfaces.Parameter
{
    public interface IExtraServices : IServices<ExtraListDto, ExtraCreateDto, Extra>
    {
    }
}
