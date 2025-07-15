using Microsoft.EntityFrameworkCore;
using WebApp.API.Data;
using WebApp.API.Repositories.Interfaces;
using WebApp.Shared.Entities;

namespace WebApp.API.Repositories.Implementations
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        private readonly DataContext _dataContext;

        public RoleRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override async Task<List<Role>> GetAllAsync()
        {
            return await _dataContext.Roles.Include(x => x.Users).ToListAsync();
        }

        public override async Task<Role> GetById(int id)
        {
            var data = await _dataContext.Roles
                                         .Include(x => x.Users)
                                         .FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return null!;
            }
            return data;
        }
    }
}