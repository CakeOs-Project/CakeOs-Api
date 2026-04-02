using CakeOs.Entity.Domain.Business;
using CakeOS.Entity.DTOs.BusinessDtos.ProductoDtos;
using Mapster;

namespace CakeOs.Business.Mapping.Registers.Parameter
{
    public class ProductMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Product, ProductListDto>()
                .Map(dest => dest.TypeName, src => src.Type != null ? src.Type.Name : string.Empty)
                .Map(dest => dest.SizeName, src => src.Size != null ? src.Size.Name : string.Empty)
                .Map(dest => dest.ShapeName, src => src.Shape != null ? src.Shape.Name : string.Empty);

            config.NewConfig<ProductCreateDto, Product>()
                .Map(dest => dest.IsActive, src => true);

            config.NewConfig<ProductUpdateDto, Product>();
        }
    }
}
