using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Repo.Enums;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

namespace OA.Repo.Implementation
{
    public class UserRepo : IUserRepo
    {
        private readonly RoleManager<ApplicationRole> _RoleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _accessor;
        private readonly ProjectContext _dbcontext;
        public UserRepo(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor accessor, ProjectContext context, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accessor = accessor;
            _dbcontext = context;
            _RoleManager = roleManager;
        }


        public async Task<ApplicationUser> FindChatAdmin()
        {

            return await _dbcontext.Users.Where(q => q.UserType == UserType.SuperAdmin.ToString() && q.Email != "programmer@prgrammer.com").FirstOrDefaultAsync();

        }



        public async Task<ApplicationUser> CreateUser(ApplicationUser user, string password)
        {
            var DBuser = await _userManager.FindByEmailAsync(user.Email);
            if (DBuser != null) throw new RestException(HttpStatusCode.BadRequest, new { Message = "Email already exists!" });

            DBuser = await _userManager.FindByNameAsync(user.UserName);
            if (DBuser != null) throw new RestException(HttpStatusCode.BadRequest, new { Message = "UserName  already exists!" });

            var result = await _userManager.CreateAsync(user, password);

            if (!result.Succeeded) throw new Exception("Error Craetaing User!");

            return user;

        }


        public async Task<ApplicationUser> CreateIdentityTeacher(ApplicationUser teacher, string password)
        {
            var DBuser = await _userManager.FindByEmailAsync(teacher.Email);

            teacher.UserName = teacher.Email;
            teacher.UserType = UserType.Teacher.ToString();

            if (DBuser != null) throw new RestException(HttpStatusCode.BadRequest, new { Message = "Email already exists!" });

            var result = await _userManager.CreateAsync(teacher, password);

            if (!result.Succeeded) throw new Exception("Error Craetaing Teacher!");

            return teacher;

        }



        public async Task<bool> CheckUserExists(string email)
        {
            return await _dbcontext.Users.Where(u => u.Email == email || u.UserName == email).FirstOrDefaultAsync() != null;
        }


        public async Task<bool> Deactivate(Guid id)
        {
            var DBuser = await _userManager.FindByIdAsync(id.ToString());
            if (DBuser == null) throw new RestException(HttpStatusCode.BadRequest, new { Message = $"User of Id={id}  does not exist!" });
            DBuser.IsActive = (DBuser.IsActive) ? false : true;

            return await _dbcontext.SaveChangesAsync() > 0;

        }



        public async Task<bool> Delete(Guid id)
        {
            var DBuser = await _userManager.FindByIdAsync(id.ToString());
            if (DBuser == null) throw new RestException(HttpStatusCode.BadRequest, new { Message = $"User of Id={id}  does not exist!" });
            var result = await _userManager.DeleteAsync(DBuser);
            if (!result.Succeeded) throw new Exception("Error deleting User!");
            return result.Succeeded;

        }


        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }



        public async Task<ApplicationUser> FindByIdAsync(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }



        public async Task<ApplicationUser> FindByUsernameAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }



        public UserClaimsDto GetUserClaims()
        {
            return new UserClaimsDto()
            {
                Email = _accessor.HttpContext.User?.Claims?
            .FirstOrDefault(c => c.Type == ClaimTypes.Email)?
            .Value,
                UserName = _accessor.HttpContext.User?.Claims?
            .FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?
            .Value,
                Id = _accessor.HttpContext.User?.Claims?
            .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?
            .Value,
            };
        }


        public async Task<List<string>> GetDevicesTokens(List<Guid> usersIds)
        {
            HashSet<Guid> idList = new HashSet<Guid>(usersIds);

            List<string> devicesTokens = await _dbcontext.Users.Where(q => idList.Contains(q.Id)).Select(q => q.DeviceToken).ToListAsync();

            if (devicesTokens == null) throw new RestException(HttpStatusCode.BadRequest, new { Message = $" Device Token Not exist!" });

            return devicesTokens;

        }


        public async Task<string> GetDeviceTokenByStudentId(Guid studentId)
        {

            string deviceToken = await _dbcontext.Users.Include(q => q.Student).Where(q => q.Id == studentId).Select(q => q.DeviceToken).FirstOrDefaultAsync();

            if (deviceToken == null) throw new RestException(HttpStatusCode.BadRequest, new { Message = $" Device Token Not exist!" });

            return deviceToken;

        }


        public async Task<int> SaveChangesAsync()
        {
            return await _dbcontext.SaveChangesAsync();
        }

        public async Task<string> GetDeviceToken(Guid userId)
        {
            string deviceToken = await _dbcontext.Users.Where(q => q.Id == userId).Select(q => q.DeviceToken).FirstOrDefaultAsync();

            return deviceToken;
        }

        public async Task<ApplicationUser> FindByMobile(string mobile)
        {
            ApplicationUser user = await _dbcontext.Users.FirstOrDefaultAsync(q => q.PhoneNumber == mobile);

            return user;
        }

        public  IEnumerable<Guid> GetTeacherSubjects()
        {
            var User = _accessor.HttpContext.User;
            if (User.IsInRole(UserType.Teacher.ToString()))
            {
                var subjectsClaim = User.FindFirst(a => a.Type == CustomClaimType.Subjects);

                if (subjectsClaim is null)
                    return null;


                return JsonSerializer.Deserialize<Guid[]>(subjectsClaim.Value);



            }
            return null;
        }

        public Task<List<string>> GetTeacherPermessions(Guid teacherId)
        {
            return _dbcontext.TeacherSubjectPermessions.Include(a => a.TeacherSubject).Where(a => a.TeacherSubject.TeacherId == teacherId).
                Select(a => $"{a.TeacherSubject.SubjectId}.{a.Permession}").Distinct()
                .ToListAsync();

        }
    }
}
