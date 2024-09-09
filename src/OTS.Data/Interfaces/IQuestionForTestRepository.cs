using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Data.Entities;

namespace OTS.Data.Interfaces
{
    public interface IQuestionForTestRepository
    {
        Task<QuestionForTestViewModel> FindById(Guid request);
        Task<QuestionForTestModel> FindByQuestionAndTestId(Guid questionId, Guid testId);
        Task<ICollection<QuestionForTestViewModel>> FindAll(FilterModel filter);
        Task<bool> Create(QuestionForTestCreateModel request);
        Task<bool> Update(QuestionForTestModel request);
        Task<bool> Delete(QuestionForTestModel request);
    }
}
