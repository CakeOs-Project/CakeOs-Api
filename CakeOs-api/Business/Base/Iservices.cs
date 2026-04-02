using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CakeOs.Business.Base
{
    /// <summary>
    /// Interfaz genérica que define las operaciones CRUD básicas para los servicios.
    /// </summary>
    /// <typeparam name="TDto">El tipo de DTO que maneja el servicio.</typeparam>
    public interface IServices<TDto> where TDto : class
    {
        /// <summary>
        /// Obtiene una entidad por su identificador.
        /// </summary>
        Task<TDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtiene todas las entidades.
        /// </summary>
        Task<IEnumerable<TDto>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtiene una página de entidades.
        /// </summary>
        Task<IEnumerable<TDto>> GetPageAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtiene el total de entidades.
        /// </summary>
        Task<int> GetCountAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Crea una nueva entidad.
        /// </summary>
        Task<TDto> CreateAsync(TDto dto, CancellationToken cancellationToken = default);

        /// <summary>
        /// Actualiza una entidad existente.
        /// </summary>
        Task<TDto?> UpdateAsync(int id, TDto dto, CancellationToken cancellationToken = default);

        /// <summary>
        /// Elimina una entidad por su identificador.
        /// </summary>
        Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
