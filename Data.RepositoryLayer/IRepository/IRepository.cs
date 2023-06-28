namespace Data.RepositoryLayer.IRepository;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> FindByIdAsync(int id);
        
    Task InsertAsync(TEntity entity);
        
    Task UpdateAsync(TEntity entity);
        
    Task DeleteByIdAsync(int id);
}