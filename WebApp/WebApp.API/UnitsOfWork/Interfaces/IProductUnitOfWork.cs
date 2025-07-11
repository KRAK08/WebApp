using WebApp.Shared.Entities;

namespace WebApp.API.UnitsOfWork.Interfaces
{
    public interface IProductUnitOfWork
    {
        Task<Product> GetById(int id);

        Task<List<Product>> GetAllAsync();
    }
}