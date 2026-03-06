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
    /// <returns>Colección con todas las entidades encontradas</returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Obtiene una entidad específica por su identificador único.
    /// </summary>
    /// <param name="id">Identificador único de la entidad</param>
    /// <returns>La entidad encontrada o null si no existe</returns>
    Task<T?> GetByIdAsync(int id);

    /// <summary>
    /// Busca y obtiene todas las entidades que cumplan con el predicado especificado.
    /// </summary>
    /// <param name="predicate">Expresión lambda que define los criterios de búsqueda</param>
    /// <returns>Colección de entidades que cumplen con los criterios</returns>
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Obtiene la primera entidad que cumpla con el predicado o null si no se encuentra ninguna.
    /// </summary>
    /// <param name="predicate">Expresión lambda que define los criterios de búsqueda</param>
    /// <returns>La primera entidad que cumple con los criterios o null</returns>
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

    // ==================== Métodos de Escritura ====================

    /// <summary>
    /// Agrega una nueva entidad a la base de datos de forma asíncrona.
    /// </summary>
    /// <param name="entity">Entidad a agregar</param>
    /// <returns>La entidad agregada con sus valores generados (como el Id)</returns>
    Task<T> AddAsync(T entity);


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
    /// <returns>True si se eliminó correctamente, False en caso contrario</returns>
    Task<bool> DeleteAsync(int id);

    /// <summary>
    /// Elimina una entidad específica de la base de datos.
    /// </summary>
    /// <param name="entity">Entidad a eliminar</param>
    /// <returns>True si se eliminó correctamente, False en caso contrario</returns>
    Task<bool> DeleteAsync(T entity);

    // ==================== Métodos de Activación/Desactivación ====================

    /// <summary>
    /// Activa una entidad estableciendo su propiedad IsActive en true.
    /// Útil para el borrado lógico y gestión de estados.
    /// </summary>
    /// <param name="id">Identificador de la entidad a activar</param>
    /// <returns>True si se activó correctamente, False en caso contrario</returns>
    Task<bool> ActivateAsync(int id);

    /// <summary>
    /// Desactiva una entidad estableciendo su propiedad IsActive en false.
    /// Útil para el borrado lógico y gestión de estados.
    /// </summary>
    /// <param name="id">Identificador de la entidad a desactivar</param>
    /// <returns>True si se desactivó correctamente, False en caso contrario</returns>
    Task<bool> DeactivateAsync(int id);

    // ==================== Métodos de Conteo y Existencia ====================

    /// <summary>
    /// Obtiene el número total de entidades en la base de datos.
    /// </summary>
    /// <returns>Cantidad total de entidades</returns>
    Task<int> CountAsync();

    /// <summary>
    /// Obtiene el número de entidades que cumplen con el predicado especificado.
    /// </summary>
    /// <param name="predicate">Expresión lambda que define los criterios de conteo</param>
    /// <returns>Cantidad de entidades que cumplen con los criterios</returns>
    Task<int> CountAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Verifica si existe una entidad con el identificador especificado.
    /// </summary>
    /// <param name="id">Identificador de la entidad a verificar</param>
    /// <returns>True si existe, False en caso contrario</returns>
    Task<bool> ExistsAsync(int id);

    /// <summary>
    /// Verifica si existe al menos una entidad que cumpla con el predicado especificado.
    /// </summary>
    /// <param name="predicate">Expresión lambda que define los criterios de existencia</param>
    /// <returns>True si existe al menos una entidad, False en caso contrario</returns>
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

    // ==================== Paginación ====================

    /// <summary>
    /// Obtiene un conjunto paginado de entidades con filtro opcional.
    /// Útil para mostrar listados grandes de datos en páginas.
    /// </summary>
    /// <param name="pageNumber">Número de página a obtener (comienza en 1)</param>
    /// <param name="pageSize">Cantidad de elementos por página</param>
    /// <param name="filter">Filtro opcional para aplicar a los datos</param>
    /// <returns>Tupla con los elementos de la página y el total de registros</returns>
    Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
        int pageNumber, 
        int pageSize, 
        Expression<Func<T, bool>>? filter = null);

    // ==================== Guardado de cambios ====================

    /// <summary>
    /// Guarda todos los cambios pendientes en la base de datos.
    /// </summary>
    /// <returns>Número de entidades afectadas por el guardado</returns>
    Task<int> SaveChangesAsync();
}