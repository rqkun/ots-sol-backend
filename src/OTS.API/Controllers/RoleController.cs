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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            this._roleService = roleService;
        }

        [HttpPost("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CreateRoleModel request)
        {
            try {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                IdentityResult result = await _roleService.Create(request);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
                else return StatusCode(500, result.Errors);

            }
            catch (Exception ex) {
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
                return Ok(await _roleService.GetAll(filter));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var role = await _roleService.Get(id);
                return Ok(role);
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
                IdentityResult result = await _roleService.Delete(id);
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
