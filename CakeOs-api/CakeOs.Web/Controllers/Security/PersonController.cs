using CakeOs.Business.Base;
using CakeOs.Web.Controllers.Base;
using CakeOS.Entity.DTOs.SecurityDtos.PersonaDtos;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Security
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con personas.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : BaseCrudController<PersonListDTO>
    {
        /// <summary>
        /// Inicializa una nueva instancia del controlador de personas.
        /// </summary>
        /// <param name="service">Servicio de personas.</param>
        public PersonController(IServices<PersonListDTO> service) : base(service)
        {
        }
    }
}
