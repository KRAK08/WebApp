using WebApp.API.Repositories.Interfaces;
using WebApp.API.UnitsOfWork.Interfaces;
using WebApp.Shared.Entities;

namespace WebApp.API.UnitsOfWork.Implementations
{
    public class UserUnitOfWork : GenericUnitOfWork<User>, IUserUnitOfWork
    {
        private readonly IUserRepository _userRepository;

        public UserUnitOfWork(IGeneric<User> generic, IUserRepository userRepository) : base(generic)
        {
            _userRepository = userRepository;
        }

        public override async Task<User> CreateAsync(User entity) => await _userRepository.CreateAsync(entity);

        public override async Task<List<User>> GetAllAsync() => await _userRepository.GetAllAsync();

        public override async Task<User> GetById(int id) => await _userRepository.GetById(id);
    }
}