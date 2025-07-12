using WebApp.Shared.Entities;

namespace WebApp.API.Repositories.Interfaces
{
    public interface IBrandRepository
    {
        Task<Brand> GetById(int id);

        Task<List<Brand>> GetAllAsync();
    }
}