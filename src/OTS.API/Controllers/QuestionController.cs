using OTS.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OTS.Data.Models;
using OTS.Service.Services;

namespace OTS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            this._questionService = questionService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid request)
        {
            var result = await _questionService.GetById(request);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll(FilterModel filter)
        {
            var result = await _questionService.GetAll(filter);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(QuestionCreateModel request)
        {
            var result = await _questionService.Create(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddToTest(QuestionForTestCreateModel request)
        {
            var result = await _questionService.AddToTest(request);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(QuestionUpdateModel request)
        {
            var result = await _questionService.Update(request);
            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(QuestionModel request)
        {
            var result = await _questionService.Delete(request);
            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteFromTest(QuestionForTestModel request)
        {
            var result = await _questionService.DeleteFromTest(request);
            return Ok(result);
        }
    }
}
