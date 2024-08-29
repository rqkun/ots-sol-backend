using OTS.Data;
using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Service.Interfaces;

namespace OTS.Service.Interfaces
{
    public interface ITestService
    {
        public Task<bool> Create(TestCreateModel request);
    }
}
