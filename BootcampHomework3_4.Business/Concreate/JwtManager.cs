using BootcampHomework3_4.Business.Abstract;
using BootcampHomework3_4.Business.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BootcampHomework3_4.Business.Concreate
{
    public class JwtManager : IJwtService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public JwtManager(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        public TokenDTO Authenticate(JwtUserDTO user)
        {
            var users = _userService.GetAllUsers();
            if (!users.Any(x => x.UserName == user.UserName && x.Password == user.UserPassword))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, user.UserName)
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new TokenDTO
            {
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
