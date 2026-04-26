using CakeOs.Business.Interfaces.Business;
using CakeOs.Business.Services.Business;
using CakeOS.Entity.DTOs.Business.Invoice;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Business
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con facturas.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceServices _services;
        public InvoiceController(IInvoiceServices services)
        {
            _services = services;
        }

        #region "GET"

        [HttpGet("today")]
        public async Task<IActionResult> GetInvoicesForToday()
    {
            var result = await _services.GetInvoicesForTodayAsync();
            return Ok(result);
        }

        #endregion

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateInvoiceAsync(InvoiceCreateDto dto, int userId)
        {
            var invoice = await _services.CreateInvoiceAsync(dto, userId);
            return Ok(invoice);
        }
    }
}
