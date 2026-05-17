using CakeOs.Data.Base;
using CakeOs.Entity.DTOs.Transversal;
using CakeOS.Entity.Domain.Base;
using MapsterMapper;

namespace CakeOs.Business.Base
{
    /// <summary>
    /// Implementación genérica de la capa de servicios de negocio.
    /// Proporciona operaciones CRUD base para cualquier entidad del sistema,
    /// delegando la persistencia al repositorio genérico y utilizando
    /// Mapster para la conversión entre entidades y DTOs.
    /// </summary>
    /// <typeparam name="TDtoList">DTO utilizado para listar y retornar registros.</typeparam>
    /// <typeparam name="TDtoCreate">DTO utilizado para crear nuevos registros.</typeparam>
    /// <typeparam name="TEntity">Entidad de dominio que hereda de <see cref="BaseDomain"/>.</typeparam>
    public class ServicesBase<TDtoList, TDtoCreate, TEntity> : AServices<TDtoList, TDtoCreate, TEntity>
        where TDtoList : class
        where TDtoCreate : class
        where TEntity : BaseDomain
    {
        protected readonly IData<TEntity> _repository;
        protected readonly IMapper _mapper;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="ServicesBase{TDtoList, TDtoCreate, TEntity}"/>.
        /// </summary>
        /// <param name="repository">Repositorio genérico para operaciones de persistencia.</param>
        /// <param name="mapper">Instancia de Mapster para mapeo entre entidades y DTOs.</param>
        public ServicesBase(IData<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todos los registros de la entidad.
        /// </summary>
        /// <param name="includeInactive">
        /// Si es <c>true</c>, incluye registros inactivos.
        /// Si es <c>false</c>, retorna únicamente los registros activos.
        /// Por defecto es <c>false</c>.
        /// </param>
        /// <param name="ct">Token para cancelar la operación asíncrona.</param>
        /// <returns>Colección de DTOs mapeados desde las entidades encontradas.</returns>
        /// <exception cref="Exception">Si ocurre un error durante la consulta.</exception>
        public override async Task<IEnumerable<TDtoList>> GetAllAsync( CancellationToken ct = default)
        {
            try
            {
                var entities = await _repository.GetAllAsync(ct);
                return _mapper.Map<IEnumerable<TDtoList>>(entities);
            }
            catch (Exception ex)
            {
                throw new("Error al obtener todos los registros.", ex);
            }
        }

        /// <summary>
        /// Obtiene un registro por su identificador único.
        /// </summary>
        /// <param name="id">Identificador del registro. Debe ser mayor a 0.</param>
        /// <param name="ct">Token para cancelar la operación asíncrona.</param>
        /// <returns>
        /// DTO del registro encontrado, o <c>null</c> si no existe.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">Si el id es menor o igual a 0.</exception>
        /// <exception cref="Exception">Si ocurre un error durante la consulta.</exception>
        public override async Task<TDtoList?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            try
            {
                if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "El id debe ser mayor a 0.");

                var entity = await _repository.GetByIdAsync(id, ct);
                return _mapper.Map<TDtoList>(entity);
            }
            catch (Exception ex)
            {
                throw new("Error al obtener el registro por Id.", ex);
            }
        }

        /// <summary>
        /// Crea un nuevo registro en el sistema a partir del DTO proporcionado.
        /// </summary>
        /// <param name="dto">DTO con los datos del nuevo registro. No puede ser nulo.</param>
        /// <returns>DTO del registro recién creado.</returns>
        /// <exception cref="ArgumentNullException">Si el DTO es nulo.</exception>
        /// <exception cref="Exception">Si ocurre un error durante la creación.</exception>
        public override async Task<TDtoList> CreateAsync(TDtoCreate dto)
        {
            try
            {
                if (dto is null) throw new ArgumentNullException(nameof(dto), "El DTO no puede ser nulo.");

                var candidate = _mapper.Map<TEntity>(dto);
                var entity = await _repository.AddAsync(candidate);
                await _repository.SaveChangesAsync();

                // Recargar la entidad con sus relaciones desde la BD
                var createdEntity = await _repository.GetByIdAsync(entity.Id);
                return _mapper.Map<TDtoList>(createdEntity);
            }
            catch (Exception ex)
            {
                throw new("Error al crear el registro.", ex);
            }
        }

        /// <summary>
        /// Actualiza un registro existente a partir del DTO proporcionado.
        /// </summary>
        /// <param name="id">Identificador del registro a actualizar. Debe ser mayor a 0.</param>
        /// <param name="dto">DTO con los datos actualizados. No puede ser nulo.</param>
        /// <returns>DTO del registro actualizado.</returns>
        /// <exception cref="ArgumentNullException">Si el DTO es nulo.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Si el id es menor o igual a 0.</exception>
        /// <exception cref="Exception">Si ocurre un error durante la actualización.</exception>
        public override async Task<ResponseDto> UpdateAsync(int id, TDtoCreate dto)
        {
            try
            {
                if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "El id debe ser mayor a 0.");
                if (dto is null) throw new ArgumentNullException(nameof(dto), "El DTO no puede ser nulo.");

                var existingEntity = await _repository.GetByIdAsync(id);
                if (existingEntity == null)
                    throw new ArgumentNullException(nameof(existingEntity), "El registro no existe.");

                var updatedEntity = _mapper.Map(dto, existingEntity);
                var entity = await _repository.UpdateAsync(updatedEntity);
                if (entity is not null)
                {
                    await _repository.SaveChangesAsync();
                    return ResponseDto.Ok("actualizada correcamente");
                }
                else
                {
                    return ResponseDto.Fail("error al actualizar");

                }
          }

            catch (Exception ex)
            {
                throw new("Error al actualizar el registro.", ex);
            }
        }

        /// <summary>
        /// Activa o desactiva un registro según el valor del parámetro <paramref name="isActive"/>.
        /// </summary>
        /// <param name="id">Identificador del registro. Debe ser mayor a 0.</param>
        /// <param name="isActive">
        /// Si es <c>true</c>, activa el registro.
        /// Si es <c>false</c>, lo desactiva.
        /// </param>
        /// <returns><c>true</c> si la operación fue exitosa, <c>false</c> en caso contrario.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Si el id es menor o igual a 0.</exception>
        /// <exception cref="Exception">Si ocurre un error durante el proceso.</exception>
        public override async Task<ResponseDto> ToggleActiveAsync(int id, bool isActive)
        {
            try
            {
                if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "El id debe ser mayor a 0.");

                bool result;
                if (isActive)
                    result = await _repository.ActivateAsync(id);
                else
                    result = await _repository.DeactivateAsync(id);

                if (result)
                    await _repository.SaveChangesAsync();

                return ResponseDto.Ok("Se actualizo correctamente!.");
            }
            catch (Exception ex)
            {
                throw new("Error en el proceso de activación/desactivación.", ex);
            }
        }

        /// <summary>
        /// Realiza un borrado lógico del registro, marcándolo como eliminado
        /// sin removerlo físicamente de la base de datos.
        /// </summary>
        /// <param name="id">Identificador del registro. Debe ser mayor a 0.</param>
        /// <returns><c>true</c> si el borrado fue exitoso, <c>false</c> en caso contrario.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Si el id es menor o igual a 0.</exception>
        /// <exception cref="Exception">Si ocurre un error durante el proceso.</exception>
        public override async Task<ResponseDto> SoftDeleteAsync(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "El id debe ser mayor a 0.");

                var result = await _repository.SoftDeleteAsync(id);
                if (result)
                    await _repository.SaveChangesAsync();
                else
                    return ResponseDto.Ok("Error al eliminar.");

                return ResponseDto.Ok("Se elimino correctamente.");
            }
            catch (Exception ex)
            {
                throw new("Error en el proceso de borrado lógico.", ex);
            }
        }
    }
}