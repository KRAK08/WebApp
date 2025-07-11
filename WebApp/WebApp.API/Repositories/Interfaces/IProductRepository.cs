using WebApp.Shared.Entities;

namespace WebApp.API.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetById(int id);

        Task<List<Product>> GetAllAsync();
    }
}