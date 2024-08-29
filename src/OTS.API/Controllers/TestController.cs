using OTS.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OTS.Data.Models;

namespace OTS.API.Controllers
{
    /*
    public class TestController : BaseAPIController
    {
        private readonly ITestRelatedService _testRelatedService;
        public TestController(ITestRelatedService testRelatedService)
        {
            Console.WriteLine("Hiiii");
            this._testRelatedService = testRelatedService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create (TestCreateModel request)
        {
            Console.WriteLine("Hiiii");
            request.CreateDate = DateTime.Now;
            var result = await this._testRelatedService.Create(request);
            return Ok(result);
        }
    }
    */
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ITestService _testService;
        public TestController(ITestService testService)
        {
            this._testService = testService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(TestCreateModel request)
        {
            var result = await this._testService.Create(request);
            return Ok(result);
        }
    }
}
