using OA.Repo.Dtos;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.TeacherServices.Dtos;
using OA.Service.Implementation.TeacherSubjectServices.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface ITeacherService
    {
        Task<(List<TeacherResponseDto>, int count)> GetTeachers(FilterDto filter);
        Task<TeacherResponseDto> GetTeacherById(Guid teacherId);
        Task<TeacherResponseDto> TeacherViewProfile();
        Task<AddSubjectsToTeacherDto> AddTeacher(CreateTeacherDto teacher);
        Task<TeacherResponseDto> EditTeacherProfile(EditTeacherDto teacher);
        Task<ActivationDto> TeacherActivation(Guid teacherId);
        Task<ActivationDto> PremiumTeacherActivation(Guid teacherId);
      
        Task DeleteTeacher(Guid teacherId);
    }
}
