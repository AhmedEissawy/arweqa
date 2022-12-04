using OA.Data.Domain;
using OA.Service.Implementation.Govern.Dtos;
using OA.Service.Implementation.UserServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IGovernService
    {
        Task<GovernResponseDto> CreateGovern(CreateGovernDto model);
        Task<List<GovernResponseDto>> GetGoverns();
    }
}