using AutoMapper;
using OA.Data.Domain;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.Govern.Dtos;
using OA.Service.Implementation.GradeServices.Dtos;
using OA.Service.Implementation.SectionServices.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Implementation.Govern
{
    public class GovernService : IGovernService
    {
        private readonly IMapper _Mapper;

        private readonly IGovernRepo _governRepo;

        public GovernService(IMapper mapper, IGovernRepo governRepo)
        {
            _Mapper = mapper;
            _governRepo = governRepo;
        }

        public async Task<GovernResponseDto> CreateGovern(CreateGovernDto model)
        {
            if (model.Name == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Govern name cannot be empty ...!" });

            var newGovern = _Mapper.Map<Governorate>(model);

            newGovern.Id = Guid.NewGuid();

            await _governRepo.AddAsync(newGovern);

            return await _governRepo.SaveChangesAsync() > 0 ? _Mapper.Map<GovernResponseDto>(newGovern) : throw new Exception("Error saving The data ...!");
        }

        public async Task<List<GovernResponseDto>> GetGoverns()
        {
            var dataDb = await _governRepo.GetAllAsync();

            var governLists = _Mapper.Map<List<GovernResponseDto>>(dataDb);

            return governLists;
        }
    }
}