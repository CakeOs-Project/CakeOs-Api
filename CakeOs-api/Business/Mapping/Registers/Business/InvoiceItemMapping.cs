using CakeOs.Entity.Domain.Business;
using CakeOs.Entity.DTOs.Business.InvoiceItemExtra;
using CakeOs.Entity.Enum.Invoice;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.InvoiceItem;
using Mapster;

namespace CakeOs.Business.Mapping.Registers.Business
{
    public class InvoiceItemMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<InvoiceItem, InvoiceItemDetailDto>()
                .Map(dest => dest.FilledName, src => src.Filled != null ? src.Filled.Name : null);

            config.NewConfig<InvoiceItemCreateDto, InvoiceItem>()
                .Map(dest => dest.IsActive, src => true)
                .Map(dest => dest.Status, src => InvoiceItemStatus.Pendiente)
                .Map(dest => dest.SubTotal, src => src.Quantity * src.UnitPrice)
                .Map(dest => dest.FilledId, src => src.HasFilling ? src.FilledId : null)
                .Ignore(dest => dest.Extras)
                .Ignore(dest => dest.Filled)
                .Ignore(dest => dest.Product)
                .Ignore(dest => dest.Image)
                .Ignore(dest => dest.Invoice);

            config.NewConfig<InvoiceItemExtraCreateDto, InvoiceItemExtra>()
                .Map(dest => dest.IsActive, src => true)
                .Map(dest => dest.SubTotal, src => src.Quantity * src.UnitPrice)
                .Ignore(dest => dest.Extra)
                .Ignore(dest => dest.InvoiceItem);

            config.NewConfig<InvoiceItemExtra, InvoiceItemExtraListDto>()
                .Map(dest => dest.ExtraName, src => src.Extra != null ? src.Extra.Name : null);
        }
    }
}
