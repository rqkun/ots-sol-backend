using OTS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Service.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(SignUpModel user);
        string CreateToken(UserModel user);
    }
}
