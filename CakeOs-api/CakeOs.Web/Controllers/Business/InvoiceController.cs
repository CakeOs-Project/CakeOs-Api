using CakeOs.Business.Base;
using CakeOs.Web.Controllers.Base;
using CakeOS.Entity.DTOs.Business.Invoice;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Business
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con facturas.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : BaseCrudController<InvoiceDetailDto>
    {
        /// <summary>
        /// Inicializa una nueva instancia del controlador de facturas.
        /// </summary>
        /// <param name="service">Servicio de facturas.</param>
        public InvoiceController(IServices<InvoiceDetailDto> service) : base(service)
        {
        }
    }
}
