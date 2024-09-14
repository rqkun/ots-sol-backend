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
        Task<IdentityResult> SignUp(SignUpModel req);
        Task<UserModel> SignIn(SignInModel req);
        Task<UserModel> Get(string email);
        Task<UserModel> Get(Guid guid);
        Task<List<UserModel>> GetAll(FilterModel filter);
        Task<IdentityResult> Delete(Guid guid);
    }
}
