using OA.Service.Implementation.ExtraRequestServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IExtraRequestService
    {
        Task<ExtraRequestResponseDto> GetStudentExtraRequest(GetStudentExtraRequestDto extraRequest);

        Task<ExtraRequestResponseDto> AddExtraRequestToStudent(CreateExtraRequestDto extraRequest);

        Task<ExtraRequestResponseDto> EditStudentExtraRequest(EditExtraRequestDto extraRequest);

    }
}
