using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Data.Entities;

namespace OTS.Data.Interfaces
{
    public interface IQuestionForTestRepository
    {
        Task<QuestionForTestViewModel> GetById(Guid request);
        Task<QuestionForTestModel> GetByQuestionAndTestId(Guid questionId, Guid testId);
        Task<ICollection<QuestionForTestViewModel>> GetAll();
        Task<bool> Create(QuestionForTestCreateModel request);
        Task<bool> Update(QuestionForTestModel request);
        Task<bool> Delete(QuestionForTestModel request);
    }
}
