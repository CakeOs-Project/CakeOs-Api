using CakeOs.Business.Interfaces.Business;
using CakeOS.Entity.DTOs.Business.Client;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace CakeOs.Web.Controllers.Business
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con clientes.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ClientController : Controller
    {
        private readonly IClientServices _Services;

        public ClientController(IClientServices services)
        {
            _Services = services;
        }

        /// <summary>
        /// Inicializa una nueva instancia del controlador de clientes.
        /// </summary>
        /// <param name="service">Servicio de clientes.</param>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var Client = await _Services.GetAllAsync(cancellationToken);
            return Ok(Client);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken ct)
        {
            var client = await _Services.GetByIdAsync(id, ct);
            return Ok(client);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateAsync(int id, ClientCreateDto dto)
        {
            var exist = await _Services.GetByIdAsync(id);

            if (exist is null)
                return NotFound("Cliente no encontrado.");

            var client = await _Services.UpdateAsync(id, dto);

            if (client.Success)
                return Ok(client);
            else
                return BadRequest(client);
        }

        [HttpGet("document")]
        public async Task<IActionResult> GetByDocumentNumberAsync(string documentNumber)
        {
            var client = await _Services.GetByDocumentNumberAsync(documentNumber);
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ClientCreateDto dto)
        {
            var client = await _Services.CreateAsync(dto);
            return Ok(client);
        }

        [HttpPatch("{id}/toggle-active")]
        public async Task<IActionResult> ToggleActiveAsync(int id, bool isActive)
        {
            var result = await _Services.ToggleActiveAsync(id, isActive);
            return Ok(result);
        }
    }
}
