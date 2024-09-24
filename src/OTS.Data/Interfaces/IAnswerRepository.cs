using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Data.Entities;

namespace OTS.Data.Interfaces
{
    public interface IAnswerRepository
    {
        Task<AnswerViewModel> Get(Guid request);
        Task<ICollection<AnswerViewModel>> GetAll(FilterModel filter);
        Task<bool> CreateAnswer(AnswerCreateModel request);
        Task<bool> UpdateAnswer(AnswerUpdateModel request);
        Task<bool> DeleteAnswer(AnswerModel request);
    }
}
