using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Data.Entities;

namespace OTS.Data.Interfaces
{
    public interface IQuestionForTestRepository
    {
        Task<QuestionForTestViewModel> Get(Guid request);
        Task<QuestionForTestModel> Get(Guid questionId, Guid testId);
        Task<ICollection<QuestionForTestViewModel>> GetAll(FilterModel filter);
        Task<bool> CreateQFT(QuestionForTestCreateModel request);
        Task<bool> UpdateQFT(QuestionForTestModel request);
        Task<bool> DeleteQFT(QuestionForTestModel request);
    }
}
