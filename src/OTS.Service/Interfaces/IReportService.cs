using OTS.Data;
using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Service.Interfaces;

namespace OTS.Service.Interfaces
{
    public interface IReportService
    {
        Task<ReportViewModel> GetById(Guid request);
        Task<AllReportViewModel> GetAll(FilterModel filter);
        Task<bool> Create(ReportCreateModel request);
        Task<bool> Update(ReportUpdateModel request);
        Task<bool> Delete(ReportModel request);
    }
}
