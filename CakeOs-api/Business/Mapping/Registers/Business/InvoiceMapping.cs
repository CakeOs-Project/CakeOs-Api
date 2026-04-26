using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.Invoice;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Mapping.Registers.Business
{
    public class InvoiceMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Invoice, InvoiceListDto>()
                .Map(dest => dest.FullName, src => src.Client != null && src.Client.Person != null
                    ? $"{src.Client.Person.Name} {src.Client.Person.LastName}"
                    : string.Empty);

            config.NewConfig<Invoice, InvoiceDetailDto>()
                .Map(dest => dest.ClientFullName, src => src.Client != null && src.Client.Person != null
                    ? $"{src.Client.Person.Name} {src.Client.Person.LastName}"
                    : string.Empty)
                .Map(dest => dest.ClientPhone, src => src.Client != null && src.Client.Person != null
                    ? src.Client.Person.Phone
                    : string.Empty)
                .Map(dest => dest.ClientEmail, src => src.Client != null ? src.Client.Email : null)
                .Map(dest => dest.CreatedByFullName, src => src.User != null && src.User.Person != null
                    ? $"{src.User.Person.Name} {src.User.Person.LastName}"
                    : string.Empty)
                .Map(dest => dest.Items, src => src.InvoiceItems)
                .Map(dest => dest.Payments, src => src.Payments);

            config.NewConfig<InvoiceCreateDto, Invoice>()
                .Map(dest => dest.IsActive, src => true)
                .Map(dest => dest.Status, src => "creada")
                .Map(dest => dest.CreatedAt, src => DateTime.UtcNow)
                .Ignore(dest => dest.InvoiceItems);

            config.NewConfig<InvoiceUpdateDto, Invoice>()
                .Ignore(dest => dest.InvoiceItems)
                .Ignore(dest => dest.Status)
                .Ignore(dest => dest.CreatedAt);
        }
    }
}
