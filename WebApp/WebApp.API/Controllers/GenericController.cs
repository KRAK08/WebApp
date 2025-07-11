using Microsoft.AspNetCore.Mvc;
using WebApp.API.UnitsOfWork.Interfaces;

namespace WebApp.API.Controllers
{
    public class GenericController<T> : Controller where T : class
    {
        private readonly IGenericUnitOfWork<T> _unitOfWork;

        public GenericController(IGenericUnitOfWork<T> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            var list = await _unitOfWork.GetAllAsync();
            if (list == null)
            {
                return NotFound("No hay registros");
            }
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> GetAsync(int id)
        {
            var data = await _unitOfWork.GetById(id);
            if (data == null)
            {
                return NotFound("No existe el registro");
            }
            return Ok(data);
        }

        [HttpPost]
        public virtual async Task<IActionResult> PostAsync(T entity)
        {
            var result = await _unitOfWork.CreateAsync(entity);
            if (result == null)
            {
                return BadRequest("Error");
            }
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _unitOfWork.DeleteAsync(id);
            if (result == false)
            {
                return BadRequest("Error");
            }
            return Ok(result);
        }

        [HttpPut]
        public virtual async Task<IActionResult> PutAsync(T entity)
        {
            var result = await _unitOfWork.UpdateAsync(entity);
            if (result == null)
            {
                return BadRequest("Error");
            }
            return Ok(result);
        }
    }
}