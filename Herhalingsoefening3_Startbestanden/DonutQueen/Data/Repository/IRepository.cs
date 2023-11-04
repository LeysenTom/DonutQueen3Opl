namespace DonutQueen.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);

        void Delete(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity?> GetByIdAsync(int id);

        void Save();

        IQueryable<TEntity> Search();

        void Update(TEntity entity);
    }
}