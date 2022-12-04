using AutoMapper;
using OA.Data.Domain;
using OA.Repo.Enums;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.SectionServices.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Service.Implementation.SectionServices
{
    public class SectionService : ISectionService
    {
        private readonly IMapper _Mapper;
        private readonly ISectionRepo _SectionRepo;
        public SectionService(IMapper mapper, ISectionRepo sectionRepo)
        {
            _Mapper = mapper;
            _SectionRepo = sectionRepo;
        }



        public async Task<SectionResponseDto> AddSection(CreateSectionDto Section)
        {
            if (Section.SectionName == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Section name cannot be empty ...!" });

            Section newSection = _Mapper.Map<Section>(Section);

            newSection.Id = Guid.NewGuid();

            await _SectionRepo.AddAsync(newSection);

            return await _SectionRepo.SaveChangesAsync() > 0 ? _Mapper.Map<SectionResponseDto>(newSection) : throw new Exception("Error saving The data ...!");

        }



        public async Task<List<SectionResponseDto>> GetAllSectionsAdmin()
        {
            List<Section> Sections = await _SectionRepo.GetSectionsAdmin();

            return _Mapper.Map<List<SectionResponseDto>>(Sections);

        }

        public async Task<List<SectionResponseDto>> GetSections()
        {
            List<Section> Sections = await _SectionRepo.GetSections();

            return _Mapper.Map<List<SectionResponseDto>>(Sections);

        }



        public async Task<SectionResponseDto> GetSectionById(Guid SectionId)
        {
            Section dbSection = (await _SectionRepo.FindAsync(q => q.Id == SectionId)).FirstOrDefault();

            if (dbSection == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Section with id = {SectionId} not found ...!" });

            return _Mapper.Map<SectionResponseDto>(dbSection);

        }



        public async Task<SectionResponseDto> EditSection(EditSectionDto Section)
        {
            Section oldSection = (await _SectionRepo.FindAsync(q => q.Id == Section.SectionId)).FirstOrDefault();

            if (oldSection == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Section with id = {Section.SectionId} not found ...!" });

            oldSection.SectionName = Section.SectionName;
            oldSection.Index = Section.Index;

            return await _SectionRepo.SaveChangesAsync() > 0 ? _Mapper.Map<SectionResponseDto>(oldSection) : throw new Exception("Error saving The data ...!");

        }



        public async Task<(object, int)> DeleteSection(Guid SectionId)
        {
            Section oldSection = (await _SectionRepo.FindAsync(q => q.Id == SectionId)).FirstOrDefault();

            if (oldSection == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Section with id = {SectionId} not found ...!" });

            _SectionRepo.Remove(oldSection);

            var result = 0;

            try
            {
                result = await _SectionRepo.SaveChangesAsync();
            }
            catch (Exception)
            {
                return (new { message = "لا يمكن حذف هذه المجموعه لإرتباطها بالطلاب والمواد الدراسيه" }, result);
            }

            return ("", result);

        }


        public async Task<ActivationDto> SectionActivation(Guid sectionId)
        {
            Section dbSection = (await _SectionRepo.FindAsync(q => q.Id == sectionId)).FirstOrDefault();

            if (dbSection == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" The Section with id = {sectionId} not found ...!" });

            if (dbSection.IsActive == true)
            {
                dbSection.IsActive = false;
                await _SectionRepo.SaveChangesAsync();

                var deActivatedStatus = new ActivationDto()
                {
                    Status = Status.DeActivated,
                    StatusFlag = false
                };

                return deActivatedStatus;
            }

            dbSection.IsActive = true;

            await _SectionRepo.SaveChangesAsync();

            var activatedStatus = new ActivationDto()
            {
                Status = Status.Activated,
                StatusFlag = true
            };

            return activatedStatus;
        }



    }
}
