using OA.Service.Implementation.Govern.Dtos;
using OA.Service.Implementation.MzhbServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IMzhbService
    {
        Task<MzhbResponseDto> CreateMzhb(MzhbCreateDto model);
        Task<List<MzhbResponseDto>> GetMzhbs();
    }
}