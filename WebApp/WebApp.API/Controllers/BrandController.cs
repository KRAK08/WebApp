using Microsoft.AspNetCore.Mvc;
using WebApp.API.UnitsOfWork.Interfaces;
using WebApp.Shared.Entities;

namespace WebApp.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class BrandController : GenericController<Brand>
    {
        private readonly IBrandUnitOfWork _brandUnitOfWork;

        public BrandController(IGenericUnitOfWork<Brand> unitOfWork, IBrandUnitOfWork brandUnitOfWork) : base(unitOfWork)
        {
            _brandUnitOfWork = brandUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAllAsync()
        {
            var list = await _brandUnitOfWork.GetAllAsync();
            if (list == null)
            {
                return NotFound("No hay registros");
            }
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var data = await _brandUnitOfWork.GetById(id);
            if (data == null)
            {
                return NotFound("No existe el registro");
            }
            return Ok(data);
        }
    }
}