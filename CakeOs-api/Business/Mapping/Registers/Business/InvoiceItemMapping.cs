using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.InvoiceItem;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Business.Mapping.Registers.Business
{
    public class InvoiceItemMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<InvoiceItem, InvoiceItemDetailDto>()
                .Map(dest => dest.ProductName, src => src.Product != null
                    ? $"{src.Product.Type.Name} - {src.Product.Size.Name} - {src.Product.Shape.Name}"
                    : string.Empty)
                .Map(dest => dest.FilledName, src => src.Filled != null ? src.Filled.Name : null)
                .Map(dest => dest.DecorationImageUrl, src => src.Image != null ? src.Image.Url : null);

            config.NewConfig<InvoiceItemCreateDto, InvoiceItem>()
                .Map(dest => dest.IsActive, src => true)
                .Map(dest => dest.Status, src => "pendiente");
        }
    }
}
