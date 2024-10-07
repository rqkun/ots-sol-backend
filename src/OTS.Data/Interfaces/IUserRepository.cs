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
        Task<IdentityResult> Register(RegisterModel req);
        Task<UserModel> Login(LoginModel model);
        Task<UserModel> Get(Guid request);
        Task<UserModel> Get(string request);
        Task<List<UserModel>> GetAll(FilterModel filter);
        Task<IdentityResult> Delete(Guid id);
        Task<bool> UpdateAvatar(string email, string seed);
        Task<string> GetVerifyToken(string email);
        Task<IdentityResult> VerifyGmail(string email, string token);
        Task<string> GetPasswordResetToken(string email);
        Task<IdentityResult> ResetPassword(string email, string token, string newPassword);
        Task<bool> ChangePassword(ChangePasswordModel model);
    }
}
