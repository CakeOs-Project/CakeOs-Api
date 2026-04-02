using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.DTOs.Parameter.Size;
using Mapster;

namespace CakeOs.Business.Mapping.Registers.Parameter
{
    public class SizeMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Size, SizeListDTO>();

            config.NewConfig<SizeCreateDTO, Size>()
                .Map(dest => dest.IsActive, src => true);

            config.NewConfig<SizeUpdateDTO, Size>();
        }
    }
}
