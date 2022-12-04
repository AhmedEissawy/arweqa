using OA.Data.Domain;
using OA.Repo.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface IUserRepo
    {
        Task<ApplicationUser> CreateUser(ApplicationUser model, string password);
        Task<ApplicationUser> CreateIdentityTeacher(ApplicationUser teacher, string password);  
        Task<bool> Delete(Guid id);
        Task<ApplicationUser> FindChatAdmin();
        Task<ApplicationUser> FindByIdAsync(Guid id);
        Task<ApplicationUser> FindByMobile(string mobile);
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<ApplicationUser> FindByUsernameAsync(string username);
        Task<List<string>> GetTeacherPermessions(Guid teacherId);
        UserClaimsDto GetUserClaims();
        IEnumerable<Guid> GetTeacherSubjects();
        Task<bool> Deactivate(Guid id);
        Task<bool> CheckUserExists(string email);
        Task<List<string>> GetDevicesTokens(List<Guid> usersIds);
        Task<string> GetDeviceToken(Guid userId);
        Task<int> SaveChangesAsync();
    }
}