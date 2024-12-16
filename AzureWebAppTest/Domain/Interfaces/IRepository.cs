namespace AzureWebAppTest.Domain.Interfaces;

public interface IRepository<T> where T : IEntity
{
    public Task<T> SaveAsync(T entity);
    public Task<T> GetByIdAsync(Guid id);
    public Task<IEnumerable<T>> GetAllAsync();
    public Task DeleteAsync(Guid id);
    public Task<T> UpdateAsync(T entity);
}