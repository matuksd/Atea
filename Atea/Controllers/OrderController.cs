using Atea.Models;
using Atea.Services;
using Microsoft.AspNetCore.Mvc;

namespace Atea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;
        private readonly IUserService _userService;

        public OrderController(OrderService orderService, IUserService userService)
        {   
            _orderService = orderService;
            _userService = userService;
        }

        [HttpPost("process")]
        public IActionResult ProcessOrder([FromBody] OrderRequest request)
        {
            var validationResult = ValidateUser(request.UserId);
            if (validationResult != null)
                return validationResult;

            try
            {
                var receipt = _orderService.ProcessOrder(request);
                return Ok(receipt);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("history/{userId}")]
        public IActionResult GetOrderHistory(int userId)
        {
            var validationResult = ValidateUser(userId);
            if (validationResult != null)
                return validationResult;

            var orders = _orderService.GetOrderHistory(userId);
            return Ok(orders);
        }

        private IActionResult? ValidateUser(int userId)
        {
            return !_userService.IsValidUser(userId) ? BadRequest("Invalid user") : null;
        }
    }
}
