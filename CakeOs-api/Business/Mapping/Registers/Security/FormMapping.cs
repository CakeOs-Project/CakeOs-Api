using CakeOS.Entity.Domain.security;
using CakeOS.Entity.DTOs.Security.Form;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Mapping.Registers.Security
{
    public class FormMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Form, FormListDto>()
                .Map(dest => dest.Route, src => src.Url);

            config.NewConfig<FormCreateDto, Form>()
                .Map(dest => dest.IsActive, src => true)
                .Map(dest => dest.IsDeleted, src => false)
                .Map(dest => dest.Url, src => src.Route);

            config.NewConfig<FormUpdateDto, Form>()
                .Map(dest => dest.Url, src => src.Route);
        }
    }
}
