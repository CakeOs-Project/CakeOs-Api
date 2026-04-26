using CakeOs.Business.Base;
using CakeOs.Web.Controllers.Base;
using CakeOS.Entity.DTOs.Business.Client;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Business
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con clientes.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : BaseCrudController<ClientListDto>
    {
        /// <summary>
        /// Inicializa una nueva instancia del controlador de clientes.
        /// </summary>
        /// <param name="service">Servicio de clientes.</param>
        public ClientController(IServices<ClientListDto> service) : base(service)
        {
        }
    }
}
