using WebApp.Shared.Entities;

namespace WebApp.API.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();

        Task<User> GetById(int id);

        Task<User> CreateAsync(User entity);
    }
}