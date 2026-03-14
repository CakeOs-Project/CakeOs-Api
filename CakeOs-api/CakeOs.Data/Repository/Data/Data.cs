using CakeOs.Data.Interfaz.IData;
using CakeOs.Entity.Context;
using CakeOS.Entity.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Repository.Data
{
    /// <summary>
    /// Implementación genérica del repositorio de datos que proporciona
    /// operaciones CRUD básicas y funcionalidades comunes para todas las entidades.
    /// </summary>
    /// <typeparam name="T">El tipo de entidad del dominio, debe heredar de BaseDomain.</typeparam>
    public class Data<T> : IData<T> where T : BaseDomain
    {
        private readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        /// <summary>
        /// Inicializa una nueva instancia de la clase Data.
        /// </summary>
        /// <param name="context">Contexto de base de datos de Entity Framework.</param>
        public Data(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        /// <summary>
        /// Agrega una nueva entidad a la base de datos de forma asíncrona.
        /// </summary>
        /// <param name="entity">La entidad a agregar.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>La entidad agregada.</returns>
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            return entity;
        }

        /// <summary>
        /// Elimina físicamente una entidad de la base de datos mediante su identificador.
        /// </summary>
        /// <param name="id">El identificador de la entidad.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>True si la entidad fue encontrada y eliminada; de lo contrario, false.</returns>
        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbSet.FindAsync(new object[] { id }, cancellationToken);
            if (entity == null) return false;

            _dbSet.Remove(entity);
            return true;
        }

        /// <summary>
        /// Obtiene todas las entidades de la base de datos.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Una colección de todas las entidades.</returns>
        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Obtiene una entidad específica por su identificador.
        /// </summary>
        /// <param name="id">El identificador de la entidad.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>La entidad encontrada o null si no se encuentra.</returns>
        public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        /// <summary>
        /// Actualiza una entidad existente en el contexto.
        /// </summary>
        /// <param name="entity">La entidad con los datos actualizados.</param>
        /// <returns>La entidad actualizada.</returns>
        public Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.FromResult(entity);
        }

        /// <summary>
        /// Activa una entidad (establece IsActive = true) de forma lógica.
        /// </summary>
        /// <param name="id">El identificador de la entidad a activar.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>True si la entidad fue activada exitosamente; de lo contrario, false.</returns>
        public async Task<bool> ActivateAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbSet.FindAsync(new object[] { id }, cancellationToken);
            if (entity == null) return false;

            entity.IsActive = true;
            _dbSet.Update(entity);
            return true;
        }

        /// <summary>
        /// Desactiva una entidad (establece IsActive = false) de forma lógica.
        /// </summary>
        /// <param name="id">El identificador de la entidad a desactivar.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>True si la entidad fue desactivada exitosamente; de lo contrario, false.</returns>
        public async Task<bool> DeactivateAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbSet.FindAsync(new object[] { id }, cancellationToken);
            if (entity == null) return false;

            entity.IsActive = false;
            _dbSet.Update(entity);
            return true;
        }

        /// <summary>
        /// Verifica si una entidad existe en la base de datos.
        /// </summary>
        /// <param name="id">El identificador de la entidad a buscar.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>True si la entidad existe; de lo contrario, false.</returns>
        public async Task<bool> ExistsAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AnyAsync(e => e.Id == id, cancellationToken);
        }

        /// <summary>
        /// Obtiene una lista paginada de entidades.
        /// </summary>
        /// <param name="pageNumber">El número de la página (comenzando por 1).</param>
        /// <param name="pageSize">La cantidad de registros por página.</param>
        /// <param name="filter">Filtro opcional (no implementado en esta versión genérica).</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Una tupla con los elementos paginados y el conteo total de elementos.</returns>
        public async Task<(IEnumerable<T> Items, int TotalCount)> GetPagedAsync(
            int pageNumber, int pageSize, string? filter = null, CancellationToken cancellationToken = default)
        {
            IQueryable<T> query = _dbSet.AsNoTracking();

            var totalCount = await query.CountAsync(cancellationToken);
            var items = await query.Skip((pageNumber - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync(cancellationToken);

            return (items, totalCount);
        }

        /// <summary>
        /// Guarda de forma asíncrona todos los cambios realizados en el contexto a la base de datos.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>El número de entidades escritas en la base de datos.</returns>
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
