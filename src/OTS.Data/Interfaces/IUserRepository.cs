using Microsoft.AspNetCore.Identity;
using OTS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityResult> SignUp(SignUpModel req);
        Task<UserModel> Get(Guid request);
        Task<UserModel> Get(string request);
        Task<ICollection<UserModel>> GetAll(FilterModel filter);
        Task<bool> ChangePassword(ChangePasswordModel model);
        Task<bool> ResetPassword(ResetPasswordModel model);
    }
}
