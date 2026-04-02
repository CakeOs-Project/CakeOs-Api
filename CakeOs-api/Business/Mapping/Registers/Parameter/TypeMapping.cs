using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.DTOs.Parameter.Type;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Mapping.Registers.Parameter
{
    public class TypeMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Types, TypeListDto>();

            config.NewConfig<TypeCreateDto, Types>()
                .Map(dest => dest.IsActive, src => true);

            config.NewConfig<TypeUpdateDto, Types>();
        }
    }
}
