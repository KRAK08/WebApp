using WebApp.Shared.Entities;

namespace WebApp.API.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllAsync();

        Task<Order> GetById(int id);

        Task<bool> CreateAsync(int userId, List<ProductOrder> products);
    }
}