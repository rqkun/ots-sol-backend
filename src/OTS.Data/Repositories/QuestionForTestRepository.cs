/*
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

        public async Task<QuestionForTestViewModel> Get(Guid request)
        {
            var foundQFT = this.GetById(request) ??
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

        public async Task<QuestionForTestModel> Get(Guid questionId, Guid testId)
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

        public async Task<ICollection<QuestionForTestViewModel>> GetAll(FilterModel filter)
        {
            var foundQFTs = await Entities.Where(qft => qft.IsDeleted == filter.IsDeleted).ToListAsync() ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.QuestionForTestNotFound);
            try
            {
                var qftList = new List<QuestionForTestViewModel>();
                foreach (var qft in foundQFTs)
                {
                    var obj = _mapper.Map<QuestionForTestViewModel>(qft);
                    qftList.Add(obj);
                }
                return await Task.FromResult(qftList); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<bool> CreateQFT(QuestionForTestCreateModel request)
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

        public async Task<bool> UpdateQFT(QuestionForTestModel request)
        {
            var foundQFT = await Entities.Where(qft => qft.IsDeleted == false).FirstOrDefaultAsync(qft => qft.QuestionForTestId == request.QuestionForTestId) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.QuestionForTestNotFound);
            try
            {
                var updateQFT = _mapper.Map<QuestionForTest>(request);
                updateQFT.QuestionId = foundQFT.QuestionForTestId;
                updateQFT.TestId = foundQFT.TestId;

                await this.Update(foundQFT, updateQFT);
                return await Task.FromResult(true); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<bool> DeleteQFT(QuestionForTestModel request)
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
*/