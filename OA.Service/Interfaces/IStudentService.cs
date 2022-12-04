using OA.Repo.Dtos;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.StudentServices.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IStudentService
    {
        Task<(List<StudentResponseDto>, int)> GetStudents(FilterDto filter);
        Task<int> GetStudentsCount(FilterDto filter);
        Task<StudentResponseDto> GetStudentById(Guid studentId);
        Task<StudentResponseDto> StudentViewProfile();
        Task<StudentResponseDto> AddStudent(CreateStudentDto student);
        Task<StudentResponseDto> RegisterStudent(RegisterStudentDto student);
        Task<StudentResponseDto> StudentEditProfile(EditStudentDto student);
        Task<StudentResponseDto> AdminStudentEditProfile(AdminEditStudentDto student);
        Task<ActivationDto> StudentActivation(Guid studentId);
        Task<ActivationDto> PremiumStudentActivation(Guid studentId);
        Task DeleteStudent(Guid? studentId);
        Task<bool> SendConfirmationCode(string phone);
        
    }
}