namespace Examer.Server.Data
{
    public interface IBaseRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();   
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> RemoveAsync(TEntity entity);
        Task RemoveAllAsync(IQueryable<TEntity> entities);
    }
}
