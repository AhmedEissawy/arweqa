using AutoMapper;
using Microsoft.AspNetCore.Identity;
using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Repo.Enums;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.SubjectGradeServices.Dtos;
using OA.Service.Implementation.TeacherServices.Dtos;
using OA.Service.Implementation.TeacherSubjectServices.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Service.Implementation.TeacherServices
{

    public class TeacherService : ITeacherService
    {
        private readonly IUserRepo _UserRepo;
        private readonly ISectionRepo _SectionRepo;
        private readonly IMapper _Mapper;
        private readonly ITeacherRepo _TeacherRepo;
        private readonly UserManager<ApplicationUser> _usermanager;
        public TeacherService(IMapper mapper, ITeacherRepo teacherRepo, IUserRepo userRepo, UserManager<ApplicationUser> userManager, ISectionRepo sectionRepo)
        {
            _Mapper = mapper;
            _TeacherRepo = teacherRepo;
            _SectionRepo = sectionRepo;
            _UserRepo = userRepo;
            _usermanager = userManager;

        }



        public async Task<(List<TeacherResponseDto> ,int count)> GetTeachers(FilterDto filter)
        {
            (List<Teacher> response , int rowCount) = await _TeacherRepo.GetTeachers(filter);

            return (_Mapper.Map<List<TeacherResponseDto>>(response) , rowCount);

        }



        public async Task<TeacherResponseDto> GetTeacherById(Guid teacherId)
        {
            Teacher dbTteacher = await _TeacherRepo.GetTeacherById(teacherId);

            List<TeacherSubject> dbTteacherSubject = await _TeacherRepo.GetTeacherSubjects(teacherId);

            TeacherResponseDto teacherResponse = _Mapper.Map<TeacherResponseDto>(dbTteacher);

            teacherResponse.Subjects = _Mapper.Map<List<SubjectResponseDto>>(dbTteacherSubject);
            
            SetSubjectPermesssions(dbTteacherSubject, teacherResponse);

            return teacherResponse;
        }

        private static void SetSubjectPermesssions(List<TeacherSubject> dbTteacherSubject, TeacherResponseDto teacherResponse)
        {
            foreach (var item in dbTteacherSubject)
            {
                var teacherSubjectResponse = teacherResponse.Subjects.FirstOrDefault(a => a.SubjectId == item.Id);

                teacherSubjectResponse.Permessions =  SubjectPermessions.GetPermessions();


                foreach (var module in teacherSubjectResponse.Permessions)
                {
                    foreach (var permession in module.Permessions)
                    {
                        if (item.SubjectPermessions.Any(a => a.Permession == permession.Permession))
                            permession.IsSelected = true;
                        else
                            permession.IsSelected = false;
                            
                    }
                }
            }
        }

        public async Task<TeacherResponseDto> TeacherViewProfile()
        {
            string userId = _UserRepo.GetUserClaims().Id;

            Teacher dbTeacher = (await _TeacherRepo.FindAsync(q => q.Id == Guid.Parse(userId))).FirstOrDefault();

            if (dbTeacher == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The teacher not found ...!" });

            if (dbTeacher.User.Deleted) throw new RestException(HttpStatusCode.BadRequest, new { message = $" لقد تم مسح حسابك ...!" });

            Teacher teacherResponse = await _TeacherRepo.GetTeacherById(dbTeacher.Id);

            return _Mapper.Map<TeacherResponseDto>(teacherResponse);
        }



        public async Task<AddSubjectsToTeacherDto> AddTeacher(CreateTeacherDto teacher)
        {
            ApplicationUser user = _Mapper.Map<ApplicationUser>(teacher);

            ApplicationUser identityUser = await _UserRepo.CreateIdentityTeacher(user, teacher.Password);

            Teacher newTeacher = _Mapper.Map<Teacher>(teacher);

            newTeacher.Id = identityUser.Id;
            newTeacher.PremiumSubscription = teacher.PremiumSubscription;

            await _TeacherRepo.AddAsync(newTeacher);

            AddSubjectsToTeacherDto Response = _Mapper.Map<AddSubjectsToTeacherDto>(newTeacher);

            Response.Subjects = teacher.Subjects;

            return await _TeacherRepo.SaveChangesAsync() > 0 ? Response : throw new Exception("Error saving The data ...!");

        }



        public async Task<TeacherResponseDto> EditTeacherProfile(EditTeacherDto teacher)
        {
            Teacher oldTeacher = (await _TeacherRepo.FindAsync(q => q.Id == teacher.TeacherId)).FirstOrDefault();

            if (oldTeacher == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The teacher with id = {teacher.TeacherId} not found ...!" });

            ApplicationUser teacherUser = (await _UserRepo.FindByIdAsync(oldTeacher.Id));
            if (teacherUser == null) throw new RestException(HttpStatusCode.BadRequest, new { Message = $"User of email={teacher}  does not exist!" });

            oldTeacher.PremiumSubscription = teacher.PremiumSubscription;

            teacherUser.UserName = teacher.Email;
            teacherUser.PhoneNumber = teacher.Mobile;
            teacherUser.Email = teacher.Email;
            teacherUser.UserFullName = teacher.Name;
            return await _TeacherRepo.SaveChangesAsync() > 0 ? _Mapper.Map<TeacherResponseDto>(oldTeacher) : throw new Exception("Error saving The data ...!");
        }



        public async Task<ActivationDto> TeacherActivation(Guid teacherId)
        {
            Teacher dbTeacher = (await _TeacherRepo.FindAsync(q => q.Id == teacherId)).FirstOrDefault();

            if (dbTeacher == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The teacher with id = {teacherId} not found ...!" });

            ApplicationUser teacherUser = (await _UserRepo.FindByIdAsync(dbTeacher.Id));

            if (teacherUser.IsActive == true)
            {
                teacherUser.IsActive = false;
                await _UserRepo.SaveChangesAsync();

                var deActivatedStatus = new ActivationDto()

                {
                    Status = Status.DeActivated,
                    StatusFlag = false
                };

                return deActivatedStatus;
            }

            teacherUser.IsActive = true;
            await _UserRepo.SaveChangesAsync();

            var activatedStatus = new ActivationDto()
            {
                Status = Status.Activated,
                StatusFlag = true
            };

            return activatedStatus;

        }



        public async Task<ActivationDto> PremiumTeacherActivation(Guid teacherId)
        {
            Teacher dbTeacher = (await _TeacherRepo.FindAsync(q => q.Id == teacherId)).FirstOrDefault();

            if (dbTeacher == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The teacherId with id = {teacherId} not found ...!" });

            if (dbTeacher.PremiumSubscription == true)
            {
                dbTeacher.PremiumSubscription = false;
                await _TeacherRepo.SaveChangesAsync();

                var deActivatedStatus = new ActivationDto()
                {
                    Status = Status.DeActivated,
                    StatusFlag = false
                };

                return deActivatedStatus;
            }

            dbTeacher.PremiumSubscription = true;
            await _TeacherRepo.SaveChangesAsync();

            var activatedStatus = new ActivationDto()
            {
                Status = Status.Activated,
                StatusFlag = true
            };

            return activatedStatus;
        }




        public async Task DeleteTeacher(Guid teacherId)
        {
            Teacher dbTeacher = (await _TeacherRepo.FindAsync(q => q.Id == teacherId)).FirstOrDefault();

            if (dbTeacher == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The teacher with id = {teacherId} not found ...!" });

            ApplicationUser teacherUser = (await _UserRepo.FindByIdAsync(dbTeacher.Id));

            teacherUser.Deleted = true;

            await _UserRepo.SaveChangesAsync();
        }

       
    }

}