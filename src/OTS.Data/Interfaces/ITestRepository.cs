using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Data.Entities;

namespace OTS.Data.Interfaces
{
    public interface ITestRepository
    {
        Task<TestViewModel> FindById(Guid request);
        Task<ICollection<TestViewModel>> FindAll(FilterModel filter);
        Task<bool> Create(TestCreateModel request);
        Task<bool> UpdateTest(TestUpdateModel request);
        Task<bool> DeleteTest(TestModel request);
    }
}
