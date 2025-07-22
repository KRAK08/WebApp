using WebApp.Shared.Entities;

namespace WebApp.API.UnitsOfWork.Interfaces
{
    public interface IOrderUnitOfWork
    {
        Task<List<Order>> GetAllAsync();

        Task<Order> GetById(int id);

        Task<bool> CreateAsync(int userId, List<ProductOrder> details);
    }
}