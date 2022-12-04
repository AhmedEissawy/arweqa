using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OA.Data;
using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Repo.Enums;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.SubjectGradeServices.Dtos;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Service.Implementation.SubjectGradeServices
{
    public class SubjectGradeService : ISubjectGradeService
    {
        private readonly IMapper _Mapper;
        private readonly IFileHandler _FileHandler;
        private readonly ISubjectGradeRepo _SubjectGradeRepo;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly IStudentRepo _StudentRepo;
        private readonly IUserRepo _UserRepo;
        public SubjectGradeService(IFileHandler fileHandler, IMapper mapper, ISubjectGradeRepo subjectGradeRepo, IStudentRepo studentRepo, IUserRepo userRepo, UserManager<ApplicationUser> userManager)
        {
            _Mapper = mapper;
            _FileHandler = fileHandler;
            _usermanager = userManager;
            _SubjectGradeRepo = subjectGradeRepo;
            _StudentRepo = studentRepo;
            _UserRepo = userRepo;
        }




        public async Task<List<MobileSubjectResponseDto>> GetStudentSubjects()
        {
            string userId = _UserRepo.GetUserClaims().Id;

            Student dbStudent = await _StudentRepo.GetStudentByIdentityId(Guid.Parse(userId));

            if (dbStudent == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The student with id = {userId} not found ...!" });

            List<SubjectGrade> subjects = new List<SubjectGrade>();

            if (dbStudent.User.SectionId != null && dbStudent.User.GradeId != null)
            {
                subjects = await _SubjectGradeRepo.GetStudentSubjectsByGradeId(dbStudent.User.GradeId.Value, dbStudent.User.SectionId.Value);
            }

            return _Mapper.Map<List<MobileSubjectResponseDto>>(subjects);
        }



        public async Task<List<MobileSubjectResponseDto>> GeStudentSubjectsForLessons()
        {
            string userId = _UserRepo.GetUserClaims().Id;

            Student dbStudent = await _StudentRepo.GetStudentByIdentityId(Guid.Parse(userId));

            if (dbStudent == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The student with id = {userId} not found ...!" });

            List<SubjectGrade> subjects = new List<SubjectGrade>();

            if (dbStudent.User.SectionId != null && dbStudent.User.GradeId != null)
            {
                subjects = await _SubjectGradeRepo.GetStudentSubjectsByGradeId(dbStudent.User.GradeId.Value, dbStudent.User.SectionId.Value);
            }

            return _Mapper.Map<List<MobileSubjectResponseDto>>(subjects);
        }



        public async Task<List<SubjectResponseDto>> GetSubjectsByGradeAndSection(FilterGradeAndSectionDto filterDto)
        {
            List<SubjectGrade> subjects = await _SubjectGradeRepo.GetSubjectsByGradeAndSection(filterDto);

            return _Mapper.Map<List<SubjectResponseDto>>(subjects);
        }



        public async Task<SubjectResponseDto> GetSubjectById(Guid subjectId)
        {
            SubjectGrade dbSubject = await _SubjectGradeRepo.GetSubjectById(subjectId);

            if (dbSubject == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The subject with id = {subjectId} not found ...!" });

            return _Mapper.Map<SubjectResponseDto>(dbSubject);
        }


        public async Task<(List<SubjectResponseDto>, int)> GetSubjects(FilterDto subjectFilter)
        {
            string userId = _UserRepo.GetUserClaims().Id;

            ApplicationUser admin = await _UserRepo.FindByIdAsync(Guid.Parse(userId));

           
            bool IsSuperAdmin = await _usermanager.IsInRoleAsync(admin, ApplicationConstatns.SuperAdminRole)||admin.UserType== UserType.Teacher.ToString();

            List<SubjectGrade> subjects = new List<SubjectGrade>();

            int rowCount = 0;

            var teacherSubject = _UserRepo.GetTeacherSubjects();

            if (!IsSuperAdmin)
            {
                subjectFilter.SectionId = admin.SectionId.Value;
                if (admin.SectionId != null)
                {
                    (List<SubjectGrade> subjectGrades, int count) = await _SubjectGradeRepo.Subjects(subjectFilter,teacherSubject);
                    subjects = subjectGrades;
                    rowCount = count;
                }

            }
            else
            {
                (List<SubjectGrade> subjectGrades, int count) = await _SubjectGradeRepo.Subjects(subjectFilter,teacherSubject);
                subjects = subjectGrades;
                rowCount = count;
            }


            return (_Mapper.Map<List<SubjectResponseDto>>(subjects), rowCount);
        }



        public async Task<SubjectResponseDto> AddSubject(CreateSubjectDto subject)
        {
            if (subject.SubjectName == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The subject name cannot be empty ...!" });

            SubjectGrade newSubject = _Mapper.Map<SubjectGrade>(subject);

            newSubject.Id = Guid.NewGuid();

            if (subject.SubjectImage != null)
            {
                newSubject.SubjectImage = await Upload(subject.SubjectImage, 200, 600);
                newSubject.SubjectSmallImage = await Upload(subject.SubjectImage, 100, 100);
            }

            await _SubjectGradeRepo.AddAsync(newSubject);

            return await _SubjectGradeRepo.SaveChangesAsync() > 0 ? _Mapper.Map<SubjectResponseDto>(newSubject) : throw new Exception("Error saving The data ...!");

        }


        public async Task<SubjectResponseDto> EditSubject(EditSubjectDto subject)
        {
            //SubjectGrade oldSubject = (await _SubjectGradeRepo.GetSubjectWithSetions(q => q.Id == subject.SubjectId));
            SubjectGrade oldSubject = (await _SubjectGradeRepo.GetSubjectById(subject.SubjectId));

            if (oldSubject == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The subject with id = {subject.SubjectId} not found ...!" });

            //oldSubject.Index = subject.Index;
            //oldSubject.SectionId = subject.SectionId;
            //oldSubject.GradeId = subject.GradeId;
            //oldSubject.SubjectName = subject.SubjectName;


            if (oldSubject != null && oldSubject.SubjectImage != null && subject.SubjectImage != null)
            {
                DeleteSubjectImage(oldSubject.SubjectImage);
                DeleteSubjectImage(oldSubject.SubjectSmallImage);
            }

            _Mapper.Map(subject, oldSubject);

            if (subject.SubjectImage != null)
            {
                oldSubject.SubjectImage = await Upload(subject.SubjectImage, 200, 600);
                oldSubject.SubjectSmallImage = await Upload(subject.SubjectImage, 100, 100);
            }

            return await _SubjectGradeRepo.SaveChangesAsync() > 0 ? _Mapper.Map<SubjectResponseDto>(oldSubject) : throw new Exception("Error saving The data ...!");

        }



        public async Task DeleteSubject(Guid subjectId)
        {
            SubjectGrade oldSubjec = (await _SubjectGradeRepo.FindAsync(q => q.Id == subjectId)).FirstOrDefault();

            if (oldSubjec == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The subject with id = {subjectId} not found ...!" });

            if (oldSubjec.SubjectImage != null)
            {
                DeleteSubjectImage(oldSubjec.SubjectImage);
                DeleteSubjectImage(oldSubjec.SubjectSmallImage);
            }

            _SubjectGradeRepo.Remove(oldSubjec);

            var result = await _SubjectGradeRepo.SaveChangesAsync();

            if (result == 0) throw new Exception("Error deleting subject ...!");
        }



        public async Task<ActivationDto> SubjectActivation(Guid subjectId)
        {
            SubjectGrade dbSubject = (await _SubjectGradeRepo.FindAsync(q => q.Id == subjectId)).FirstOrDefault();

            if (dbSubject == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Subject with id = {subjectId} not found ...!" });

            if (dbSubject.IsActive == true)
            {
                dbSubject.IsActive = false;
                await _SubjectGradeRepo.SaveChangesAsync();

                var deActivatedStatus = new ActivationDto()
                {
                    Status = Status.DeActivated,
                    StatusFlag = false
                };

                return deActivatedStatus;
            }

            dbSubject.IsActive = true;

            await _SubjectGradeRepo.SaveChangesAsync();

            var activatedStatus = new ActivationDto()
            {
                Status = Status.Activated,
                StatusFlag = true
            };

            return activatedStatus;
        }


        private async Task<string> Upload(IFormFile attachment, int width, int height)
        {
            _FileHandler.ValiadteFile(attachment);

            if (attachment.Length == 0) throw new Exception("Error Saving Subject Image Attachment ...!");

            return await _FileHandler.SaveImageConverter(attachment, FolderName.Subjects.ToString(), width, height);
        }


        private bool DeleteSubjectImage(string imagePath)
        {
            return _FileHandler.DeleteFile(imagePath, FolderName.Subjects.ToString());

        }


    }
}
