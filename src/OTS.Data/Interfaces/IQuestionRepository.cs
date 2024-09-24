using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Data.Entities;

namespace OTS.Data.Interfaces
{
    public interface IQuestionRepository
    {
        Task<QuestionViewModel> Get(Guid request);
        Task<ICollection<QuestionViewModel>> GetAll(FilterModel filter);
        Task<bool> CreateQuestion(QuestionCreateModel request);
        Task<bool> UpdateQuestion(QuestionUpdateModel request);
        Task<bool> DeleteQuestion(QuestionModel request);
    }
}
