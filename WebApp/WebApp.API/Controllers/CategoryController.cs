using Microsoft.AspNetCore.Mvc;
using WebApp.API.UnitsOfWork.Interfaces;
using WebApp.Shared.Entities;

namespace WebApp.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoryController : GenericController<Category>
    {
        private readonly ICategoryUnitOfWork _categoryUnitOfWork;

        public CategoryController(IGenericUnitOfWork<Category> unitOfWork, ICategoryUnitOfWork categoryUnitOfWork) : base(unitOfWork)
        {
            _categoryUnitOfWork = categoryUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAllAsync()
        {
            var list = await _categoryUnitOfWork.GetAllAsync();
            if (list == null)
            {
                return NotFound("No hay registros");
            }
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var data = await _categoryUnitOfWork.GetById(id);
            if (data == null)
            {
                return NotFound("No existe el registro");
            }
            return Ok(data);
        }
    }
}