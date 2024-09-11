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
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        private readonly IMapper _mapper;
        protected readonly OTsystemDB _dbContext;
        public AnswerRepository(OTsystemDB dbContext, IMapper mapper) : base(dbContext)
        {
            this._mapper = mapper;
            this._dbContext = dbContext;
        }

        public async Task<AnswerViewModel> FindById(Guid request)
        {
            var foundAnswer = this.GetById(request) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.AnswerNotFound);
            try
            {
                var answer = _mapper.Map<AnswerViewModel>(foundAnswer);
                return await Task.FromResult<AnswerViewModel>(answer); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<ICollection<AnswerViewModel>> FindAll(FilterModel filter)
        {
            var foundAnswers = await Entities.Where(a => a.IsDeleted == filter.IsDeleted).ToListAsync() ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.AnswerNotFound);
            try
            {
                var answerList = new List<AnswerViewModel>();
                foreach (var answer in foundAnswers)
                {
                    var obj = _mapper.Map<AnswerViewModel>(answer);
                    answerList.Add(obj);
                }
                return await Task.FromResult(answerList); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<bool> Create(AnswerCreateModel request)
        {
            try
            {
                var newAnswer = _mapper.Map<Answer>(request);
                newAnswer.AnswerId = Guid.NewGuid();

                await this.Add(newAnswer);
                return await Task.FromResult(true); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<bool> UpdateAnswer(AnswerUpdateModel request)
        {
            var foundAnswer = await Entities.Where(a => a.IsDeleted == false).FirstOrDefaultAsync(a => a.AnswerId == request.AnswerId) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.AnswerNotFound);
            try
            {
                var updateAnswer = _mapper.Map<Answer>(request);
                updateAnswer.QuestionId = foundAnswer.QuestionId;

                await this.Update(foundAnswer, updateAnswer);
                return await Task.FromResult(true); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<bool> DeleteAnswer(AnswerModel request)
        {
            var foundAnswer = await Entities.Where(a => a.IsDeleted == false).FirstOrDefaultAsync(a => a.AnswerId == request.AnswerId) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.AnswerNotFound);
            try
            {
                var deleteAnswer = _mapper.Map<Answer>(foundAnswer);
                deleteAnswer.QuestionId = foundAnswer.QuestionId;
                deleteAnswer.IsDeleted = true;

                await this.Update(foundAnswer, deleteAnswer);
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
