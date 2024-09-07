using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        { 
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IdentityResult> SignUp(SignUpModel req)
        {
            
            return await _userRepository.SignUp(req);
        }
    }
}
