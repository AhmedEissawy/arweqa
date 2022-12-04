using OA.Repo.Dtos;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.SubjectGradeServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface ISubjectGradeService
    {
        Task<SubjectResponseDto> AddSubject(CreateSubjectDto grade);
        Task<List<SubjectResponseDto>> GetSubjectsByGradeAndSection(FilterGradeAndSectionDto filterDto);
        Task<(List<SubjectResponseDto>, int)> GetSubjects(FilterDto subjectFilter);
        Task<List<MobileSubjectResponseDto>> GetStudentSubjects();
        Task<SubjectResponseDto> GetSubjectById(Guid subjectId);
        Task<SubjectResponseDto> EditSubject(EditSubjectDto subject);
        Task DeleteSubject(Guid subjectId);
        Task<ActivationDto> SubjectActivation(Guid subjectId);
        Task<List<MobileSubjectResponseDto>> GeStudentSubjectsForLessons();
    }
}