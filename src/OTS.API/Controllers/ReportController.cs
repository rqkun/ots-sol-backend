using OTS.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OTS.Data.Models;
using OTS.Service.Services;

namespace OTS.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;
        public ReportController(IReportService reportService)
        {
            this._reportService = reportService;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(Guid request)
        {
            var result = await _reportService.GetById(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetAll(FilterModel filter, int page, int limit)
        {
            var result = await _reportService.GetAll(filter, page, limit);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create(ReportCreateModel request)
        {
            var result = await _reportService.Create(request);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update(ReportUpdateModel request)
        {
            var result = await _reportService.Update(request);
            return Ok(result);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> Delete(ReportModel request)
        {
            var result = await _reportService.Delete(request);
            return Ok(result);
        }
    }
}
