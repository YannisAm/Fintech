using Fintech.Server.Services.UserService;
using Fintech.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fintech.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<int>>> CreateUser(RegisterUser user)
        {
            var result = await _userService.CreateUserAsync(user);
            return Ok(result);
        }
    }
}
