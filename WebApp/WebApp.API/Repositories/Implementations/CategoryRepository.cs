using Microsoft.EntityFrameworkCore;
using WebApp.API.Data;
using WebApp.API.Repositories.Interfaces;
using WebApp.Shared.Entities;

namespace WebApp.API.Repositories.Implementations
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly DataContext _dataContext;

        public CategoryRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public override async Task<Category> GetById(int id)
        {
            var category = await _dataContext.Categories
                                             .Include(c => c.Products)
                                             .FirstOrDefaultAsync(c => c.Id == id);
            return category!;
        }

        public override async Task<List<Category>> GetAllAsync()
        {
            return await _dataContext.Categories.Include(c => c.Products).ToListAsync();
        }
    }
}