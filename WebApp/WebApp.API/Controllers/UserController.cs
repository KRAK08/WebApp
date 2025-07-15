using Microsoft.AspNetCore.Mvc;
using WebApp.API.UnitsOfWork.Interfaces;
using WebApp.Shared.Entities;

namespace WebApp.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : GenericController<User>
    {
        private readonly IUserUnitOfWork _userUnitOfWork;

        public UserController(IGenericUnitOfWork<User> unitOfWork, IUserUnitOfWork userUnitOfWork) : base(unitOfWork)
        {
            _userUnitOfWork = userUnitOfWork;
        }

        [HttpGet]
        public override async Task<IActionResult> GetAllAsync()
        {
            var list = await _userUnitOfWork.GetAllAsync();
            if (list == null)
            {
                return NotFound("No hay registros");
            }
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public override async Task<IActionResult> GetAsync(int id)
        {
            var data = await _userUnitOfWork.GetById(id);
            if (data == null)
            {
                return NotFound("No existe el registro");
            }
            return Ok(data);
        }

        [HttpPost]
        public override async Task<IActionResult> PostAsync(User entity)
        {
            var result = await _userUnitOfWork.CreateAsync(entity);
            if (result == null)
            {
                return BadRequest("Error");
            }
            return Ok(result);
        }
    }
}