using CakeOs.Business.Interfaces.Business;
using CakeOs.Business.Services.Business;
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
    public class InvoiceItemController : Controller
    {
        private readonly IInvoiceItemServices _services;
        public InvoiceItemController(IInvoiceItemServices services)
        {
            _services = services;
        }

        #region "GET"

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (id <= 0)
                return BadRequest(new { message = "El id debe ser mayor que cero." });

            var item = await _services.GetByIdAsync(id);


            if (item is null)
                return NotFound(new { message = "El ítem de factura no existe." });

            return Ok(item);
        }

        #endregion

        [HttpPatch("{id}/ready")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> MarkAsReadyAsync(int id)
        {
            if (id <= 0)
                return BadRequest(new { message = "El id debe ser mayor que cero." });

            var result = await _services.MarkAsReadyAsync(id);
            return Ok(result);
        }
    }
}
