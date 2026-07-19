using CakeOs.Business.Interfaces.Business;
using CakeOs.Business.Services.Business;
using CakeOs.Entity.Enum.Invoice;
using CakeOS.Entity.DTOs.Business.Invoice;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Business
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con facturas.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
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
        public async Task<IActionResult> GetInvoicesForToday([FromQuery] TimeRangeFilter range = TimeRangeFilter.Today)
        {
            var result = await _services.GetInvoicesByRangeAsync(range);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvoiceDetailAsync(int id)
        {
            var result = await _services.GetWithDetailsAsync(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        #endregion

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateInvoiceAsync(InvoiceCreateDto dto)
        {
            var invoice = await _services.CreateInvoiceAsync(dto);
            return Ok(invoice);
        }
    }
}
