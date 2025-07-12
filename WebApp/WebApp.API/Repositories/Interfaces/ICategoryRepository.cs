using WebApp.Shared.Entities;

namespace WebApp.API.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> GetById(int id);

        Task<List<Category>> GetAllAsync();
    }
}