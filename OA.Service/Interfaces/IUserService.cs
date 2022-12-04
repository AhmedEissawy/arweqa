using OA.Data.Domain;
using OA.Service.Implementation.UserServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IUserService
    {
        Task<ApplicationUser> CreateUser(RegistrationDto model);
        Task<UserLoginResponseDto> Login(LoginDto loginData);
        Task<StudentLoginResponseDto> StudentLogin(StudentLoginDto loginData);
        Task<TeacherLoginResponseDto> TeacherLogin(LoginDto loginData);
        Task<List<AdminResponseDto>> GetAdmins();
        Task EditAdminProfile(EditAdminProfileDto admin);
        Task ResetPassword(ResetPasswordDto resetPassword);
        Task RemoveAdmin(string id);
        Task<AdminResponseDto> GetAdminById(Guid adminId);
    }
}
