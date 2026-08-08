using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Business;
using CakeOs.Web.Controllers.Base;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Business
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con pagos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    [Produces("application/json")]
    public class PaymentController : Controller
    {
        private readonly IPaymentServices _services;
        public PaymentController(IPaymentServices services)
        {
            _services = services;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var payment = await _services.GetAllAsync(cancellationToken);
            return Ok(payment);
        }

        [HttpGet("invoice/{invoiceId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetByInvoiceIdAsync(int invoiceId)
        {
            if (invoiceId <= 0)
                return BadRequest(new { message = "El id de factura debe ser mayor que cero." });

            var payment = await _services.GetByInvoiceIdAsync(invoiceId);
            return Ok(payment);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> RegisterPaymentAsync(PaymentCreateDto dto)
        {
            var payment = await _services.RegisterPaymentAsync(dto);
            return StatusCode(StatusCodes.Status201Created, payment);
        }
    }
}
