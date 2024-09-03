using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Data.Entities;

namespace OTS.Data.Interfaces
{
    internal interface IAnswerRepository
    {
        Task<AnswerViewModel> GetById(Guid request);
        Task<ICollection<AnswerViewModel>> GetAll();
        Task<bool> Create(AnswerCreateModel request);
        Task<bool> Update(AnswerUpdateModel request);
        Task<bool> Delete(AnswerModel request);
    }
}
