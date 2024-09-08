using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using OTS.Common.ErrorHandle;
using OTS.Data.Entities;
using OTS.Data.Interfaces;
using OTS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OTS.Data.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly IConfiguration _conf;
        private readonly IMapper _mapper;
        protected readonly OTsystemDB _dbContext;
        private readonly RoleManager<Role> _roleManager;
        public RoleRepository(OTsystemDB dbContext,IConfiguration conf, IMapper mapper, RoleManager<Role> roleManager) : base(dbContext)
        {
            this._dbContext = dbContext;
            this._roleManager = roleManager;
            this._mapper = mapper;
            this._conf = conf;
        }
        public async Task<IdentityResult> CreateAsync(CreateRoleModel model)
        {
            Role role = _mapper.Map<Role>(model); 
            return await _roleManager.CreateAsync(role);
        }
        public async Task<List<RoleModel>> GetAll(FilterModel filter)
        {
            var list = this.GetAll();
            List<RoleModel> modelList = [];
            foreach (var item in list.ToList())
            {
                RoleModel submitModel = _mapper.Map<RoleModel>(item);
                modelList.Add(submitModel);
            }
            return await Task.FromResult(modelList);
        }
        public async Task<RoleModel> Get(Guid id)
        {
            string idString = id.ToString();
            var roleFound = await _roleManager.FindByIdAsync(idString) ?? throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.RoleNotFound);
            return _mapper.Map<RoleModel>(roleFound);
        }
        public async Task<IdentityResult> DeleteAsync(Guid id)
        {
            string idString = id.ToString();
            var roleFound = await _roleManager.FindByIdAsync(idString) ?? throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.RoleNotFound);
            return await _roleManager.DeleteAsync(roleFound);
        }
    }
}
