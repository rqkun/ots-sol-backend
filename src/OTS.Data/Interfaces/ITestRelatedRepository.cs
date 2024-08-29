using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Data.Entities;

namespace OTS.Data.Interfaces
{
    public interface ITestRelatedRepository
    {
        Task<bool> Create(TestCreateModel request);
    }
}
