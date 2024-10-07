using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OTS.Common.ErrorHandle;
using OTS.Data.Entities;
using OTS.Data.Interfaces;
using OTS.Data.Models;
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

        public async Task<string> GetVerifyToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email) ?? throw new LoginException(LoginMessage.InvalidCredentials);
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            return await Task.FromResult(token);
        }

        public async Task<IdentityResult> VerifyGmail(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email) ?? throw new LoginException(LoginMessage.InvalidCredentials);
            var result = await _userManager.ConfirmEmailAsync(user, token);
            return await Task.FromResult(result);
        }

        public async Task<string> GetPasswordResetToken(string email)
        {
            var user = await _userManager.FindByEmailAsync(email) ?? throw new KeyNotFoundException(KeyNotFoundMessage.UserNotFound);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            return await Task.FromResult(token);
        }
        public async Task<IdentityResult> ResetPassword(string email, string token, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email) ?? throw new KeyNotFoundException(KeyNotFoundMessage.UserNotFound);
            var result = await _userManager.ResetPasswordAsync(user, token, newPassword);
            return await Task.FromResult(result);
        }
        public async Task<bool> ChangePassword(ChangePasswordModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email) ?? throw new KeyNotFoundException(KeyNotFoundMessage.UserNotFound);
            var result = await _userManager.CheckPasswordAsync(user, model.NewPassword);
            return await Task.FromResult(result);
        }
    }
}
