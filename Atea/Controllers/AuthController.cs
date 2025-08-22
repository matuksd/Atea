using Atea.Models;
using Atea.Services;
using Microsoft.AspNetCore.Mvc;

namespace Atea.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _userService.Authenticate(request.Username, request.Password);
            if (user == null)
                return Unauthorized();

            return Ok(new { user.Id, user.Username });
        }
    }
}
