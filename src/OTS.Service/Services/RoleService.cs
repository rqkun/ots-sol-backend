using Microsoft.AspNetCore.Identity;
using OTS.Data.Interfaces;
using OTS.Data.Models;
using OTS.Data.Repositories;
using OTS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository) { 
            this._roleRepository = roleRepository;
        }
        public async Task<RoleModel> Get(Guid id)
        {
            return await _roleRepository.Get(id);
        }
        public async Task<IdentityResult> Create(CreateRoleModel roleModel)
        { 
            return await _roleRepository.CreateAsync(roleModel);
        }
        public async Task<IdentityResult> Delete(Guid id)
        {
            return await _roleRepository.DeleteAsync(id);
        }
        public async Task<List<RoleModel>> GetAll(FilterModel filter)
        {
            return await _roleRepository.GetAll(filter);
        }
    }
}
