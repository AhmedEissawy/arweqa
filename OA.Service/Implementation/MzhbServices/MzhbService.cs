using AutoMapper;
using OA.Data.Domain;
using OA.Repo.Errors;
using OA.Repo.Implementation;
using OA.Repo.Interfaces;
using OA.Service.Implementation.Govern.Dtos;
using OA.Service.Implementation.MzhbServices.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Implementation.MzhbServices
{
    public class MzhbService : IMzhbService
    {
        private readonly IMapper _Mapper;

        private readonly IMzhbRepo _mzhbRepo;

        public MzhbService(IMapper mapper, IMzhbRepo mzhbRepo)
        {
            _Mapper = mapper;
            _mzhbRepo = mzhbRepo;
        }


        public async Task<List<MzhbResponseDto>> GetMzhbs()
        {
            var dataDb = await _mzhbRepo.GetAllAsync();

            var mzhbLists = _Mapper.Map<List<MzhbResponseDto>>(dataDb);
       
            return mzhbLists;
        }

        public async Task<MzhbResponseDto> CreateMzhb(MzhbCreateDto model)
        {
            if (model.Name == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Mzhb name cannot be empty ...!" });

            var newMzhb = _Mapper.Map<Mzhb>(model);

            newMzhb.Id = Guid.NewGuid();

            await _mzhbRepo.AddAsync(newMzhb);

            return await _mzhbRepo.SaveChangesAsync() > 0 ? _Mapper.Map<MzhbResponseDto>(newMzhb) : throw new Exception("Error saving The data ...!");
        }

 
    }
}