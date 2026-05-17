using CakeOs.Business.Interfaces.Business;
using CakeOS.Entity.DTOs.BusinessDtos.ProductoDtos;
using Microsoft.AspNetCore.Mvc;

namespace CakeOs.Web.Controllers.Business
{
    /// <summary>
    /// Controlador para gestionar operaciones relacionadas con productos.
    /// CU-16: Crear producto — Dueño
    /// CU-17: Editar producto — Dueño
    /// CU-18: Activar/Desactivar producto — Dueño
    /// CU-19: Listar productos — Dueño, Empleado
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ProductController : Controller
    {
        private readonly IProductServices _services;

        public ProductController(IProductServices services)
        {
            _services = services;
        }

        #region "GET"

        /// <summary>
        /// CU-19: Obtiene la lista de todos los productos.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns>Lista de productos</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var products = await _services.GetAllAsync(cancellationToken);
            return Ok(products);
        }

        /// <summary>
        /// Obtiene un producto específico por su ID.
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <param name="cancellationToken">Token de cancelación</param>
        /// <returns>Producto encontrado</returns>
        [HttpGet("{id}", Name = nameof(GetByIdAsync))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var product = await _services.GetByIdAsync(id, cancellationToken);

            if (product is null)
                return NotFound();

            return Ok(product);
        }

        /// <summary>
        /// CU-19: Busca productos por nombre.
        /// </summary>
        /// <param name="name">Nombre del producto a buscar</param>
        /// <returns>Lista de productos que coinciden con el nombre</returns>
        [HttpGet("search/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SearchByNameAsync(string name)
        {
            var products = await _services.SearchByNameAsync(name);
            return Ok(products);
        }

        #endregion

        #region "POST"

        /// <summary>
        /// CU-16: Crea un nuevo producto.
        /// </summary>
        /// <param name="dto">Datos del producto a crear</param>
        /// <returns>Producto creado</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync(ProductCreateDto dto)
        {
            var product = await _services.CreateAsync(dto);
            return CreatedAtRoute("GetProductByIdAsync", new { id = product.Id }, product);
        }

        #endregion

        #region "PUT"

        /// <summary>
        /// CU-17: Actualiza un producto existente.
        /// </summary>
        /// <param name="id">ID del producto a actualizar</param>
        /// <param name="dto">Datos del producto a actualizar</param>
        /// <returns>Producto actualizado</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(int id, ProductCreateDto dto)
        {
            var product = await _services.UpdateAsync(id, dto);
            return Ok(product);
        }

        /// <summary>
        /// CU-18: Activa o desactiva un producto.
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <param name="isActive">Estado del producto (activo/inactivo)</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPatch("{id}/toggle-active")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ToggleActiveAsync(int id, [FromQuery] bool isActive)
        {
            var result = await _services.ToggleActiveAsync(id, isActive);

            if (!result.Success)
                return NotFound();

            return Ok(new { message = "El estado del producto ha sido actualizado." });
        }

        #endregion

        #region "PATCH"

        /// <summary>
        /// Elimina lógicamente un producto (soft delete).
        /// </summary>
        /// <param name="id">ID del producto a eliminar</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SoftDeleteAsync(int id)
        {
            var result = await _services.SoftDeleteAsync(id);
            return Ok(result);
        }

        #endregion
    }
}
