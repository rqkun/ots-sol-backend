using OTS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data.Interfaces
{
    public interface IBlacklistRepository
    {
        Task<bool> Create(CreateBlackListModel model);
        Task<BlacklistModel> Get(Guid id);
        Task<IEnumerable<BlacklistModel>> GetAll(FilterModel filter);
        Task<bool> Update(BlacklistUpdateModel model);
        Task<bool> Delete(Guid id);
    }
}
