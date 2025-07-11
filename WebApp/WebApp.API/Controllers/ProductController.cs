using Microsoft.AspNetCore.Mvc;
using WebApp.API.UnitsOfWork.Interfaces;
using WebApp.Shared.Entities;

namespace WebApp.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductController : GenericController<Product>
    {
        private readonly IProductUnitOfWork _productUnitOfWork;

        public ProductController(IGenericUnitOfWork<Product> unitOfWork, IProductUnitOfWork productUnitOfWork) : base(unitOfWork)
        {
            _productUnitOfWork = productUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAllAsync()
        {
            var list = await _productUnitOfWork.GetAllAsync();
            if (list == null)
            {
                return NotFound("No hay registros");
            }
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var data = await _productUnitOfWork.GetById(id);
            if (data == null)
            {
                return NotFound("No existe el registro");
            }
            return Ok(data);
        }
    }
}