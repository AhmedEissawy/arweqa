using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Enums;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.UserServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Service.Implementation.UserServices
{
    public class UserService : IUserService
    {
        private readonly IMapper _Mapper;
        private readonly IRoleService _RoleService;
        private readonly IUserRepo _UserRepo;
        private readonly IStudentRepo _StudentRepo;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly SignInManager<ApplicationUser> _signinmanger;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly ITeacherRepo _TeacherRepo;
        public UserService(IMapper mapper, IUserRepo userRepo, UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signinmanger, IJwtGenerator jwtGenerator, ITeacherRepo teacherRepo, IStudentRepo studentRepo, IRoleService roleService)
        {
            _Mapper = mapper;
            _StudentRepo = studentRepo;
            _UserRepo = userRepo;
            _usermanager = usermanager;
            _signinmanger = signinmanger;
            _jwtGenerator = jwtGenerator;
            _RoleService = roleService;
            _TeacherRepo = teacherRepo;

        }


        public async Task<ApplicationUser> CreateUser(RegistrationDto user)
        {
            ApplicationUser newUser = _Mapper.Map<ApplicationUser>(user);

            bool exists = await _UserRepo.CheckUserExists(user.Email);

            if (exists) throw new RestException(HttpStatusCode.BadRequest, new { Message = "هذاالإيميل مستخدم بالفعل" });

            newUser.UserName = user.Email;
            newUser.IsActive = true;
            newUser.UserFullName = user.UserName;
            newUser.UserType = UserType.Admin.ToString();

            ApplicationUser createdUser = await _UserRepo.CreateUser(newUser, user.Password);

            return createdUser;
        }


        public async Task<List<AdminResponseDto>> GetAdmins()
        {

            List<ApplicationUser> users = await _usermanager.Users.Include(q => q.Section).Where(q => q.UserType == UserType.Admin.ToString() && q.Email != "programmer@programmer.com" && !q.Deleted).ToListAsync();

            List<AdminResponseDto> admins = _Mapper.Map<List<AdminResponseDto>>(users);

            return admins;

        }


        public async Task<AdminResponseDto> GetAdminById(Guid adminId)
        {
            ApplicationUser adminUser = await _usermanager.Users.Include(q => q.Section).Where(q => q.UserType == UserType.Admin.ToString() && q.Email != "programmer@programmer.com" && !q.Deleted && q.Id == adminId).FirstOrDefaultAsync();

            AdminResponseDto admin = _Mapper.Map<AdminResponseDto>(adminUser);

            return admin;
        }


        public async Task EditAdminProfile(EditAdminProfileDto admin)
        {
            if (string.IsNullOrEmpty(admin.AdminId) || string.IsNullOrWhiteSpace(admin.AdminId))
            {
                admin.AdminId = _UserRepo.GetUserClaims().Id;
            }

            ApplicationUser adminUser = await _usermanager.Users.FirstOrDefaultAsync(q => q.Id == Guid.Parse(admin.AdminId) && q.Email != "programmer@programmer.com" && !q.Deleted);

            bool exists = await _UserRepo.CheckUserExists(admin.Email);

            if (exists && adminUser.Email != admin.Email) throw new RestException(HttpStatusCode.BadRequest, new { Message = "هذاالإيميل مستخدم بالفعل" });

            adminUser.UserFullName = admin.AdminName;
            adminUser.Email = admin.Email;
            adminUser.SectionId = admin.SectionId;

            IdentityResult result = await _usermanager.UpdateAsync(adminUser);

            if (!result.Succeeded) throw new RestException(HttpStatusCode.BadRequest, new { Message = $"Error Editing Admin : {result.Errors.FirstOrDefault().Description}" });

        }

        public async Task<UserLoginResponseDto> Login(LoginDto loginData)
        {
            var user = await _usermanager.FindByEmailAsync(loginData.Username);
            
            if (user == null) throw new RestException(HttpStatusCode.Unauthorized);

            if (user != null && user.Deleted||!user.IsActive)
            {
                return new UserLoginResponseDto()
                {
                    
                    Unauthorized = true,
                    Message = "غير مصرح لك بدخول هذه الصفحه"

                };
            }

            var result = await _signinmanger.CheckPasswordSignInAsync(user, loginData.Password,true);

            if (result.Succeeded)
            {
                var response= new UserLoginResponseDto()
                {
                    UserName = user.Email,
                    Token = await _jwtGenerator.CreateTokenAsync(user),
                    Id = user.Id.ToString(),
                    ExpirationDate = DateTime.Now.AddDays(14),
                    SectionId = user.SectionId,
                    Roles = await _RoleService.GetAdminRolesInLogin(user.Id.ToString()),
                    Unauthorized = false,
                    Message = null,
                    UserType=user.UserType,
                   TeacherPermession= user.UserType==UserType.Teacher.ToString()? await _UserRepo.GetTeacherPermessions(user.Id) :new List<string>()

                };
                return response;
            }
            else
            {
                return new UserLoginResponseDto()
                {
                   
                    Unauthorized = true,
                    Message = "إسم المستخدم أو كلمة المرور غير صحيحه"

                };
            }

        }


        //public async Task<StudentLoginResponseDto> StudentLogin(StudentLoginDto loginData)
        //{

        //    var user = await _usermanager.FindByEmailAsync(loginData.Email);

        //    if (user == null)
        //    {
        //        var newUser = new ApplicationUser { Email = loginData.Email, UserName = loginData.Email };

        //        ApplicationUser createdUser = await _UserRepo.CreateUser(newUser, loginData.Password);

        //        await LogInDataHandler(loginData.DeviceToken, createdUser);

        //        //remoe after test
        //        CreateStudentDto newStudent = new CreateStudentDto()
        //        {
        //            Name = "New User",

        //            Mobile = "0000000000",

        //            StageId = Guid.Parse("6eee9b04-b2f9-45af-878e-2986e008d3ad"),

        //            GradeId = Guid.Parse("0d5e2faa-a27e-4987-9d7c-4f69bac73f74")
        //        };

        //        //remoe after test
        //        await _StudentService.AddStudent(newStudent, createdUser.Id);



        //        return new StudentLoginResponseDto()
        //        {
        //            // for uploading purpose only after that we will uncomment it ###
        //            //Exsist = false,

        //            //remoe after test
        //            Exsist = true,

        //            Token = await _jwtGenerator.CreateTokenAsync(createdUser),

        //        };
        //    }


        //    var result = await _signinmanger.CheckPasswordSignInAsync(user, loginData.Password, true);


        //    if (result.Succeeded)
        //    {
        //        Student student = (await _StudentRepo.FindAsync(q => q.IdentityId == user.Id)).FirstOrDefault();

        //        //remoe after test
        //        if (student == null)
        //        {
        //            //remoe after test
        //            CreateStudentDto newStudent = new CreateStudentDto()
        //            {
        //                Name = "New User",

        //                Mobile = "0000000000",

        //                StageId = Guid.Parse("6eee9b04-b2f9-45af-878e-2986e008d3ad"),

        //                GradeId = Guid.Parse("0d5e2faa-a27e-4987-9d7c-4f69bac73f74")
        //            };

        //            //remoe after test
        //            await _StudentService.AddStudent(newStudent, user.Id);
        //        }

        //        await LogInDataHandler(loginData.DeviceToken, user);

        //        return new StudentLoginResponseDto()
        //        {
        //            // for uploading purpose only after that we will uncomment it ###
        //            //Exsist = student == null ? false : true,

        //            //remoe after test
        //            Exsist = true,

        //            Token = await _jwtGenerator.CreateTokenAsync(user),
        //        };
        //    }
        //    throw new RestException(HttpStatusCode.Unauthorized);

        //}


        public async Task<StudentLoginResponseDto> StudentLogin(StudentLoginDto loginData)
        {

            if (loginData == null)
                return new StudentLoginResponseDto { Message = "Invalid Model" };            

            var user = await _usermanager.FindByEmailAsync(loginData.Email);

            //Edit After Firebase
            //ApplicationUser user = await _UserRepo.FindByMobile(loginData.Mobile);

            if (user == null)
            
                //var newUser = new ApplicationUser { Email = loginData.Email, UserName = loginData.Email, PhoneNumber = loginData.Mobile, DeviceToken = loginData.DeviceToken??"" };

                //ApplicationUser createdUser = await _UserRepo.CreateUser(newUser, loginData.Password);

                return new StudentLoginResponseDto()
                {
                    isExist = false,
                    Message = "There is No User With That Email",
                    //Token = await _jwtGenerator.CreateTokenAsync(createdUser),
                };
           

            var result = await _usermanager.CheckPasswordAsync(user, loginData.Password);

            if (result)
            {
                //Student student = (await _StudentRepo.FindAsync(q => q.Id == user.Id)).FirstOrDefault();

                await LogInDataHandler(loginData.DeviceToken, user);

                return new StudentLoginResponseDto()
                {
                    isExist = true,
                    Token = await _jwtGenerator.CreateTokenAsync(user),
                    Role = user.UserType
                };
            }
            return new StudentLoginResponseDto()
            {
                isExist = true,
                Message = "Invalid Password",
                Password= loginData.Password
            };
            //throw new RestException(HttpStatusCode.Unauthorized);
        }


        public async Task<TeacherLoginResponseDto> TeacherLogin(LoginDto loginData)
        {
            var user = await _usermanager.FindByEmailAsync(loginData.Username);

            if (user == null) throw new RestException(HttpStatusCode.Unauthorized);

            if (user != null)
            {
                if (user.Deleted) throw new RestException(HttpStatusCode.BadRequest, new { Message = $"غير مصرح لك بدخول هذه الصفحه" });
            }


            var result = await _signinmanger.CheckPasswordSignInAsync(user, loginData.Password, true);

            if (result.Succeeded)
            {
                await LogInDataHandler(loginData.DeviceToken, user);
                return new TeacherLoginResponseDto()
                {
                    TeacherName = user.UserFullName,

                    Token = await _jwtGenerator.CreateTokenAsync(user),

                };
            }
            throw new RestException(HttpStatusCode.Unauthorized);

        }



        // saving  ( DeviceToken)
        private async Task LogInDataHandler(string deviceToken, ApplicationUser user)
        {

            if (!string.IsNullOrEmpty(deviceToken))
            {
                user.DeviceToken = deviceToken;

                await _UserRepo.SaveChangesAsync();
            }

        }



        public async Task ResetPassword(ResetPasswordDto resetPassword)
        {
            var user = await _usermanager.FindByIdAsync(resetPassword.UserIdentityId);

            if (user == null) throw new RestException(HttpStatusCode.BadRequest, new { Message = $"the user with id ={resetPassword.UserIdentityId} not exists!" });

            var PasswordResetToken = await _usermanager.GeneratePasswordResetTokenAsync(user);

            var result = await _usermanager.ResetPasswordAsync(user, PasswordResetToken, resetPassword.NewPassword);

            if (!result.Succeeded) throw new RestException(HttpStatusCode.BadRequest, new { Message = $"Error deleting Admin : {result.Errors.FirstOrDefault().Description}" });
        }



        public async Task RemoveAdmin(string id)
        {
            var user = await _usermanager.FindByIdAsync(id);

            if (user == null) throw new RestException(HttpStatusCode.BadRequest, new { Message = $"the admin with id ={id} not exists!" });

            var result = await _usermanager.DeleteAsync(user);

            if (!result.Succeeded) throw new RestException(HttpStatusCode.BadRequest, new { Message = $"Error deleting Admin : {result.Errors.FirstOrDefault().Description}" });

        }


    }
}
