using WebApp.Shared.Entities;

namespace WebApp.API.UnitsOfWork.Interfaces
{
    public interface IBrandUnitOfWork
    {
        Task<Brand> GetById(int id);

        Task<List<Brand>> GetAllAsync();
    }
}