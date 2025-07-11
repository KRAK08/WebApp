using WebApp.API.Repositories.Interfaces;
using WebApp.API.UnitsOfWork.Interfaces;

namespace WebApp.API.UnitsOfWork.Implementations
{
    public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
    {
        private readonly IGeneric<T> _generic;

        public GenericUnitOfWork(IGeneric<T> generic)
        {
            _generic = generic;
        }

        public virtual async Task<T> CreateAsync(T entity) => await _generic.CreateAsync(entity);

        public virtual async Task<bool> DeleteAsync(int id) => await _generic.DeleteAsync(id);

        public virtual async Task<List<T>> GetAllAsync() => await _generic.GetAllAsync();

        public virtual async Task<T> GetById(int id) => await _generic.GetById(id);

        public virtual async Task<T> UpdateAsync(T entity) => await _generic.UpdateAsync(entity);
    }
}