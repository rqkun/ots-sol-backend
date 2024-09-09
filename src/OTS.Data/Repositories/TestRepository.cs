using System;
using System.Collections.Generic;
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

        public async Task<Test> GetEntity(Guid id)
        {
            var foundEntity = await Entities.FirstOrDefaultAsync(t => t.TestId == id) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.TestNotFound);
            try
            {
                return await Task.FromResult<Test>(foundEntity); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<TestViewModel> GetById(Guid request)
        {
            var foundTest = await Entities.Where(t => t.IsDeleted == false).FirstOrDefaultAsync(t => t.TestId == request) ??
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

        public new async Task<ICollection<TestViewModel>> GetAll()
        {
            var foundTests = await Entities.Where(t => t.IsDeleted == false).ToListAsync() ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.TestNotFound);
            try
            {
                var testList = new List<TestViewModel>();
                foreach (var test in foundTests)
                { 
                    var obj = _mapper.Map<TestViewModel>(test);
                    testList.Add(obj);
                }
                return await Task.FromResult(testList); // Return true if the operation succeeds
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
