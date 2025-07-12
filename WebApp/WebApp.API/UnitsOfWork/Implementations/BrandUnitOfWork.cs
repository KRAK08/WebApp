using WebApp.API.Repositories.Interfaces;
using WebApp.API.UnitsOfWork.Interfaces;
using WebApp.Shared.Entities;

namespace WebApp.API.UnitsOfWork.Implementations
{
    public class BrandUnitOfWork : GenericUnitOfWork<Brand>, IBrandUnitOfWork
    {
        private readonly IBrandRepository _repository;

        public BrandUnitOfWork(IGeneric<Brand> generic, IBrandRepository repository) : base(generic)
        {
            _repository = repository;
        }

        public override async Task<List<Brand>> GetAllAsync() => await _repository.GetAllAsync();

        public override async Task<Brand> GetById(int id) => await _repository.GetById(id);
    }
}