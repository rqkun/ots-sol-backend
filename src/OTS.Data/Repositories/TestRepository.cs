using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
        public async Task<bool> Create(TestCreateModel request)
        {
            try
            {
                //var creator = await GetAll().FirstOrDefaultAsync(e => e.CreatorId == request.CreatorId);
                //if (creator == null)
                //{
                //    // Throw a DuplicateException with a custom message
                //    throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.UserNotFound);
                //}

                var newTest = _mapper.Map<Test>(request);
                newTest.TestId = Guid.NewGuid();

                await this.Add(newTest);
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
