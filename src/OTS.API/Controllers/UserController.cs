using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OTS.Data.Models;
using OTS.Service.Interfaces;
using OTS.Service.Services;

namespace OTS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        public UserController(IUserService userService, ITokenService tokenService)
        {
            this._userService = userService;
            this._tokenService = tokenService;
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(SignUpModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            IdentityResult result = await _userService.SignUp(request);
            if (result.Succeeded)
            {
                return Ok(
                    new TokenModel
                    {
                        UserName = request.Username,
                        Email = request.Email,
                        Token = _tokenService.CreateToken(request)
                    }
                );
            }
            else return StatusCode(500, result.Errors);
        }
        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(SignInModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _userService.SignIn(request);
            try
            {
                return Ok(
                    new TokenModel
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        Token = _tokenService.CreateToken(user)
                    }
                );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(FilterModel filter)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                return Ok(await _userService.GetAll(filter));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var user = await _userService.Get(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByEmail(string email)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var user = await _userService.Get(email);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateAvatar(string email, string seed)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                return Ok(await _userService.UpdateAvatar(email,seed));
                

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                IdentityResult result = await _userService.Delete(id);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                else return StatusCode(500, result.Errors);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
