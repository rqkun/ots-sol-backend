using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OTS.Data.Models;
using OTS.Service.Interfaces;

namespace OTS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(SignUpModel request)
        {
            IdentityResult result = await _userService.SignUp(request);
            if (result.Succeeded)
                return Ok(result);
            else return BadRequest(result.Errors);
        }
    }
}
