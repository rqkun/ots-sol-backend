using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using OTS.Data.Entities;
using OTS.Data.Interfaces;
using OTS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Data.Repositories
{
    public class UserRepository : Repository<UserRepository>, IUserRepository
    {
        private readonly IConfiguration _conf;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        public UserRepository(OTsystemDB dbContext, UserManager<User> userManager, IMapper mapper, IConfiguration configuration) : base(dbContext)
        {
            _mapper = mapper;
            _conf = configuration;
            _userManager = userManager;
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
