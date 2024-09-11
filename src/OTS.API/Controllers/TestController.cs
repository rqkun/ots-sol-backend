using OTS.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OTS.Data.Models;

namespace OTS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        public TestController(ITestService testService)
        {
            this._testService = testService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid request)
        {
            var result = await _testService.GetById(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetAll(FilterModel filter)
        {
            var result = await _testService.GetAll(filter);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(TestCreateModel request)
        {
            var result = await _testService.Create(request);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(TestUpdateModel request)
        {
            var result = await _testService.Update(request);
            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(TestModel request)
        {
            var result = await _testService.Delete(request);
            return Ok(result);
        }
    }
}
