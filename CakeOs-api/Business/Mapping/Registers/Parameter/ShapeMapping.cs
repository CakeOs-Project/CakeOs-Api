using CakeOs.Entity.Domain.Parameter;
using CakeOs.Entity.DTOs.Parameter.Shape;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Mapping.Registers.Parameter
{
    public class ShapeMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Shape, ShapeListDTO>();

            config.NewConfig<ShapeCreateDTO, Shape>()
                .Map(dest => dest.IsActive, src => true);

            config.NewConfig<ShapeUpdateDTO, Shape>();
        }
    }
}
