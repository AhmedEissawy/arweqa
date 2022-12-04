using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.SectionServices.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface ISectionService
    {
        Task<SectionResponseDto> AddSection(CreateSectionDto section);
        Task<List<SectionResponseDto>> GetAllSectionsAdmin();
        Task<List<SectionResponseDto>> GetSections();
        Task<SectionResponseDto> GetSectionById(Guid sectionId);
        Task<SectionResponseDto> EditSection(EditSectionDto section);
        Task<(object, int)> DeleteSection(Guid sectionId);
        Task<ActivationDto> SectionActivation(Guid sectionId);
    }
}
