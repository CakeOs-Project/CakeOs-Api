using CakeOs.Entity.Context;
using CakeOs.Entity.Domain.Base;
using CakeOS.Entity.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace CakeOs.Data.Base
{
    /// <summary>
    /// Implementación genérica del repositorio de datos que proporciona
    /// operaciones CRUD básicas y funcionalidades comunes para todas las entidades.
    /// </summary>
    /// <typeparam name="T">El tipo de entidad del dominio, debe heredar de BaseDomain.</typeparam>
    public class DataBase<T> :  AData<T> where T : BaseDomain
    {
        private readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        /// <summary>
        /// Inicializa una nueva instancia de la clase Data.
        /// </summary>
        /// <param name="context">Contexto de base de datos de Entity Framework.</param>
        public DataBase(ApplicationDbContext context)
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
        public override async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            entity.IsActive = true;
            await _dbSet.AddAsync(entity, cancellationToken);
            return entity;
        }

        /// <summary>
        /// Elimina físicamente una entidad de la base de datos mediante su identificador.
        /// </summary>
        /// <param name="id">El identificador de la entidad.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>True si la entidad fue encontrada y eliminada; de lo contrario, false.</returns>
        public override async Task<bool> SoftDeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id,cancellationToken);
            if (entity == null) return false;

            if (entity is BaseAuditory auditory)
            {
                auditory.IsDeleted = true;
                _dbSet.Update(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Obtiene todas las entidades de la base de datos.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Una colección de todas las entidades.</returns>
        public override async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Obtiene todas las entidades activas de la base de datos.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Una colección de todas las entidades activas.</returns>
        public override async Task<IEnumerable<T>> GetAllActiveAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTracking().Where(e => e.IsActive).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// Obtiene una entidad específica por su identificador.
        /// </summary>
        /// <param name="id">El identificador de la entidad.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>La entidad encontrada o null si no se encuentra.</returns>
        public override async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        /// <summary>
        /// Actualiza una entidad existente en el contexto.
        /// </summary>
        /// <param name="entity">La entidad con los datos actualizados.</param>
        /// <returns>La entidad actualizada.</returns>
        public override Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.FromResult(entity);
        }

        /// <summary>
        /// Activa una entidad (establece IsActive = true) de forma lógica.
        /// </summary>
        /// <param name="id">El identificador de la entidad a activar.</param>
        /// <returns>True si la entidad fue activada exitosamente; de lo contrario, false.</returns>
        public override async Task<bool> ActivateAsync(int id)
        {
            var entity = await _dbSet.FindAsync(new object[] { id });
            if (entity == null) return false;

            entity.IsActive = true;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Desactiva una entidad (establece IsActive = false) de forma lógica.
        /// </summary>
        /// <param name="id">El identificador de la entidad a desactivar.</param>
        /// <returns>True si la entidad fue desactivada exitosamente; de lo contrario, false.</returns>
        public override async Task<bool> DeactivateAsync(int id)
        {
            var entity = await _dbSet.FindAsync(new object[] { id });
            if (entity == null) return false;

            entity.IsActive = false;
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Verifica si una entidad existe en la base de datos.
        /// </summary>
        /// <param name="id">El identificador de la entidad a buscar.</param>
        /// <returns>True si la entidad existe; de lo contrario, false.</returns>
        public override async Task<bool> ExistsAsync(int id)
        {
            return await _dbSet.AnyAsync(e => e.Id == id);
        }

        /// <summary>
        /// Guarda de forma asíncrona todos los cambios realizados en el contexto a la base de datos.
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>El número de entidades escritas en la base de datos.</returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
