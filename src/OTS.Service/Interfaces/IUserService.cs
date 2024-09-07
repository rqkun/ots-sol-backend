using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    }
}
