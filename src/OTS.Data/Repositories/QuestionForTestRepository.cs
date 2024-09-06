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
    public class QuestionForTestRepository : Repository<QuestionForTest>, IQuestionForTestRepository
    {
        private readonly IMapper _mapper;
        protected readonly OTsystemDB _dbContext;
        public QuestionForTestRepository(OTsystemDB dbContext, IMapper mapper) : base(dbContext)
        {
            this._mapper = mapper;
            this._dbContext = dbContext;
        }

        public async Task<QuestionForTest> GetEntity(Guid id)
        {
            var foundEntity = await Entities.FirstOrDefaultAsync(qft => qft.QuestionForTestId == id) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.QuestionForTestNotFound);
            try
            {
                return await Task.FromResult<QuestionForTest>(foundEntity); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<QuestionForTestViewModel> GetById(Guid request)
        {
            var foundQFT = await Entities.Where(qft => qft.IsDeleted == false).FirstOrDefaultAsync(qft => qft.QuestionForTestId == request) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.QuestionForTestNotFound);
            try
            {
                var qft = _mapper.Map<QuestionForTestViewModel>(foundQFT);
                return await Task.FromResult<QuestionForTestViewModel>(qft); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<QuestionForTestModel> GetByQuestionAndTestId(Guid questionId, Guid testId)
        {
            var foundQFT = await Entities.Where(qft => qft.IsDeleted == false).FirstOrDefaultAsync(qft => qft.QuestionId == questionId && qft.TestId == testId) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.QuestionForTestNotFound);
            try
            {
                var qft = _mapper.Map<QuestionForTestModel>(foundQFT);
                return await Task.FromResult<QuestionForTestModel>(qft); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public new async Task<ICollection<QuestionForTestViewModel>> GetAll()
        {
            var foundQFTs = await this.GetAll() ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.QuestionForTestNotFound);
            try
            {
                var qftList = new List<QuestionForTestViewModel>();
                foreach (var qft in foundQFTs)
                {
                    if (qft.IsDeleted == false)
                    {
                        var obj = _mapper.Map<QuestionForTestViewModel>(qft);
                        qftList.Add(obj);
                    }
                }
                return await Task.FromResult(qftList); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<bool> Create(QuestionForTestCreateModel request)
        {
            try
            {
                var newQFT = _mapper.Map<QuestionForTest>(request);
                newQFT.QuestionForTestId = Guid.NewGuid();

                await this.Add(newQFT);
                return await Task.FromResult(true); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<bool> Update(QuestionForTestModel request)
        {
            var foundQFT = await Entities.Where(qft => qft.IsDeleted == false).FirstOrDefaultAsync(qft => qft.QuestionForTestId == request.QuestionForTestId) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.QuestionForTestNotFound);
            try
            {
                var updateQFT = _mapper.Map<QuestionForTest>(request);

                await this.Update(updateQFT);
                return await Task.FromResult(true); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<bool> Delete(QuestionForTestModel request)
        {
            var foundQFT = await Entities.Where(qft => qft.IsDeleted == false).FirstOrDefaultAsync(qft => qft.QuestionForTestId == request.QuestionForTestId) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.QuestionForTestNotFound);
            try
            {
                var deleteQFT = _mapper.Map<QuestionForTest>(foundQFT);
                //deleteQFT.IsDeleted = true;

                this.Remove(deleteQFT);
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
