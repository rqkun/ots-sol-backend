using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Data.Entities;

namespace OTS.Data.Interfaces
{
    public interface ITestRepository
    {
        Task<TestViewModel> Get(Guid request);
        Task<AllTestViewModel> Get(string request, int page, int limit);
        Task<AllTestViewModel> Get(FilterModel filter, int page, int limit);
        Task<bool> CreateTest(TestCreateModel request);
        Task<bool> UpdateTest(TestUpdateModel request);
        Task<bool> DeleteTest(TestModel request);
    }
}
