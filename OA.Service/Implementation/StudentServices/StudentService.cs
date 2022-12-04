using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Repo.Enums;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.Infrastructure;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.StudentServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace OA.Service.Implementation.StudentServices
{
    
    public class StudentService : IStudentService
    {
        private readonly IStudentRepo _StudentRepo;
        private readonly IUserRepo _UserRepo;
        private readonly IMapper _Mapper;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly SignInManager<ApplicationUser> _signinmanger;
        private readonly IFileHandler _FileHandler;
        public StudentService(IStudentRepo studentRepo, IUserRepo userRepo, IMapper mapper, UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signinmanger, IFileHandler fileHandler)
        {
            _StudentRepo = studentRepo;
            _usermanager = usermanager;
            _signinmanger = signinmanger;
            _FileHandler = fileHandler;
            _UserRepo = userRepo;
            _Mapper = mapper;
        }



        public async Task<(List<StudentResponseDto>, int)> GetStudents(FilterDto filter)
        {

            string userId = _UserRepo.GetUserClaims().Id;

            ApplicationUser admin = await _UserRepo.FindByIdAsync(Guid.Parse(userId));

            bool IsSuperAdmin = await _usermanager.IsInRoleAsync(admin, Role.SuperAdmin);

            (List<Student> students, int count) response = (null, 0);

            if (!IsSuperAdmin)
            {
                if (admin.SectionId != null)
                {
                    filter.SectionId = admin.SectionId.Value;
                    response = await _StudentRepo.GetStudents(filter);
                }

            }
            else
            {
                response = await _StudentRepo.GetStudents(filter);
            }

            return (_Mapper.Map<List<StudentResponseDto>>(response.students), response.count);
        }



        public async Task<StudentResponseDto> GetStudentById(Guid studentId)
        {
            Student Response = await _StudentRepo.GetStudentById(studentId);

            return _Mapper.Map<StudentResponseDto>(Response);
        }



        public async Task<StudentResponseDto> StudentViewProfile()
        {
            string studentIdentifier = _UserRepo.GetUserClaims().Id;

            Guid studentId = Guid.Parse(studentIdentifier);

            //Student dbStudent = await _StudentRepo.GetStudentAsync(studentId);

            if (studentId == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The student not found ...!" });

            Student studentResponse = await _StudentRepo.GetStudentById(studentId);

            return _Mapper.Map<StudentResponseDto>(studentResponse);
        }



        public async Task<StudentResponseDto> AddStudent(CreateStudentDto student)
        {
            Student newStudent = _Mapper.Map<Student>(student);

            if (student.ProfileImage != null && student.ProfileImage.Length > 0)
                newStudent.ProfileImage = await _FileHandler.SaveFile(student.ProfileImage, $"{FolderName.Students}\\{FolderName.ProfileImage}");
            else
                newStudent.ProfileImage = "";

            newStudent.Id = Guid.Parse(_UserRepo.GetUserClaims().Id);

            ApplicationUser studentIdentityUser = await _UserRepo.FindByIdAsync(newStudent.Id);

            studentIdentityUser.UserFullName = student.Name;
            studentIdentityUser.PhoneNumber = student.Mobile;
            studentIdentityUser.GradeId = student.GradeId;
            studentIdentityUser.SectionId = student.SectionId;
            studentIdentityUser.UserType = UserType.Student.ToString();

            if (studentIdentityUser == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The student with identityId = {newStudent.Id} not found ...!" });

            await _StudentRepo.AddAsync(newStudent);

            return await _StudentRepo.SaveChangesAsync() > 0 ? _Mapper.Map<StudentResponseDto>(newStudent) : throw new Exception("Error saving The data ...!");

        }



        public async Task<StudentResponseDto> StudentEditProfile(EditStudentDto student)
        {
            string userId = _UserRepo.GetUserClaims().Id;


            Student oldStudent = (await _StudentRepo.GetStudentByIdentityId(Guid.Parse(userId)));
            if (student.ProfileImage != null && student.ProfileImage.Length > 0)
            {
                _FileHandler.DeleteFile(oldStudent.ProfileImage, $"{FolderName.Students}\\{FolderName.ProfileImage}");
                oldStudent.ProfileImage = await _FileHandler.SaveFile(student.ProfileImage, $"{FolderName.Students}\\{FolderName.ProfileImage}");
            }

            // ApplicationUser user = await _UserRepo.FindByMobile(student.Mobile);

            if (oldStudent == null || oldStudent.User is null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The student with id = {userId} not found ...!" });

            //if (oldStudent != null  && user.Id != oldStudent.Id) throw new RestException(HttpStatusCode.BadRequest, new { message = $" This Mobile Number Used Before ...!" });

            oldStudent.User.UserFullName = student.Name.Trim();
            //oldStudent.User.PhoneNumber = student.Mobile;
            oldStudent.User.SectionId = student.SectionId;
            oldStudent.User.GradeId = student.GradeId;

            await _StudentRepo.SaveChangesAsync();

            return _Mapper.Map<StudentResponseDto>(oldStudent);

        }



        public async Task<StudentResponseDto> AdminStudentEditProfile(AdminEditStudentDto student)
        {
            Student oldStudent = (await _StudentRepo.GetStudentByIdentityId(student.StudentId));

            if (oldStudent == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The student with id = {student.StudentId} not found ...!" });

            oldStudent.User.UserFullName = student.Name;
            oldStudent.User.Email = student.Email;
            oldStudent.User.PhoneNumber = student.Mobile;
            oldStudent.User.SectionId = student.SectionId;
            oldStudent.User.GradeId = student.GradeId;

            return await _StudentRepo.SaveChangesAsync() > 0 ? _Mapper.Map<StudentResponseDto>(oldStudent) : throw new Exception("Error saving The data ...!");

        }



        public async Task<ActivationDto> PremiumStudentActivation(Guid studentId)
        {
            Student dbStudent = (await _StudentRepo.FindAsync(q => q.Id == studentId)).FirstOrDefault();

            if (dbStudent == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The student with id = {studentId} not found ...!" });

            if (dbStudent.PremiumSubscription == true)
            {
                dbStudent.PremiumSubscription = false;
                await _UserRepo.SaveChangesAsync();

                var deActivatedStatus = new ActivationDto()
                {
                    Status = Status.DeActivated,
                    StatusFlag = false
                };

                return deActivatedStatus;
            }

            dbStudent.PremiumSubscription = true;
            await _UserRepo.SaveChangesAsync();

            var activatedStatus = new ActivationDto()
            {
                Status = Status.Activated,
                StatusFlag = true
            };

            return activatedStatus;
        }



        public async Task<ActivationDto> StudentActivation(Guid studentId)
        {
            ApplicationUser studentUser = (await _UserRepo.FindByIdAsync(studentId));

            if (studentUser == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Student with id = {studentId} not found ...!" });


            if (studentUser.IsActive == true)
            {
                studentUser.IsActive = false;
                await _UserRepo.SaveChangesAsync();

                var deActivatedStatus = new ActivationDto()
                {
                    Status = Status.DeActivated,
                    StatusFlag = false
                };

                return deActivatedStatus;
            }

            studentUser.IsActive = true;
            await _UserRepo.SaveChangesAsync();

            var activatedStatus = new ActivationDto()
            {
                Status = Status.Activated,
                StatusFlag = true
            };

            return activatedStatus;
        }

        public async Task DeleteStudent(Guid? studentId)
        {
            if (studentId == null || studentId == Guid.Empty)
            {
                studentId = Guid.Parse(_UserRepo.GetUserClaims().Id);
            }

            Student dbStudent = (await _StudentRepo.GetStudentById(studentId.Value));

            if (dbStudent == null || studentId == Guid.Empty || studentId == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The student with id = {studentId} not found ...!" });


            dbStudent.User.DeviceToken = $"FullName =({dbStudent.User.UserFullName}) , PhoneNumber =({dbStudent.User.PhoneNumber}) , UserName =({dbStudent.User.UserName})";
            dbStudent.User.UserName = Guid.NewGuid().ToString();
            dbStudent.User.Email = dbStudent.User.UserName;
            dbStudent.User.NormalizedUserName = dbStudent.User.UserName.ToUpper();
            dbStudent.User.NormalizedEmail = dbStudent.User.UserName.ToUpper();
            dbStudent.User.PhoneNumber = "تم مسح الحساب";
            dbStudent.User.Deleted = true;
            dbStudent.User.Deleted = true;
            dbStudent.User.IsActive = false;
            dbStudent.Deleted = true;
            dbStudent.IsActive = false;

            await _StudentRepo.SaveChangesAsync();
        }

        public Task<bool> SendConfirmationCode(string phone)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetStudentsCount(FilterDto filter)
        {
            return await _StudentRepo.GetSTudentsCount(filter);
        }

        public async Task<StudentResponseDto> RegisterStudent(RegisterStudentDto student)
        {

            if (student == null)
                return new StudentResponseDto() { Message = "Invalid Model" };

            student.UserFullName = student.UserFullName?.Trim();
            student.Email = student.Email?.Trim();
            student.Password = student.Password?.Trim();
            student.Gender = student.Gender?.Trim();
            student.City = student.City?.Trim();
            student.InstituteName = student.InstituteName?.Trim();

            bool isExist = await _usermanager.Users.AnyAsync(
                s => s.Email == student.Email ||
                s.PhoneNumber == student.Phone 
                );

            if (isExist)
                return new StudentResponseDto() { Message = "Email Or Phone  Is Already Exist" };

            if (student.Image != null && student.Image.Length > 0)
                await _FileHandler.SaveFile(student.Image,$"{FolderName.Students}\\{FolderName.ProfileImage}");

            var dataDb = _Mapper.Map<ApplicationUser>(student);


            var result = await _usermanager.CreateAsync(dataDb, student.Password);

            if (result.Succeeded)
               return new StudentResponseDto() {Message = "Student Registered Successfully"};

            else
                return new StudentResponseDto() { Message = "Registeration Faild" };


        }
    }
}