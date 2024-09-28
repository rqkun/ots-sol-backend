using Azure.Core;
using OTS.Data;
using OTS.Data.Interfaces;
using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Service.Interfaces;

namespace OTS.Service.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        // private readonly IQuestionForTestRepository _questionForTestRepository;
        private readonly ITestRepository _testRepository;
        public QuestionService(IQuestionRepository questionRepository/*, IQuestionForTestRepository questionForTestRepository*/, ITestRepository testRepository)
        {
            _questionRepository = questionRepository;
            // _questionForTestRepository = questionForTestRepository;
            _testRepository = testRepository;
        }

        public async Task<QuestionViewModel> GetById(Guid request)
        {
            var foundQuestion = await _questionRepository.Get(request);
            return await Task.FromResult(foundQuestion);
        }

        public async Task<ICollection<QuestionViewModel>> GetAll(FilterModel filter)
        {
            var foundQuestions = await _questionRepository.GetAll(filter);
            return await Task.FromResult(foundQuestions);
        }

        public async Task<bool> Create(QuestionCreateModel request)
        {
            await _questionRepository.CreateQuestion(request);
            return await Task.FromResult(true);
        }

        public async Task<bool> Update(QuestionUpdateModel request)
        {
            _ = await _questionRepository.Get(request.QuestionId);
            await _questionRepository.UpdateQuestion(request);
            return await Task.FromResult(true);
        }

        public async Task<bool> Delete(QuestionModel request)
        {
            // _ = await _questionForTestRepository.Get(request.QuestionId);
            await _questionRepository.DeleteQuestion(request);
            return await Task.FromResult(true);
        }

        //public async Task<bool> AddToTest(QuestionForTestCreateModel request)
        //{
        //    _ = await _testRepository.Get(request.TestId);
        //    _ = await _questionRepository.Get(request.QuestionId);
        //    await _questionForTestRepository.CreateQFT(request);
        //    return await Task.FromResult(true);
        //}

        //public async Task<bool> DeleteFromTest(QuestionForTestModel request)
        //{
        //    _ = await _testRepository.Get(request.TestId);
        //    _ = await _questionRepository.Get(request.QuestionId);
        //    var foundQFT = await _questionForTestRepository.Get(request.QuestionId, request.TestId);
        //    await _questionForTestRepository.DeleteQFT(foundQFT);
        //    return await Task.FromResult(true);
        //}
    }
}
