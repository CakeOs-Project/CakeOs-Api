using System.Linq.Expressions;

namespace CakeOs.Data.Interfaz.IData;

/// <summary>
/// Interfaz genérica para el acceso a datos que define las operaciones CRUD básicas
/// y operaciones adicionales comunes para todas las entidades del sistema.
/// </summary>
/// <typeparam name="T">Tipo de entidad que debe ser una clase de referencia</typeparam>
public interface IData<T> where T : class
{
    // ==================== Métodos de Consulta ====================

    /// <summary>
    /// Obtiene todas las entidades de tipo T de la base de datos de forma asíncrona.
    /// </summary>
    /// <returns>Colección con todas las entidades encontradas</returnsS
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Obtiene una entidad específica por su identificador único.
    /// </summary>
    /// <param name="id">Identificador único de la entidad</param>
    /// <param name="cancellationToken">Token para cancelar la operación asíncrona</param>
    /// <returns>La entidad encontrada o null si no existe</returns>
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    // ==================== Métodos de Escritura ====================

    /// <summary>
    /// Agrega una nueva entidad a la base de datos de forma asíncrona.
    /// </summary>
    /// <param name="entity">Entidad a agregar</param>
    /// <param name="cancellationToken">Token para cancelar la operación asíncrona</param>
    /// <returns>La entidad agregada con sus valores generados (como el Id)</returns>
    Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Actualiza una entidad existente en la base de datos.
    /// </summary>
    /// <param name="entity">Entidad con los datos actualizados</param>
    /// <returns>La entidad actualizada</returns>
    Task<T> UpdateAsync(T entity);

    /// <summary>
    /// Elimina una entidad de la base de datos por su identificador.
    /// </summary>
    /// <param name="id">Identificador de la entidad a eliminar</param>
    /// <param name="cancellationToken">Token para cancelar la operación asíncrona</param>
    /// <returns>True si se eliminó correctamente, False en caso contrario</returns>
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);

    // ==================== Métodos de Activación/Desactivación ====================

    /// <summary>
    /// Activa una entidad estableciendo su propiedad IsActive en true.
    /// Útil para el borrado lógico y gestión de estados.
    /// </summary>
    /// <param name="id">Identificador de la entidad a activar</param>
    /// <param name="cancellationToken">Token para cancelar la operación asíncrona</param>
    /// <returns>True si se activó correctamente, False en caso contrario</returns>
    Task<bool> ActivateAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Desactiva una entidad estableciendo su propiedad IsActive en false.
    /// Útil para el borrado lógico y gestión de estados.
    /// </summary>
    /// <param name="id">Identificador de la entidad a desactivar</param>
    /// <param name="cancellationToken">Token para cancelar la operación asíncrona</param>
    /// <returns>True si se desactivó correctamente, False en caso contrario</returns>
    Task<bool> DeactivateAsync(int id, CancellationToken cancellationToken = default);

    // ==================== Métodos de Conteo y Existencia ====================


    /// <summary>
    /// Verifica si existe una entidad con el identificador especificado.
    /// </summary>
    /// <param name="id">Identificador de la entidad a verificar</param>
    /// <param name="cancellationToken">Token para cancelar la operación asíncrona</param>
    /// <returns>True si existe, False en caso contrario</returns>
    Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default);

    // ==================== Paginación ====================

    /// <summary>
    /// Obtiene un conjunto paginado de entidades con filtro opcional.
    /// Útil para mostrar listados grandes de datos en páginas.
    /// </summary>
    /// <param name="pageNumber">Número de página a obtener (comienza en 1)</param>
    /// <param name="pageSize">Cantidad de elementos por página</param>
    /// <param name="filter">Filtro opcional para aplicar a los datos</param>
    /// <param name="cancellationToken">Token para cancelar la operación asíncrona</param>
    /// <returns>Tupla con los elementos de la página y el total de registros</returns>
    Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
        int pageNumber, 
        int pageSize,                                                                      
        string? filter = null);

    // ==================== Guardado de cambios ====================

    /// <summary>
    /// Guarda todos los cambios pendientes en la base de datos.
    /// </summary>
    /// <returns>Número de entidades afectadas por el guardado</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}