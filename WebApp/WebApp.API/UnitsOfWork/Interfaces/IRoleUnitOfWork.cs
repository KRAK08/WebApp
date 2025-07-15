using WebApp.Shared.Entities;

namespace WebApp.API.UnitsOfWork.Interfaces
{
    public interface IRoleUnitOfWork
    {
        Task<Role> GetById(int id);

        Task<List<Role>> GetAllAsync();
    }
}