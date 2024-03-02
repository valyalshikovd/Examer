using Examer.Server.Data;
using Microsoft.AspNetCore.Http.HttpResults;
namespace Examer.Server.Data
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly AppDBContext _context;

        public BaseRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public IQueryable<TEntity> GetAll()
        {
            return  _context.Set<TEntity>();
        }

        public async Task<TEntity> RemoveAsync(TEntity entity)
        {

                if (entity == null) throw new ArgumentNullException(nameof(entity));

                _context.Remove(entity);
            await _context.SaveChangesAsync();
                return entity;
            
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

             _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task RemoveAllAsync(IQueryable<TEntity> entities) {
                _context.RemoveRange(entities);
                await _context.SaveChangesAsync();
        }
    }
}
