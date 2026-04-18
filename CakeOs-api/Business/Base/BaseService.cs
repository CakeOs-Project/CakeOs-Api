using CakeOs.Data.Interfaz.IData;
using CakeOS.Entity.Domain.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CakeOs.Business.Base
{
    /// <summary>
    /// Servicio base genérico que proporciona operaciones CRUD comunes.
    /// </summary>
    /// <typeparam name="TEntity">La entidad del dominio.</typeparam>
    /// <typeparam name="TDto">El DTO asociado con la entidad.</typeparam>
    public abstract class BaseService<TEntity, TDto> : IServices<TDto>
        where TEntity : BaseDomain
        where TDto : class
    {
        protected readonly IData<TEntity> _data;

        /// <summary>
        /// Inicializa una nueva instancia del servicio base.
        /// </summary>
        /// <param name="data">Repositorio de datos genérico.</param>
        protected BaseService(IData<TEntity> data)
        {
            _data = data ?? throw new ArgumentNullException(nameof(data));
        }

        /// <summary>
        /// Obtiene una entidad por su identificador.
        /// </summary>
        /// <param name="id">El identificador de la entidad.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>El DTO de la entidad encontrada o null.</returns>
        public virtual async Task<TDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _data.GetByIdAsync(id, cancellationToken);
            return entity != null ? MapToDto(entity) : null;
        }

        /// <summary>
        /// Obtiene todas las entidades.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Lista de DTOs de todas las entidades.</returns>
        public virtual async Task<IEnumerable<TDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = await _data.GetAllAsync(cancellationToken);
            return entities.Select(MapToDto).ToList();
        }

        /// <summary>
        /// Obtiene una página de entidades.
        /// </summary>
        /// <param name="pageNumber">Número de página (comienza en 1).</param>
        /// <param name="pageSize">Tamaño de la página.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Lista de DTOs de la página especificada.</returns>
        public virtual async Task<IEnumerable<TDto>> GetPageAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var entities = await _data.GetPageAsync(pageNumber, pageSize, cancellationToken);
            return entities.Select(MapToDto).ToList();
        }

        /// <summary>
        /// Obtiene el total de entidades.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Total de entidades.</returns>
        public virtual async Task<int> GetCountAsync(CancellationToken cancellationToken = default)
        {
            return await _data.GetCountAsync(cancellationToken);
        }

        /// <summary>
        /// Crea una nueva entidad.
        /// </summary>
        /// <param name="dto">El DTO con los datos de la entidad.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>El DTO de la entidad creada.</returns>
        public virtual async Task<TDto> CreateAsync(TDto dto, CancellationToken cancellationToken = default)
        {
            var entity = MapToEntity(dto);
            await _data.AddAsync(entity, cancellationToken);
            await _data.SaveAsync(cancellationToken);
            return MapToDto(entity);
        }

        /// <summary>
        /// Actualiza una entidad existente.
        /// </summary>
        /// <param name="id">El identificador de la entidad.</param>
        /// <param name="dto">El DTO con los datos actualizados.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>El DTO de la entidad actualizada o null si no existe.</returns>
        public virtual async Task<TDto?> UpdateAsync(int id, TDto dto, CancellationToken cancellationToken = default)
        {
            var entity = await _data.GetByIdAsync(id, cancellationToken);
            if (entity == null)
                return null;

            MapToEntity(dto, entity);
            _data.Update(entity);
            await _data.SaveAsync(cancellationToken);
            return MapToDto(entity);
        }

        /// <summary>
        /// Elimina una entidad por su identificador.
        /// </summary>
        /// <param name="id">El identificador de la entidad.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>True si la entidad fue eliminada; false si no existe.</returns>
        public virtual async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _data.DeleteAsync(id, cancellationToken);
        }

        /// <summary>
        /// Convierte un DTO a una entidad. Debe implementarse en las clases derivadas.
        /// </summary>
        /// <param name="dto">El DTO a convertir.</param>
        /// <returns>La entidad convertida.</returns>
        protected abstract TEntity MapToEntity(TDto dto);

        /// <summary>
        /// Actualiza una entidad existente con los datos del DTO. Debe implementarse en las clases derivadas.
        /// </summary>
        /// <param name="dto">El DTO con los datos actualizados.</param>
        /// <param name="entity">La entidad a actualizar.</param>
        protected abstract void MapToEntity(TDto dto, TEntity entity);

        /// <summary>
        /// Convierte una entidad a un DTO. Debe implementarse en las clases derivadas.
        /// </summary>
        /// <param name="entity">La entidad a convertir.</param>
        /// <returns>El DTO convertido.</returns>
        protected abstract TDto MapToDto(TEntity entity);
    }
}
