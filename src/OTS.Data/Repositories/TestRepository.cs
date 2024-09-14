using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using OTS.Common;
using OTS.Common.ErrorHandle;
using OTS.Data.Entities;
using OTS.Data.Interfaces;
using OTS.Data.Models;
using OTS.Data.ViewModels;


namespace OTS.Data.Repositories
{
    public  class TestRepository : Repository<Test>, ITestRepository
    {
        //private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        protected readonly OTsystemDB _dbContext;
        public TestRepository(OTsystemDB dbContext, /*UnitOfWork uow,*/ IMapper mapper) : base(dbContext)
        {
            //this._uow = uow;
            this._mapper = mapper;
            this._dbContext = dbContext;
        }

        public async Task<TestViewModel> FindById(Guid request)
        {
            var foundTest = this.GetById(request) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.TestNotFound);
            try
            {
                var test = _mapper.Map<TestViewModel>(foundTest);
                return await Task.FromResult<TestViewModel>(test); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<AllTestViewModel> FindAll(FilterModel filter, int page, int limit)
        {
            page = page != 0 ? page : 1;
            limit = limit != 0 ? limit : 10;
            var foundTests = await Entities
                .Include(q => q.QuestionForTests).ThenInclude(qft => qft.Question).ThenInclude(q => q.Answers)
                .Where(t => t.IsDeleted == filter.IsDeleted).ToListAsync() ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.TestNotFound);
            try
            {
                var testList = new List<TestViewModel>();
                foreach (var test in foundTests)
                { 
                    var obj = _mapper.Map<TestViewModel>(test);
                    testList.Add(obj);
                }
                int totalCount = testList.Count;
                testList = testList.Skip((page -1) * limit).Take(limit).ToList();
                AllTestViewModel result = new AllTestViewModel()
                {
                    Total = totalCount,
                    Page = page,
                    Limit = limit,
                    TestViewModels = testList
                };
                return await Task.FromResult(result); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<bool> Create(TestCreateModel request)
        {
            try
            {
                var newTest = _mapper.Map<Test>(request);
                //newTest.TestId = Guid.NewGuid();

                await this.Add(newTest);
                return await Task.FromResult(true); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<bool> UpdateTest(TestUpdateModel request)
        {
            var foundTest = await Entities.Where(t => t.IsDeleted == false).FirstOrDefaultAsync(t => t.TestId == request.TestId) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.TestNotFound);
            try
            {
                var updateTest = _mapper.Map<Test>(request);
                updateTest.CreatorId = foundTest.CreatorId;

                await this.Update(foundTest, updateTest);
                return await Task.FromResult(true); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<bool> DeleteTest(TestModel request)
        {
            var foundTest = await Entities.Where(t => t.IsDeleted == false).FirstOrDefaultAsync(t => t.TestId == request.TestId) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.TestNotFound);
            try
            {
                var deleteTest = _mapper.Map<Test>(foundTest);
                deleteTest.CreatorId = foundTest.CreatorId;
                deleteTest.IsDeleted = true;

                await this.Update(foundTest, deleteTest);
                return await Task.FromResult(true); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }
    }
}
