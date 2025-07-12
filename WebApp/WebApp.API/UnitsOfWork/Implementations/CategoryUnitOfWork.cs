using WebApp.API.Repositories.Interfaces;
using WebApp.API.UnitsOfWork.Interfaces;
using WebApp.Shared.Entities;

namespace WebApp.API.UnitsOfWork.Implementations
{
    public class CategoryUnitOfWork : GenericUnitOfWork<Category>, ICategoryUnitOfWork
    {
        private readonly ICategoryRepository _repository;

        public CategoryUnitOfWork(IGeneric<Category> generic, ICategoryRepository repository) : base(generic)
        {
            _repository = repository;
        }

        public override async Task<Category> GetById(int id) => await _repository.GetById(id);

        public override async Task<List<Category>> GetAllAsync() => await _repository.GetAllAsync();
    }
}