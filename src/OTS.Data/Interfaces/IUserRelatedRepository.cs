using OTS.Data.Models;
using OTS.Data.ViewModels;
using OTS.Data.Entities;

namespace OTS.Data.Interfaces
{
    public interface IUserRelatedRepository
    {
        Task<UserModel> GetById(Guid request);
    }
}
