using WebApp.Shared.Entities;

namespace WebApp.API.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role> GetById(int id);

        Task<List<Role>> GetAllAsync();
    }
}