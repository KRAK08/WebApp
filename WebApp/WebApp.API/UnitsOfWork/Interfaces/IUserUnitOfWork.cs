using WebApp.Shared.Entities;

namespace WebApp.API.UnitsOfWork.Interfaces
{
    public interface IUserUnitOfWork
    {
        Task<List<User>> GetAllAsync();

        Task<User> GetById(int id);

        Task<User> CreateAsync(User entity);
    }
}