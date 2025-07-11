namespace WebApp.API.Repositories.Interfaces
{
    public interface IGeneric<T> where T : class
    {
        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(int id);

        Task<T> GetById(int id);

        Task<List<T>> GetAllAsync();
    }
}