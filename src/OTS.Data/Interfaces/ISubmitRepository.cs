using OTS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data.Interfaces
{
    public interface ISubmitRepository
    {
        Task<bool> Create(SubmitCreateModel model);
        Task<SubmitModel> Get(Guid id);
        Task<IEnumerable<SubmitModel>> Get();
        Task<bool> Delete(Guid id);
        Task<bool> Delete(IEnumerable<Guid> idList);
    }
}
