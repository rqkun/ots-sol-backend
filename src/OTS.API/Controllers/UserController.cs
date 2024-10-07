using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OTS.Data.Entities;
using OTS.Data.Models;
using OTS.Service.Interfaces;
using OTS.Service.Services;
using PasswordGenerator;

namespace OTS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        public UserController(IUserService userService, ITokenService tokenService, IEmailService emailService)
        {
            this._userService = userService;
            this._tokenService = tokenService;
            this._emailService = emailService;
        }

        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            IdentityResult result = await _userService.Register(request);
            if (result.Succeeded)
            {
                var token = await _userService.GetVerifyToken(request.Email);
                var confirmationLink = Url.Action(nameof(VerifyEmail), "Authentication", new { token, email = request.Email }, Request.Scheme);
                var message = new MessageModel(new string[] { request.Email! }, "Confirmation email link", confirmationLink!);
                _emailService.SendEmail(message);
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
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = await _userService.Login(request);
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

        [HttpGet]
        [Route("verify")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyEmail(string token, string email)
        {
            var result = await _userService.VerifyGmail(email, token);
            if (result.Succeeded)
            {
                return Ok("Verify Successful.");
            }
            else return StatusCode(500, result.Errors);
        }
        [HttpPost]
        [Route("resetpassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(string email)
        {

            Password passwordGen = new(includeLowercase: true, includeUppercase: true, includeNumeric: true, includeSpecial: true, passwordLength: 16);
            string password = passwordGen.Next();
            var token = await _userService.GetPasswordResetToken(email);
            var resetLink = Url.Action(nameof(ResetPassword), "UserController", new { token, email, password}, Request.Scheme);
            var message = new MessageModel(new string[] { email! }, "Reset Password Link", resetLink!);
            var process = await _emailService.SendEmail(message);
            if (token != null)
            {
               
                return Ok("Email Sent Successful.");
            }
            else return StatusCode(500,"Password Reset Token Empty.");
        }


        [HttpGet]
        [Route("resetpassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(string token, string email, string password)
        {
            var result = await _userService.ResetPassword(email, token, password);
            if (result.Succeeded)
            {
                return Ok("Verify Successful.");
            }
            else return StatusCode(500, result.Errors);
        }

        [HttpPost]
        [Route("changepassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel request)
        {
            var result = await _userService.ChangePassword(request);
            if (result)
            {
                return Ok("Verify Successful.");
            }
            else return StatusCode(500, false);
        }

    }
}
