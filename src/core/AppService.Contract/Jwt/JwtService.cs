using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TimeLogger.AppService.Contract.User;

namespace TimeLogger.AppService.Contract
{
    public class JwtService : IJwtService
    {

        public string Generate(UserView user)
        {
            var secretKey = Encoding.UTF8.GetBytes("MySecretKey123456789");//longer than 16 character
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey),SecurityAlgorithms.HmacSha256Signature);
            var claims = _getClaims(user);
            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = "MyWebsite",
                Audience = "MyWebsite",
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddMinutes(5),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = signingCredentials,
                Subject = new ClaimsIdentity(claims)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken= tokenHandler.CreateToken(descriptor);
            var jwt = tokenHandler.WriteToken(securityToken);
            return jwt;
        }

        private IEnumerable<Claim> _getClaims(UserView user)
        {
            var list = new List<Claim>
            {
              new Claim(ClaimTypes.Name,user.UserName),
              new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
              new Claim(ClaimTypes.MobilePhone,"09176788990")  
            };
            // var roles = new Role[] { new Role { Name = "Admin" } };
            // foreach (var role in roles)
            // {
            //    list.Add(new Claim(ClaimTypes.Role,role.Name)); 
            // }
           // list.Add(new Claim("x","y"));
            return list;
        }
    }
}