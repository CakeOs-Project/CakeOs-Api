using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.DTOs.Parameter.Filled;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Mapping.Registers.Parameter
{
    public class FilledMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Filled, FilledListDto>();

            config.NewConfig<FilledCreateDto, Filled>()
                .Map(dest => dest.IsActive, src => true);

            config.NewConfig<FilledUpdateDto, Filled>();
        }
    }
}
