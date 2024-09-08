using Microsoft.AspNetCore.Identity;
using OTS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data.Interfaces
{
    public interface IRoleRepository
    {
        Task<IdentityResult> CreateAsync(CreateRoleModel model);
        Task<IdentityResult> DeleteAsync(Guid id);
        Task<RoleModel> Get(Guid id);
        Task<List<RoleModel>> GetAll(FilterModel filter);

    }
}
