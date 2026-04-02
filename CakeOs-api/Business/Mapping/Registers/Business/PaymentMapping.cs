using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.Payment;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Mapping.Registers.Business
{
    public class PaymentMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Payment, PaymentListDto>()
                .Map(dest => dest.RegisteredByFullName, src => src.User != null
                    ? $"{src.User.Person.Name} {src.User.Person.LastName}"
                    : string.Empty);

            config.NewConfig<PaymentCreateDto, Payment>()
                .Map(dest => dest.PaymentDate, src => DateTime.UtcNow);
        }
    }
}
