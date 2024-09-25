using OTS.Data;
using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Service.Interfaces;

namespace OTS.Service.Interfaces
{
    public interface ITestService
    {
        Task<TestViewModel> GetById(Guid request);
        Task<AllTestViewModel> GetByCode(FilterModel filter);
        Task<AllTestViewModel> GetAll(FilterModel filter);
        Task<bool> Create(TestCreateModel request);
        Task<bool> Update(TestUpdateModel request);
        Task<bool> Delete(TestModel request);
    }
}
