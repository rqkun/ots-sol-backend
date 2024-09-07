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
        private readonly SignInManager<User> _signInManager;
        public UserRepository(OTsystemDB dbContext, UserManager<User> userManager, SignInManager<User> signinManager, IMapper mapper, IConfiguration configuration) : base(dbContext)
        {
            //this._uow = uow;
            this._mapper = mapper;
            this._dbContext = dbContext;
            this._userManager = userManager;
            this._conf = configuration;
            this._signInManager = signinManager;
        }
        public async Task<UserModel> Get(Guid request)
        {
            var foundUser = this.GetById(request) ??
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
        public async Task<UserModel> Get(string request)
        {
            var foundUser =  _userManager.FindByEmailAsync(request) ??
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
        public async Task<ICollection<UserModel>> GetAll(FilterModel filter)
        {
            var list = this.GetAll();
            ICollection<UserModel> modelList = [];
            foreach (var item in list)
            {
                UserModel submitModel = _mapper.Map<UserModel>(item);
                modelList.Append(submitModel);
            }
            return await Task.FromResult(modelList);
        }
        public async Task<bool> ChangePassword(ChangePasswordModel model)
        {
            
            var foundUser = await _userManager.FindByEmailAsync(model.Email) ??
                 throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.UserNotFound);
            try
            {
                await _userManager.ChangePasswordAsync(foundUser, model.OldPassword, model.NewPassword);
                return await Task.FromResult(true);
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                throw new Exception(ex.Message); // Return error message
            }
            
        }
        public async Task<bool> ResetPassword(ResetPasswordModel model)
        {

            var foundUser = await _userManager.FindByEmailAsync(model.Email) ??
                 throw new KeyNotFoundException(ErrorMessages.KeyNotFoundMessage.UserNotFound);
            try
            {
                await _userManager.ResetPasswordAsync(foundUser,model.Token,model.NewPassword);
                return await Task.FromResult(true);
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

            var user = _mapper.Map<User>(req);
            return await _userManager.CreateAsync(user, req.Password);
        }

    }
}
