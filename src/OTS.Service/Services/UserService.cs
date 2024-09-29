using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using OTS.Data.Entities;
using OTS.Data.Interfaces;
using OTS.Data.Models;
using OTS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper, IRoleRepository roleRepository)
        { 
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<IdentityResult> Register(RegisterModel req)
        {
            return await _userRepository.Register(req);
        }
        public async Task<UserModel> Login(LoginModel req)
        {
            return await _userRepository.Login(req);
        }
        public async Task<UserModel> Get(string email)
        {
            return await _userRepository.Get(email);
        }

        public async Task<UserModel> Get(Guid guid)
        {
            return await _userRepository.Get(guid);
        }

        public async Task<List<UserModel>> GetAll(FilterModel filter)
        {
            return await _userRepository.GetAll(filter);
        }

        public async Task<IdentityResult> Delete(Guid guid)
        {
            return await _userRepository.Delete(guid);
        }

        public async Task<bool> UpdateAvatar(string email, string seed)
        {
            return await _userRepository.UpdateAvatar(email,seed);
        }

        public async Task<string> GetOTP(string email)
        {
            return await _userRepository.GetOTP(email);
        }
    }
}
