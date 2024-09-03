using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Data.Entities;

namespace OTS.Data.Interfaces
{
    internal interface IQuestionRepository
    {
        Task<QuestionViewModel> GetById(Guid request);
        Task<ICollection<QuestionViewModel>> GetAll();
        Task<bool> Create(QuestionCreateModel request);
        Task<bool> Update(QuestionUpdateModel request);
        Task<bool> Delete(QuestionModel request);
    }
}
