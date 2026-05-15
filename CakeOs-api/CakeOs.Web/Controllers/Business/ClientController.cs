using CakeOs.Business.Interfaces.Business;
using CakeOS.Entity.DTOs.Business.Client;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetClientListAsync(CancellationToken cancellationToken = default)
        {
            var Client = await _Services.GetClientListAsync(cancellationToken);
            return Ok(Client);
        }
    }
}
