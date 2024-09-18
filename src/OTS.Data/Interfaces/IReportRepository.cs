using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Data.Entities;

namespace OTS.Data.Interfaces
{
    public interface IReportRepository
    {
        Task<ReportViewModel> FindById(Guid request);
        Task<AllReportViewModel> FindAll(FilterModel filter, int page, int limit);
        Task<bool> Create(ReportCreateModel request);
        Task<bool> UpdateReport(ReportUpdateModel request);
        Task<bool> DeleteReport(ReportModel request);
    }
}
