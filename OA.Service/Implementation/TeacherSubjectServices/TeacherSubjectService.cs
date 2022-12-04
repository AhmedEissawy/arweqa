using AutoMapper;
using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.TeacherSubjectServices.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Implementation.TeacherSubjectServices
{
    public class TeacherSubjectService : ITeacherSubjectService
    {
        private readonly IMapper _Mapper;
        private readonly ITeacherSubjectRepo _TeacherSubjectRepo;
        public TeacherSubjectService(IMapper mapper, ITeacherSubjectRepo teacherSubjectRepo)
        {
            _Mapper = mapper;
            _TeacherSubjectRepo = teacherSubjectRepo;
        }



        public async Task AddSubjectToTeacher(AddSubjectsToTeacherDto subjectsDto)
        {
           List<TeacherSubject> teacherSubjects = await _TeacherSubjectRepo.GetAllTeacherSubjects(subjectsDto.TeacherId);

            if (teacherSubjects.Count != 0)
            {
                List<Guid> Subjects = teacherSubjects.Select(q => q.SubjectId).ToList();

                List<Guid> duplicatedSubjects = Subjects.Intersect(subjectsDto.Subjects.Select(z=>z.SubjectId)).ToList();

                // for uploading purpose only after that we will uncomment it ###
                // if (teacherSubjects == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $"  {teacherSubjects.Where(q => duplicatedSubjects.SubjectId == q.SubjectId)).Select(q => q.Subject.SubjectName).ToList()}لايمكن إضافة مواد مكرره لنفس المعلم المواد المكرره للمعلم " });
            }



            if (subjectsDto.Subjects.Count != 0)
            {
                foreach (var subject in subjectsDto.Subjects)
                { var id = Guid.NewGuid();
                    var teacherSubject = new TeacherSubject()
                    {
                        Id = id,
                        TeacherId = subjectsDto.TeacherId,
                        SubjectId = subject.SubjectId,
                        Role = await _TeacherSubjectRepo.GetLastTeacherRole(subject.SubjectId) + 1,
                        SubjectPermessions = subject.Permessions.Select(a=>new TeacherSubjectPermession 
                        {
                            Id= Guid.NewGuid(),
                            Teacher_Subject_Id =id,
                            IsActive=true,
                            Permession=a
                        }).ToArray()
                    };

                    await _TeacherSubjectRepo.AddAsync(teacherSubject);
                }


                int result = await _TeacherSubjectRepo.SaveChangesAsync();



                if (result == 0) throw new Exception("Error saving The data ...!");
            }

            if (subjectsDto.UpdatedPermessions == null || !subjectsDto.UpdatedPermessions.Any())
                return;

            foreach (var item in subjectsDto.UpdatedPermessions)
            {
                var subject = await _TeacherSubjectRepo.GetTeacherSubjectByPermessions(subjectsDto.TeacherId, item.SubjectId);

                if (subject == null)
                    continue;
                
                RemoveOldPermessionsForSubject(subject);

                foreach (var permession in item.Permessions)
                {
                    subject.SubjectPermessions.Add(new TeacherSubjectPermession { Id = Guid.NewGuid(), Permession = permession });

                }
            }

          var updated=  await _TeacherSubjectRepo.SaveChangesAsync();

        }

        private static void RemoveOldPermessionsForSubject(TeacherSubject subject)
        {
            foreach (var permession in subject.SubjectPermessions.ToList())
            {
                subject.SubjectPermessions.Remove(permession);
            }
        }
    

    public  Task<List<PermessionsModel>> GetSubjectPermissions()
        {
            return Task.FromResult(SubjectPermessions.modulesPermessions);
        }

        public async Task RemoveSubjectFromTeacher(Guid teacherSubjectId)
        {
            TeacherSubject subject = (await _TeacherSubjectRepo.FindAsync(q => q.Id == teacherSubjectId)).FirstOrDefault();

            if (subject == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The subject with id = {teacherSubjectId}  not found ...!" });

            _TeacherSubjectRepo.Remove(subject);

            int result = await _TeacherSubjectRepo.SaveChangesAsync();

            if (result == 0) throw new Exception("Error saving The data ...!");

        }

        public async Task<bool> DeleteOrAddSubjectPermession(Guid teacherId, Guid subjectId, string permession, bool status)
        {
            var result = await _TeacherSubjectRepo.ChangeTeacherSubjectPermession(teacherId, subjectId, permession, status);
            var saved = await _TeacherSubjectRepo.SaveChangesAsync();
            return result;
        }

    }
}
