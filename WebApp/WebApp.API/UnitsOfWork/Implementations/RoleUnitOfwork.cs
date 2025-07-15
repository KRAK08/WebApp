using WebApp.API.Repositories.Interfaces;
using WebApp.API.UnitsOfWork.Interfaces;
using WebApp.Shared.Entities;

namespace WebApp.API.UnitsOfWork.Implementations
{
    public class RoleUnitOfwork : GenericUnitOfWork<Role>, IRoleUnitOfWork
    {
        private readonly IRoleRepository _roleRepository;

        public RoleUnitOfwork(IGeneric<Role> generic, IRoleRepository roleRepository) : base(generic)
        {
            _roleRepository = roleRepository;
        }

        public override async Task<List<Role>> GetAllAsync() => await _roleRepository.GetAllAsync();

        public override async Task<Role> GetById(int id) => await _roleRepository.GetById(id);
    }
}