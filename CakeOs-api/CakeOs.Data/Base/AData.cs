namespace CakeOs.Data.Base
{
    public abstract class AData<TEntity> : IData<TEntity> where TEntity : class
    {
        // ==================== CONSULTA ====================

        public abstract Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        public abstract Task<IEnumerable<TEntity>> GetAllActiveAsync(CancellationToken cancellationToken = default);

        public abstract Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        // ==================== ESCRITURA ====================

        public abstract Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        public abstract Task<TEntity> UpdateAsync(TEntity entity);

        public abstract Task<bool> SoftDeleteAsync(int id, CancellationToken cancellationToken = default);

        // ==================== ACTIVACIÓN ====================

        public abstract Task<bool> ActivateAsync(int id);

        public abstract Task<bool> DeactivateAsync(int id);

        // ==================== EXISTENCIA ====================

        public abstract Task<bool> ExistsAsync(int id);

        // ==================== SAVE ====================

        public abstract Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}