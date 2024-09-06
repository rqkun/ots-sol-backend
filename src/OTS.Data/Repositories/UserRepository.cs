using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OTS.Common;
using OTS.Common.ErrorHandle;
using OTS.Data.Entities;
using OTS.Data.Interfaces;
using OTS.Data.Models;
using OTS.Data.ViewModels;

namespace OTS.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        //private readonly IUnitOfWork _uow;
        private readonly IConfiguration _conf;
        private readonly IMapper _mapper;
        protected readonly OTsystemDB _dbContext;
        private readonly UserManager<User> _userManager;
        public UserRepository(OTsystemDB dbContext, UserManager<User> userManager, IMapper mapper, IConfiguration configuration) : base(dbContext)
        {
            //this._uow = uow;
            this._mapper = mapper;
            this._dbContext = dbContext;
            this._userManager = userManager;
            this._conf = configuration;
        }
        public async Task<UserModel> GetById(Guid request)
        {
            var foundUser = await this.GetById(request) ??
                throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.UserNotFound);
            try
            {
                var user = _mapper.Map<UserModel>(foundUser);
                return await Task.FromResult<UserModel>(user); // Return true if the operation succeeds
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
        }
        public async Task<IdentityResult> SignUp(SignUpModel req)
        {
            var userEmail = await _userManager.FindByEmailAsync(req.Email);
            if (userEmail != null)
            {
                throw new Exception("Account existed.");
            }
            var userName = await _userManager.FindByNameAsync(req.Username);
            if (userName != null)
            {
                throw new Exception("Account existed.");
            }

            var user = new User
            {
                AvatarSeed = req.AvatarSeed,
                Email = req.Email,
                UserName = req.Email,
            };
            return await _userManager.CreateAsync(user, req.Password);
        }
        
    }
}
