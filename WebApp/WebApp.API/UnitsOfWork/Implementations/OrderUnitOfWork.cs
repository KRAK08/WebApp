using WebApp.API.Repositories.Interfaces;
using WebApp.API.UnitsOfWork.Interfaces;
using WebApp.Shared.Entities;

namespace WebApp.API.UnitsOfWork.Implementations
{
    public class OrderUnitOfWork : GenericUnitOfWork<Order>, IOrderUnitOfWork
    {
        private readonly IOrderRepository _repository;

        public OrderUnitOfWork(IGeneric<Order> generic, IOrderRepository repository) : base(generic)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(int userId, List<ProductOrder> details) => await _repository.CreateAsync(userId, details);

        public override async Task<List<Order>> GetAllAsync() => await _repository.GetAllAsync();

        public override async Task<Order> GetById(int id) => await _repository.GetById(id);
    }
}