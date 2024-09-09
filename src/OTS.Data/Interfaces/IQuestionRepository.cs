using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Data.Entities;

namespace OTS.Data.Interfaces
{
    public interface IQuestionRepository
    {
        Task<QuestionViewModel> FindById(Guid request);
        Task<ICollection<QuestionViewModel>> FindAll(FilterModel filter);
        Task<bool> Create(QuestionCreateModel request);
        Task<bool> UpdateQuestion(QuestionUpdateModel request);
        Task<bool> DeleteQuestion(QuestionModel request);
    }
}
