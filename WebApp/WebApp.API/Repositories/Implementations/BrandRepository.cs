using Microsoft.EntityFrameworkCore;
using WebApp.API.Data;
using WebApp.API.Repositories.Interfaces;
using WebApp.Shared.Entities;

namespace WebApp.API.Repositories.Implementations
{
    public class BrandRepository : GenericRepository<Brand>, IBrandRepository
    {
        private readonly DataContext _dataContext;

        public BrandRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override async Task<List<Brand>> GetAllAsync()
        {
            var data = await _dataContext.Brands.Include(b => b.Products).ToListAsync();
            return data;
        }

        public override async Task<Brand> GetById(int id)
        {
            var brand = await _dataContext.Brands
                                          .Include(b => b.Products)
                                          .FirstOrDefaultAsync(b => b.Id == id);
            return brand!;
        }
    }
}