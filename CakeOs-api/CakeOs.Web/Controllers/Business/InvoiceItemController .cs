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
    public class InvoiceItemController : Controller
    {
        private readonly IInvoiceItemServices _services;
        public InvoiceItemController(IInvoiceItemServices services)
        {
            _services = services;
        }

        #region "GET"

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var item = await _services.GetByIdAsync(id);
            return Ok(item);
        }

        #endregion

        [HttpPatch("{id}/ready")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> MarkAsReadyAsync(int id)
        {
            var result = await _services.MarkAsReadyAsync(id);

            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
