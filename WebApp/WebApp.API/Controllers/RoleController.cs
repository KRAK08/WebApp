using Microsoft.AspNetCore.Mvc;
using WebApp.API.UnitsOfWork.Interfaces;
using WebApp.Shared.Entities;

namespace WebApp.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class RoleController : GenericController<Role>
    {
        private readonly IRoleUnitOfWork _roleUnitOfWork;

        public RoleController(IGenericUnitOfWork<Role> unitOfWork, IRoleUnitOfWork roleUnitOfWork) : base(unitOfWork)
        {
            _roleUnitOfWork = roleUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAllAsync()
        {
            var list = await _roleUnitOfWork.GetAllAsync();
            if (list == null)
            {
                return NotFound("No hay registros");
            }
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var data = await _roleUnitOfWork.GetById(id);
            if (data == null)
            {
                return NotFound("No existe el registro");
            }
            return Ok(data);
        }
    }
}