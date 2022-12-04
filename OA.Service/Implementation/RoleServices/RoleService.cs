using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using OA.Data.Domain;
using OA.Repo.Enums;
using OA.Repo.Errors;
using OA.Service.Implementation.RoleServices.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Implementation.RoleServices
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<ApplicationRole> _RoleManager;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly IMapper _Mapper;
        public RoleService(RoleManager<ApplicationRole> roleManager, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _RoleManager = roleManager;
            _usermanager = userManager;
            _Mapper = mapper;
        }



        public async Task<List<AdminRolesResponseDto>> GetAdminRoles(string adminId)
        {
            ApplicationUser user = await _usermanager.FindByIdAsync(adminId);

            List<ApplicationRole> roles = _RoleManager.Roles.ToList();

            List<AdminRolesResponseDto> adminRoles = new List<AdminRolesResponseDto>();


            foreach (ApplicationRole role in roles)
            {

                AdminRolesResponseDto userRoleViewModel = new AdminRolesResponseDto
                {
                    RoleName = role.Name,
                };


                if (await _usermanager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.Selected = true;
                }
                else
                {
                    userRoleViewModel.Selected = false;
                }

                adminRoles.Add(userRoleViewModel);

            }

            return adminRoles;
        }



        public async Task<List<string>> GetAdminRolesInLogin(string adminId)
        {
            ApplicationUser user = await _usermanager.FindByIdAsync(adminId);

           

            List<ApplicationRole> roles = _RoleManager.Roles.ToList();

            List<string> adminRoles = new List<string>();

            if (user.UserType == UserType.Teacher.ToString())
                adminRoles.Add(user.UserType);

                foreach (ApplicationRole role in roles)
            {
                if (await _usermanager.IsInRoleAsync(user, role.Name))
                {
                    adminRoles.Add(role.Name);
                }
              
            }

            return adminRoles;
        }


        public async Task<EditAdminRolesDto> EditAdminRoles(EditAdminRolesDto editAdminRoles)
        {
            ApplicationUser user = await _usermanager.FindByIdAsync(editAdminRoles.AdminId);

            foreach (AdminRolesResponseDto role in editAdminRoles.Roles)
            {
                IdentityResult result = null;

                if ((role.Selected) && !(await _usermanager.IsInRoleAsync(user, role.RoleName)))
                {
                    result = await _usermanager.AddToRoleAsync(user, role.RoleName);
                }
                else if (!(role.Selected) && (await _usermanager.IsInRoleAsync(user, role.RoleName)))
                {
                    result = await _usermanager.RemoveFromRoleAsync(user, role.RoleName);
                }

            }

            return editAdminRoles;
        }



        public async Task<bool> CreateRole(CreateRoleDto role)
        {
            ApplicationRole identityRole = new ApplicationRole
            {
                Name = role.RoleName
            };

            IdentityResult result = await _RoleManager.CreateAsync(identityRole);

            if (result.Succeeded)
            {
                return true;
            }

            throw new RestException(HttpStatusCode.BadRequest, new { messages = "Error creating role" });

        }



        public List<RoleResponseDto> GetRoles()
        {
            IQueryable<ApplicationRole> roles = _RoleManager.Roles;

            List<RoleResponseDto> rolesResponse = _Mapper.Map<List<RoleResponseDto>>(roles);

            return rolesResponse;

        }



        public async Task DeleteRole(string roleId)
        {
            ApplicationRole role = await _RoleManager.FindByIdAsync(roleId);

            if (role == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $"the role with Id = {roleId} not found to delete ...!" });

            IdentityResult result = await _RoleManager.DeleteAsync(role);

            if (!result.Succeeded) throw new RestException(HttpStatusCode.BadRequest, new { message = $"{result.Errors.ToList()}" });

        }



    }
}
