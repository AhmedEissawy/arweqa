using AutoMapper;
using OA.Data.Domain;
using OA.Repo.Enums;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.SemesterServices.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Service.Implementation.SemesterServices
{
    public class SemesterService : ISemesterService
    {

        private readonly ISemesterRepo _semesterRepo;
        private readonly IMapper _Mapper;
        public SemesterService(ISemesterRepo semesterRepo, IMapper mapper)
        {
            _semesterRepo = semesterRepo;
            _Mapper = mapper;
        }



        public async Task<List<SemesterResponseDto>> GetSemesters()
        {
            List<Semester> semesters = await _semesterRepo.GetSemesters();

            return _Mapper.Map<List<SemesterResponseDto>>(semesters);
        }



        public async Task<SemesterResponseDto> GetSemesterById(Guid semesterId)
        {
            Semester dbSemester = (await _semesterRepo.FindAsync(q => q.Id == semesterId)).FirstOrDefault();

            if (dbSemester == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Semester with id = {semesterId} not found ...!" });

            return _Mapper.Map<SemesterResponseDto>(dbSemester);
        }



        public async Task<SemesterResponseDto> AddSemester(CreateSemesterDto semester)
        {
            if (semester.SemesterName == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Semester name cannot be empty ...!" });

            Semester newSemester = _Mapper.Map<Semester>(semester);

            newSemester.Id = Guid.NewGuid();

            await _semesterRepo.AddAsync(newSemester);

            return await _semesterRepo.SaveChangesAsync() > 0 ? _Mapper.Map<SemesterResponseDto>(newSemester) : throw new Exception("Error saving The data ...!");
        }



        public async Task<SemesterResponseDto> EditSemester(EditSemesterDto semester)
        {
            Semester oldSemester = (await _semesterRepo.FindAsync(q => q.Id == semester.SemesterId)).FirstOrDefault();

            if (oldSemester == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Semester with id = {semester.SemesterId} not found ...!" });

            oldSemester.SemesterName = semester.SemesterName ?? semester.SemesterName;
            oldSemester.StartDate = semester.StartDate;
            oldSemester.EndDate = semester.EndDate;
            oldSemester.Index = semester.Index;

            return await _semesterRepo.SaveChangesAsync() > 0 ? _Mapper.Map<SemesterResponseDto>(oldSemester) : throw new Exception("Error saving The data ...!");
        }



        public async Task<(object, int)> DeleteSemester(Guid semesterId)
        {
            Semester oldSemester = (await _semesterRepo.FindAsync(q => q.Id == semesterId)).FirstOrDefault();

            if (oldSemester == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Semester with id = {semesterId} not found ...!" });

            _semesterRepo.Remove(oldSemester);

            var result = 0;

            try
            {
                result = await _semesterRepo.SaveChangesAsync();
            }
            catch (Exception)
            {
                return (new { message = "لا يمكن حذف هذا الترم لإرتباطه بالمواد الدراسيه" }, result);
            }

            return ("", result);
        }


        public async Task<ActivationDto> SemesterActivation(Guid semesterId)
        {
            Semester dbSemester = (await _semesterRepo.FindAsync(q => q.Id == semesterId)).FirstOrDefault();

            if (dbSemester == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Semester with id = {semesterId} not found ...!" });

            if (dbSemester.IsActive == true)
            {
                dbSemester.IsActive = false;
                await _semesterRepo.SaveChangesAsync();

                var deActivatedStatus = new ActivationDto()
                {
                    Status = Status.DeActivated,
                    StatusFlag = false
                };

                return deActivatedStatus;
            }

            dbSemester.IsActive = true;

            await _semesterRepo.SaveChangesAsync();

            var activatedStatus = new ActivationDto()
            {
                Status = Status.Activated,
                StatusFlag = true
            };

            return activatedStatus;
        }


    }
}
