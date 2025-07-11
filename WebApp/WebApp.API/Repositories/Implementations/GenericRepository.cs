using Microsoft.EntityFrameworkCore;
using WebApp.API.Data;
using WebApp.API.Repositories.Interfaces;

namespace WebApp.API.Repositories.Implementations
{
    public class GenericRepository<T> : IGeneric<T> where T : class
    {
        private readonly DataContext _dataContext;
        private DbSet<T> _dataSet;

        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
            _dataSet = _dataContext.Set<T>();
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            await _dataContext.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> DeleteAsync(int id)
        {
            bool state = false;
            var data = await _dataSet.FindAsync(id);
            if (data != null)
            {
                _dataSet.Remove(data);
                await _dataContext.SaveChangesAsync();
                state = true;
            }
            return state;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _dataSet.ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            var data = await _dataSet.FindAsync(id);
            if (data == null)
            {
                return null!;
            }
            return data;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dataContext.Update(entity);
            await _dataContext.SaveChangesAsync();
            return entity;
        }
    }
}