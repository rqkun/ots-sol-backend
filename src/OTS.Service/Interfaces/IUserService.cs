using Microsoft.AspNetCore.Identity;
using OTS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Service.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> Register(RegisterModel req);
        Task<UserModel> Login(LoginModel req);
        Task<UserModel> Get(string email);
        Task<UserModel> Get(Guid guid);
        Task<List<UserModel>> GetAll(FilterModel filter);
        Task<bool> UpdateAvatar(string email, string seed);
        Task<IdentityResult> Delete(Guid guid);
        Task<string> GetVerifyToken(string email);
        Task<IdentityResult> VerifyGmail(string email, string token);
        Task<string> GetPasswordResetToken(string email);
        Task<IdentityResult> ResetPassword(string email, string token, string newPassword);
        Task<bool> ChangePassword(ChangePasswordModel model);
    }
}
