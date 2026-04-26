using CakeOs.Business.Base;
using CakeOs.Web.Controllers.Base;
using CakeOS.Entity.DTOs.Business.Payment;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Business
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con pagos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : BaseCrudController<PaymentListDto>
    {
        /// <summary>
        /// Inicializa una nueva instancia del controlador de pagos.
        /// </summary>
        /// <param name="service">Servicio de pagos.</param>
        public PaymentController(IServices<PaymentListDto> service) : base(service)
        {
        }
    }
}
