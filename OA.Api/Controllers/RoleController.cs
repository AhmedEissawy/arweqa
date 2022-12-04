using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OA.Data.Domain;
using OA.Service.Implementation.RoleServices.Dtos;
using OA.Service.Interfaces;

namespace OA.Api.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    public class RoleController : ApiControllersBase
    {

        private readonly IRoleService _RoleService;
        public RoleController(IRoleService roleService)
        {
            _RoleService = roleService;
        }


        [HttpPost]
        [Route("api/Role/CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleDto role)
        {
            await _RoleService.CreateRole(role);

            return Ok();

        }



        [HttpGet]
        [Route("api/Role/GetRoles")]
        public IActionResult GetRoles()
        {
            List<RoleResponseDto> roles = _RoleService.GetRoles();

            return Ok(roles);

        }



        [HttpDelete]
        [Route("api/Role/DeleteRole/{roleId}")]
        public async Task<IActionResult> DeleteRole(string roleId)
        {
           await _RoleService.DeleteRole(roleId);

            return NoContent();

        }



        [HttpGet]
        [Route("api/Role/GetAdminRoles/{adminId}")]
        public async Task<IActionResult> GetAdminRoles(string adminId)
        {
            List<AdminRolesResponseDto> adminRoles = await _RoleService.GetAdminRoles(adminId);

            return Ok(adminRoles);

        }



        [HttpPut]
        [Route("api/Role/EditAdminRoles")]
        public async Task<IActionResult> EditAdminRoles(EditAdminRolesDto adminRoles)
        {
            EditAdminRolesDto adminRolesResponse = await _RoleService.EditAdminRoles(adminRoles);

            return Ok(adminRolesResponse);

        }




    }
}
