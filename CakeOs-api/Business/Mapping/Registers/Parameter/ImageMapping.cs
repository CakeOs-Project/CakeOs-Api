using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.DTOs.Parameter.Image;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Mapping.Registers.Parameter
{
    public class ImageMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Image, ImageListDto>();

            config.NewConfig<ImageCreateDto, Image>()
                .Map(dest => dest.IsActive, src => true);

            config.NewConfig<ImageUpdateDto, Image>();
        }
    }
}
