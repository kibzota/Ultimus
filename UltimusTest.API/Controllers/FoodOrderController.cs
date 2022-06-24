using Microsoft.AspNetCore.Mvc;
using UltimusTest.Domain.Interfaces.Services;

namespace UltimusTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodOrderController: ControllerBase
    {
        private readonly IFoodOrderService _foodService;
        public FoodOrderController(IFoodOrderService foodService) 
        {
            _foodService = foodService;
        }

        [HttpGet("order/{orderCSV}")]
        public IActionResult GetAll(string orderCSV)
        {
            try
            {
                var response = _foodService.Execute(orderCSV);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad Request: {ex.Message}");
            }
        }
    }
}
