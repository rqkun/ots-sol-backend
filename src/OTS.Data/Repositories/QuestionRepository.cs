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
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly IMapper _mapper;
        protected readonly OTsystemDB _dbContext;
        public QuestionRepository(OTsystemDB dbContext, IMapper mapper) : base(dbContext)
        {
            this._mapper = mapper;
            this._dbContext = dbContext;
        }

        public async Task<Question> GetEntity(Guid id)
        {
            var foundEntity = await Entities.FirstOrDefaultAsync(q => q.QuestionId == id) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.QuestionNotFound);
            try
            {
                return await Task.FromResult<Question>(foundEntity); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<QuestionViewModel> GetById(Guid request)
        {
            var foundQuestion = await Entities.Where(q => q.IsDeleted == false).FirstOrDefaultAsync(q => q.QuestionId == request) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.QuestionNotFound);
            try
            {
                var Question = _mapper.Map<QuestionViewModel>(foundQuestion);
                return await Task.FromResult<QuestionViewModel>(Question); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public new async Task<ICollection<QuestionViewModel>> GetAll()
        {
            var foundQuestions = await Entities.Where(q => q.IsDeleted == false).ToListAsync() ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.QuestionNotFound);
            try
            {
                var QuestionList = new List<QuestionViewModel>();
                foreach (var Question in foundQuestions)
                {
                    var obj = _mapper.Map<QuestionViewModel>(Question);
                    QuestionList.Add(obj);
                }
                return await Task.FromResult(QuestionList); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<bool> Create(QuestionCreateModel request)
        {
            try
            {
                var newQuestion = _mapper.Map<Question>(request);
                newQuestion.QuestionId = Guid.NewGuid();

                await this.Add(newQuestion);
                return await Task.FromResult(true); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<bool> Update(QuestionUpdateModel request)
        {
            var foundQuestion = await Entities.Where(q => q.IsDeleted == false).FirstOrDefaultAsync(q => q.QuestionId == request.QuestionId) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.QuestionNotFound);
            try
            {
                var updateQuestion = _mapper.Map<Question>(request);

                await this.Update(foundQuestion, updateQuestion);
                return await Task.FromResult(true); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }

        public async Task<bool> Delete(QuestionModel request)
        {
            var foundQuestion = await Entities.Where(q => q.IsDeleted == false).FirstOrDefaultAsync(q => q.QuestionId == request.QuestionId) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.QuestionNotFound);
            try
            {
                var deleteQuestion = _mapper.Map<Question>(foundQuestion);
                deleteQuestion.IsDeleted = true;

                await this.Update(foundQuestion, deleteQuestion);
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
