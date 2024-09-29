using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OTS.Common;
using OTS.Common.ErrorHandle;
using OTS.Data.Entities;
using OTS.Data.Interfaces;
using OTS.Data.Models;
using OTS.Data.ViewModels;
using static OTS.Common.ErrorHandle.ErrorMessages;

namespace OTS.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        //private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        protected readonly OTsystemDB _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public UserRepository(OTsystemDB dbContext, UserManager<User> userManager, SignInManager<User> signinManager, IMapper mapper) : base(dbContext)
        {
            //this._uow = uow;
            this._mapper = mapper;
            this._dbContext = dbContext;
            this._userManager = userManager;
            this._signInManager = signinManager;
        }
        public async Task<UserModel> Get(Guid request)
        {
            var foundUser = this.GetById(request) ??
                throw new KeyNotFoundException(KeyNotFoundMessage.UserNotFound);
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
            var foundUser =  await _userManager.FindByEmailAsync(request) ??
                throw new KeyNotFoundException(KeyNotFoundMessage.UserNotFound);
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
        public async Task<List<UserModel>> GetAll(FilterModel filter)
        {
            var list = this.GetAll().Where(x => x.IsDeleted == filter.IsDeleted);
            List<UserModel> modelList = [];
            foreach (var item in list.ToList())
            {
                UserModel submitModel = _mapper.Map<UserModel>(item);
                modelList.Add(submitModel);
            }
            return await Task.FromResult(modelList);
        }
        public async Task<bool> ChangePassword(ChangePasswordModel model)
        {
            
            var foundUser = await _userManager.FindByEmailAsync(model.Email) ??
                 throw new KeyNotFoundException(KeyNotFoundMessage.UserNotFound);
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
                 throw new KeyNotFoundException(KeyNotFoundMessage.UserNotFound);
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

        public async Task<IdentityResult> Delete(Guid id)
        {
            var result = await _userManager.DeleteAsync(this.GetById(id));
            return result;
        }
        public async Task<IdentityResult> Register(RegisterModel req)
        {
            var user = _mapper.Map<User>(req);
            var createdUser = await _userManager.CreateAsync(user, req.Password);
            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                return roleResult;
            }
            else return createdUser;
        }
        public async Task<UserModel> Login(LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email) ?? throw new LoginException(LoginMessage.InvalidCredentials);
            var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
            if (!result.Succeeded) {
                throw new LoginException(LoginMessage.InvalidCredentials);
            }
            try
            {
                var userModel = _mapper.Map<UserModel>(user);
                return userModel;
            }
            catch (Exception e){
                throw new Exception(e.Message); // Return error message
            }
            
        }

        public async Task<bool> UpdateAvatar(string email, string seed)
        {
            var user = await _userManager.FindByEmailAsync(email) ?? throw new LoginException(LoginMessage.InvalidCredentials);
            try
            {
                var oldUser = user;
                user.AvatarSeed = seed;
                await this.Update(oldUser, user);
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public async Task<string> GetOTP(string email)
        {
            var user = await _userManager.FindByEmailAsync(email) ?? throw new LoginException(LoginMessage.InvalidCredentials);
            var otp = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");
            return await Task.FromResult(otp);
        }
    }
}
