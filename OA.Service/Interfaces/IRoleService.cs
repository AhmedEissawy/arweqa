using Microsoft.AspNetCore.Identity;
using OA.Service.Implementation.RoleServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IRoleService
    {
        Task<bool> CreateRole(CreateRoleDto role);
        List<RoleResponseDto> GetRoles();
        Task DeleteRole(string roleId);
        Task<List<AdminRolesResponseDto>> GetAdminRoles(string adminId);
        Task<List<string>> GetAdminRolesInLogin(string adminId);
        Task<EditAdminRolesDto> EditAdminRoles(EditAdminRolesDto editAdminRoles);
       
    }
}
