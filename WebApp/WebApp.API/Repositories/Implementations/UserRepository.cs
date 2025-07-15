using Microsoft.EntityFrameworkCore;
using WebApp.API.Data;
using WebApp.API.Helpers;
using WebApp.API.Repositories.Interfaces;
using WebApp.Shared.Entities;

namespace WebApp.API.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly DataContext _dataContext;

        public UserRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override async Task<List<User>> GetAllAsync()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public override async Task<User> GetById(int id)
        {
            var data = await _dataContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (data == null)
            {
                return null!;
            }
            return data;
        }

        public override async Task<User> CreateAsync(User entity)
        {
            entity.Password = EncryptPasswords.EncryptPassword(entity.Password);
            await _dataContext.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }
    }
}