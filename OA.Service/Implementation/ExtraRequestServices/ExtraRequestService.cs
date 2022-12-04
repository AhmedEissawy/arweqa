using AutoMapper;
using OA.Data.Domain;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.ExtraRequestServices.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Implementation.ExtraRequestServices
{
    public class ExtraRequestService : IExtraRequestService
    {
        private readonly IMapper _Mapper;
        private readonly IExtraRequestRepo _ExtraRequestRepo;
        public ExtraRequestService(IMapper mapper, IExtraRequestRepo extraRequestRepo)
        {
            _Mapper = mapper;
            _ExtraRequestRepo = extraRequestRepo;
        }

        public async Task<ExtraRequestResponseDto> AddExtraRequestToStudent(CreateExtraRequestDto extraRequest)
        {
           
            ExtraRequest newExtraRequest = _Mapper.Map<ExtraRequest>(extraRequest);

            newExtraRequest.Id = Guid.NewGuid();

            await _ExtraRequestRepo.AddAsync(newExtraRequest);

            return await _ExtraRequestRepo.SaveChangesAsync() > 0 ? _Mapper.Map<ExtraRequestResponseDto>(newExtraRequest) : throw new Exception("Error saving The data ...!");
        }


        public async Task<ExtraRequestResponseDto> EditStudentExtraRequest(EditExtraRequestDto extraRequest)
        {
            ExtraRequest oldExtraRequest = (await _ExtraRequestRepo.FindAsync(q => q.Id == extraRequest.ExtraRequestId)).FirstOrDefault();

            if (oldExtraRequest == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The ExtraRequest with id = {extraRequest.ExtraRequestId} not found ...!" });

            oldExtraRequest.RequestCount = extraRequest.RequestCount;

            return await _ExtraRequestRepo.SaveChangesAsync() > 0 ? _Mapper.Map<ExtraRequestResponseDto>(oldExtraRequest) : throw new Exception("Error saving The data ...!");
        }


        public async Task<ExtraRequestResponseDto> GetStudentExtraRequest(GetStudentExtraRequestDto extraRequest)
        {
            ExtraRequest dbExtraRequest = await _ExtraRequestRepo.GetStudentExtraRequest(extraRequest.StudentId , extraRequest.SubjectId);

            if (dbExtraRequest == null)
            {

                return new ExtraRequestResponseDto()
                {
                    ExtraRequestId = Guid.Empty,
                    StudentId = extraRequest.StudentId,
                    SubjectId = extraRequest.SubjectId,
                    RequestCount = 0
                };
            }
                 
            return _Mapper.Map<ExtraRequestResponseDto>(dbExtraRequest);
        }
    }
}
