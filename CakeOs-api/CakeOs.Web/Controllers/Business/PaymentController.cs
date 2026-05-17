using CakeOs.Business.Base;
using CakeOs.Business.Interfaces.Business;
using CakeOs.Web.Controllers.Base;
using CakeOS.Entity.Domain.Business;
using CakeOS.Entity.DTOs.Business.Payment;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Business
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con pagos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentServices _services;
        public PaymentController(IPaymentServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var payment = await _services.GetAllAsync(cancellationToken);
            return Ok(payment);
        }

        [HttpGet("invoice/{invoiceId}")]
        public async Task<IActionResult> GetByInvoiceIdAsync(int invoiceId)
        {
            var payment = await _services.GetByInvoiceIdAsync(invoiceId);
            return Ok(payment);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPaymentAsync(PaymentCreateDto dto, int userId)
        {
            var payment = await _services.RegisterPaymentAsync(dto, userId);
            return Ok(payment);
        }
    }
}
