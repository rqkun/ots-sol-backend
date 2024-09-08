using Microsoft.AspNetCore.Identity;
using OTS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Service.Interfaces
{
    public interface IRoleService
    {
        Task<RoleModel> Get(Guid id);
        Task<IdentityResult> Create(CreateRoleModel roleModel);
        Task<IdentityResult> Delete(Guid id);
        Task<List<RoleModel>> GetAll(FilterModel filter);
    }
}
