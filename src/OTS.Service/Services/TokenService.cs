using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OTS.Data.Models;
using OTS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OTS.Service.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration configuration) 
        {
            this._configuration = configuration;
            this._key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        }
        public string CreateToken(RegisterModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.Username)
            };
            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDesciptor = new SecurityTokenDescriptor 
            { 
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = cred,
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"]
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDesciptor);
            return tokenHandler.WriteToken(token);

        }
        public string CreateToken(UserModel user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName)
            };
            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDesciptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = cred,
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"]
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDesciptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
