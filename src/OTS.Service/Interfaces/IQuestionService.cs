using OTS.Data.Models;
using OTS.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Service.Interfaces
{
    public interface IQuestionService
    {
        Task<QuestionViewModel> GetById(Guid request);
        Task<ICollection<QuestionViewModel>> GetAll(FilterModel filter);
        Task<bool> Create(QuestionCreateModel request);
        Task<bool> Update(QuestionUpdateModel request);
        Task<bool> Delete(QuestionModel request);
        //Task<bool> AddToTest(QuestionForTestCreateModel request);
        //Task<bool> DeleteFromTest(QuestionForTestModel request);
    }
}
