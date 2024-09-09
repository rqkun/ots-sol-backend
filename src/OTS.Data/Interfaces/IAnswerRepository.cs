using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Data.Entities;

namespace OTS.Data.Interfaces
{
    public interface IAnswerRepository
    {
        Task<AnswerViewModel> FindById(Guid request);
        Task<ICollection<AnswerViewModel>> FindAll(FilterModel filter);
        Task<bool> Create(AnswerCreateModel request);
        Task<bool> UpdateAnswer(AnswerUpdateModel request);
        Task<bool> DeleteAnswer(AnswerModel request);
    }
}
