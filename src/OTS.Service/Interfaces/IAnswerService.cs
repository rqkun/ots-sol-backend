using OTS.Data.Models;
using OTS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Service.Interfaces
{
    public interface IAnswerService
    {
        Task<AnswerViewModel> GetById(Guid request);
        Task<ICollection<AnswerViewModel>> GetAll(FilterModel filter);
        Task<bool> Create(AnswerCreateModel request);
        Task<bool> Update(AnswerUpdateModel request);
        Task<bool> Delete(AnswerModel request);
    }
}
