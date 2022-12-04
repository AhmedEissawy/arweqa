
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OA.Data.Domain;
using OA.Repo.Enums;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OA.Service.Implementation.Infrastructure
{
    public class JwtGenerator : IJwtGenerator
    {
        private readonly SymmetricSecurityKey _key;
        private readonly IConfiguration _config;
        private readonly RoleManager<ApplicationRole> _RoleManager;
        private readonly UserManager<ApplicationUser> _usermanager;
        public JwtGenerator(IConfiguration config, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Secret"]));
            _RoleManager = roleManager;
            _usermanager = userManager;
        }

        public async Task<string> CreateTokenAsync(ApplicationUser user)
        {
            var claims = new List<Claim> {
                new Claim (JwtRegisteredClaimNames.GivenName, user.UserName),
                new Claim (JwtRegisteredClaimNames.Email, user.UserName),
                new Claim (JwtRegisteredClaimNames.NameId, user.Id.ToString()),
            };



            var userClaims = await _usermanager.GetClaimsAsync(user);
            var userRoles = await _usermanager.GetRolesAsync(user);

            claims.AddRange(userClaims);
            claims.Add(new Claim(ClaimTypes.Role, user.UserType));
            if (user.UserType == UserType.Teacher.ToString())
            {
                await addTeacherClaims(user, claims);
            }
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _RoleManager.FindByNameAsync(userRole);
                if (role != null)
                {
                    var roleClaims = await _RoleManager.GetClaimsAsync(role);
                    foreach (Claim roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }



            // generate signing credentials
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(14),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private async Task addTeacherClaims(ApplicationUser user, List<Claim> claims)
        {
            var subjects = (await _usermanager.Users.Include(a=>a.Teacher).ThenInclude(a=>a.TeacherSubjects).FirstOrDefaultAsync(a => a.Id == user.Id)).Teacher.TeacherSubjects.Select(a => a.SubjectId).ToArray();
            claims.Add(new Claim(CustomClaimType.Subjects, JsonSerializer.Serialize(subjects)));
        }
    }
}
