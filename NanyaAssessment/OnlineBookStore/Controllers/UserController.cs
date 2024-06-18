using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStore.Core.IService;
using OnlineBookStore.Core.Services;
using OnlineBookStore.Data.DTO;
using OnlineBookStore.Model.Entities;

namespace OnlineBookStore.Controllers
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

        [HttpPost("register")]
        public async Task<IActionResult> User([FromBody] UserDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender
                // You can set other properties as needed
            };

            var result = await _userService.AddUserAsync(user);

            if (result.Succeeded)
            {
                return Ok("User Added successfully");
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }  
    }
}
