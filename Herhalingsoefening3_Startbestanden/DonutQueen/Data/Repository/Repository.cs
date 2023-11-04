using Microsoft.EntityFrameworkCore;

namespace DonutQueen.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DonutQueenContext _context;

        public Repository(DonutQueenContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
            }
            catch (Exception e)
            {
                throw new Exception("" + e.Message);
            }
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IQueryable<TEntity> Search()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}