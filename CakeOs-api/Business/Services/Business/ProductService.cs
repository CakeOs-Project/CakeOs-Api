using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Business;
using CakeOs.Data.Interfaces.Business;
using CakeOs.Entity.Domain.Business;
using CakeOS.Entity.DTOs.BusinessDtos.ProductoDtos;
using CakeOS.Utilities.Provider;
using MapsterMapper;

namespace CakeOs.Business.Services.Business
{
    /// <summary>
    /// Servicio para gestionar operaciones relacionadas con productos.
    /// </summary>
    public class ProductService : TenantServicesBase<ProductListDto, ProductCreateDto, Product>, IProductServices
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository data, IMapper mapper, ITenantProvider tenantProvider)
            : base(data, mapper, tenantProvider)
        {
            _repository = data;
            _mapper = mapper;
        }

        /// <summary>
        /// CU-19: Busca productos por nombre.
        /// </summary>
        /// <param name="name">Nombre del producto a buscar</param>
        /// <returns>Lista de productos que coinciden</returns>
        public async Task<IEnumerable<ProductListDto>> SearchByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("El nombre del producto es requerido.");

            var products = await _repository.SearchByNameAsync(name);
            return _mapper.Map<IEnumerable<ProductListDto>>(products);
        }
    }
}
