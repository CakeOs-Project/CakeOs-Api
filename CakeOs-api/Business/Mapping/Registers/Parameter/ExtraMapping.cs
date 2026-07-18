using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.DTOs.Parameter.Extras;
using Mapster;

namespace CakeOs.Business.Mapping.Registers.Parameter
{
    public class ExtraMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Extra, ExtraListDto>();

            config.NewConfig<ExtraCreateDto, Extra>()
                .Map(dest => dest.IsActive, src => true);
        }
    }
}
