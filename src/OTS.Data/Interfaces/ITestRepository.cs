using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Data.Entities;

namespace OTS.Data.Interfaces
{
    public interface ITestRepository
    {
        Task<TestViewModel> GetById(Guid request);
        Task<ICollection<TestViewModel>> GetAll();
        Task<bool> Create(TestCreateModel request);
        Task<bool> Update(TestUpdateModel request);
        Task<bool> Delete(TestModel request);
    }
}
