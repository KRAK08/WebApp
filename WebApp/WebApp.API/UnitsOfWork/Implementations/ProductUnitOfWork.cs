using WebApp.API.Repositories.Interfaces;
using WebApp.API.UnitsOfWork.Interfaces;
using WebApp.Shared.Entities;

namespace WebApp.API.UnitsOfWork.Implementations
{
    public class ProductUnitOfWork : GenericUnitOfWork<Product>, IProductUnitOfWork
    {
        private readonly IProductRepository _repository;

        public ProductUnitOfWork(IGeneric<Product> generic, IProductRepository repository) : base(generic)
        {
            _repository = repository;
        }

        public override async Task<Product> GetById(int id) => await _repository.GetById(id);

        public override async Task<List<Product>> GetAllAsync() => await _repository.GetAllAsync();
    }
}