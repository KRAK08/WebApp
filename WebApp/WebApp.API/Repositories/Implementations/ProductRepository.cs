using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApp.API.Data;
using WebApp.API.Repositories.Interfaces;
using WebApp.Shared.Entities;

namespace WebApp.API.Repositories.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext _dataContext;

        public ProductRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override async Task<List<Product>> GetAllAsync()
        {
            var data = await _dataContext.Products
                                         .Include(p => p.Brand)
                                         .Include(p => p.Category)
                                         .ToListAsync();
            return data;
        }

        public override async Task<Product> GetById(int id)
        {
            var data = await _dataContext.Products
                                   .Include(p => p.Brand)
                                   .Include(p => p.Category)
                                   .FirstOrDefaultAsync(p => p.Id == id);
            return data!;
        }
    }
}