using WebApp.Shared.Entities;

namespace WebApp.API.UnitsOfWork.Interfaces
{
    public interface ICategoryUnitOfWork
    {
        Task<Category> GetById(int id);

        Task<List<Category>> GetAllAsync();
    }
}