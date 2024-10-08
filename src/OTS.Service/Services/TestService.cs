﻿using Azure.Core;
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

        public async Task<TestViewModel> GetById(Guid request)
        {
            var foundTest = await _testRepository.Get(request);
            return await Task.FromResult(foundTest);
        }

        public async Task<AllTestViewModel> GetByCode(FilterModel filter)
        {
            var foundTests = await _testRepository.GetByCode(filter);
            return await Task.FromResult(foundTests);
        }

        public async Task<AllTestViewModel> GetAll(FilterModel filter)
        {
            var foundTests = await _testRepository.Get(filter);
            return await Task.FromResult(foundTests);
        }

        public async Task<bool> Create(TestCreateModel request)
        {
            _ = await _userRepository.Get(request.CreatorId);
            request.CreateDate = DateTime.Now;
            await _testRepository.CreateTest(request);
            return await Task.FromResult(true);
        }

        public async Task<bool> Update(TestUpdateModel request)
        {
            _ = await _testRepository.Get(request.TestId);
            await _testRepository.UpdateTest(request);
            return await Task.FromResult(true);
        }

        public async Task<bool> Delete(TestModel request)
        {
            _ = await _testRepository.Get(request.TestId);
            await _testRepository.DeleteTest(request);
            return await Task.FromResult(true);
        }
    }
}
