using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Data.Entities;

namespace OTS.Data.Interfaces
{
    public interface IReportRepository
    {
        Task<ReportViewModel> Get(Guid request);
        Task<AllReportViewModel> GetAll(FilterModel filter, int page, int limit);
        Task<bool> CreateReport(ReportCreateModel request);
        Task<bool> UpdateReport(ReportUpdateModel request);
        Task<bool> DeleteReport(ReportModel request);
    }
}
