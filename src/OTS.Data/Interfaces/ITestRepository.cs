using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Data.Entities;

namespace OTS.Data.Interfaces
{
    public interface ITestRepository
    {
        Task<TestViewModel> FindById(Guid request);
        Task<AllTestViewModel> FindByCode(string request, int page, int limit);
        Task<AllTestViewModel> FindAll(FilterModel filter, int page, int limit);
        Task<bool> Create(TestCreateModel request);
        Task<bool> UpdateTest(TestUpdateModel request);
        Task<bool> DeleteTest(TestModel request);
    }
}
