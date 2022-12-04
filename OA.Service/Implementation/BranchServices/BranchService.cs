using AutoMapper;
using OA.Data.Domain;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.BranchServices.Dtos;
using OA.Service.Implementation.Govern.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Implementation.BranchServices
{
    public class BranchService : IBranchService
    {
        private readonly IMapper _Mapper;

        private readonly IBranchRepo _branchRepo;

        public BranchService(IMapper mapper, IBranchRepo branchRepo)
        {
            _Mapper = mapper;
            _branchRepo = branchRepo;
        }

        public async Task<ResponseBranchDto> CreateBranch(CreateBranchDto model)
        {
            if (model.Name == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Branch name cannot be empty ...!" });

            var newBranch = _Mapper.Map<Branch>(model);

            newBranch.Id = Guid.NewGuid();

            await _branchRepo.AddAsync(newBranch);

            return await _branchRepo.SaveChangesAsync() > 0 ? _Mapper.Map<ResponseBranchDto>(newBranch) : throw new Exception("Error saving The data ...!");
        }

        public async Task<List<ResponseBranchDto>> GetBranchs()
        {
            var dataDb = await _branchRepo.GetAllAsync();

            var branchLists = _Mapper.Map<List<ResponseBranchDto>>(dataDb);

            return branchLists;
        }
    
    }
}
