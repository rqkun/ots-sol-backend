using OTS.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OTS.Data.Models;
using OTS.Service.Services;

namespace OTS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        public AnswerController(IAnswerService answerService)
        {
            this._answerService = answerService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid request)
        {
            var result = await _answerService.GetById(request);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _answerService.GetAll();
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(AnswerCreateModel request)
        {
            var result = await _answerService.Create(request);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(AnswerUpdateModel request)
        {
            var result = await _answerService.Update(request);
            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(AnswerModel request)
        {
            var result = await _answerService.Delete(request);
            return Ok(result);
        }
    }
}
