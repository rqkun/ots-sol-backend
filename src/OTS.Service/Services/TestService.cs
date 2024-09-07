using OTS.Data;
using OTS.Data.Interfaces;
using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Service.Interfaces;

namespace OTS.Service.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IUserRepository _userRepository;
        public TestService(ITestRepository testRepository, IUserRepository userRepository)
        {
            _testRepository = testRepository;
            _userRepository = userRepository;
        }

        public async Task<bool> Create(TestCreateModel request)
        {
            _ = await _userRepository.Get(request.CreatorId);
            request.CreateDate = DateTime.Now;
            await _testRepository.Create(request);
            return await Task.FromResult(true);
        }
    }
}
