using Azure.Core;
using OTS.Data;
using OTS.Data.Interfaces;
using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Service.Interfaces;

namespace OTS.Service.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        public AnswerService(IQuestionRepository questionRepository, IAnswerRepository answerRepository) 
        { 
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
        }

        public async Task<AnswerViewModel> GetById(Guid request)
        {
            var foundAnswer = await _answerRepository.GetById(request);
            return await Task.FromResult(foundAnswer);
        }

        public async Task<ICollection<AnswerViewModel>> GetAll()
        {
            var foundAnswers = await _answerRepository.GetAll();
            return await Task.FromResult(foundAnswers);
        }

        public async Task<bool> Create(AnswerCreateModel request)
        {
            _ = await _questionRepository.GetById(request.QuestionId);
            await _answerRepository.Create(request);
            return await Task.FromResult(true);
        }

        public async Task<bool> Update(AnswerUpdateModel request)
        {
            _ = await _answerRepository.GetById(request.AnswerId);
            await _answerRepository.Update(request);
            return await Task.FromResult(true);
        }

        public async Task<bool> Delete(AnswerModel request)
        {
            _ = await _answerRepository.GetById(request.AnswerId);
            await _answerRepository.Delete(request);
            return await Task.FromResult(true);
        }
    }
}
