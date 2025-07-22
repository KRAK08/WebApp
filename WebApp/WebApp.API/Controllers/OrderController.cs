using Microsoft.AspNetCore.Mvc;
using WebApp.API.UnitsOfWork.Interfaces;
using WebApp.Shared.Entities;

namespace WebApp.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderUnitOfWork _orderUnitOfWork;

        public OrderController(IOrderUnitOfWork orderUnitOfWork)
        {
            _orderUnitOfWork = orderUnitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var list = await _orderUnitOfWork.GetAllAsync();
            if (list == null)
            {
                return NotFound("No hay registros");
            }
            return Ok(list);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var data = await _orderUnitOfWork.GetById(id);
            if (data == null)
            {
                return NotFound("No existe el registro");
            }
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] OrderDto orderDto)
        {
            var result = await _orderUnitOfWork.CreateAsync(orderDto.UserId, orderDto.Details!);
            if (result == false)
            {
                return BadRequest("Error");
            }
            return Ok(result);
        }
    }
}