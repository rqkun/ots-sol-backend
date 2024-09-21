using Azure.Core;
using OTS.Data;
using OTS.Data.Interfaces;
using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Service.Interfaces;

namespace OTS.Service.Services
{
    public class ReportService : IReportService
    {
        private readonly ITestRepository _testRepository;
        private readonly IReportRepository _reportRepository;
        public ReportService(ITestRepository testRepository, IReportRepository reportRepository)
        {
            _testRepository = testRepository;
            _reportRepository = reportRepository;
        }

        public async Task<ReportViewModel> GetById(Guid request)
        {
            var foundReport = await _reportRepository.FindById(request);
            return await Task.FromResult(foundReport);
        }

        public async Task<AllReportViewModel> GetAll(FilterModel filter, int page, int limit)
        {
            var foundReports = await _reportRepository.FindAll(filter, page, limit);
            return await Task.FromResult(foundReports);
        }

        public async Task<bool> Create(ReportCreateModel request)
        {
            _ = await _testRepository.FindById(request.TestId);
            request.ReportDate = DateTime.Now;
            await _reportRepository.Create(request);
            return await Task.FromResult(true);
        }

        public async Task<bool> Update(ReportUpdateModel request)
        {
            _ = await _testRepository.FindById(request.TestId);
            await _reportRepository.UpdateReport(request);
            return await Task.FromResult(true);
        }

        public async Task<bool> Delete(ReportModel request)
        {
            _ = await _testRepository.FindById(request.TestId);
            request.ReportDate = DateTime.Now;
            await _reportRepository.DeleteReport(request);
            return await Task.FromResult(true);
        }
    }
}
