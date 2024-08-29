using OTS.Data;
using OTS.Data.Interfaces;
using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Service.Interfaces;

namespace OTS.Service.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRelatedRepository;
        private readonly IUserRepository _userRelatedRepository;
        public TestService(ITestRepository testRelatedRepository, IUserRepository userRelatedRepository)
        {
            _testRelatedRepository = testRelatedRepository;
            _userRelatedRepository = userRelatedRepository;
        }

        public async Task<bool> Create(TestCreateModel request)
        {
            _ = await _userRelatedRepository.GetById(request.CreatorId);
            request.CreateDate = DateTime.Now;
            await _testRelatedRepository.Create(request);
            return await Task.FromResult(true);
        }
    }
}
