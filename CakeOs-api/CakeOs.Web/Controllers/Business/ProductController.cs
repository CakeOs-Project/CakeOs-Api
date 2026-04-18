using CakeOs.Business.Base;
using CakeOs.Web.Controllers.Base;
using CakeOS.Entity.DTOs.Business.Product;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Business
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con productos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : BaseCrudController<ProductUpdateDto>
    {
        /// <summary>
        /// Inicializa una nueva instancia del controlador de productos.
        /// </summary>
        /// <param name="service">Servicio de productos.</param>
        public ProductController(IServices<ProductUpdateDto> service) : base(service)
        {
        }
    }
}
