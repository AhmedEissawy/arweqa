using OA.Data.Domain;
using OA.Service.Implementation.LessonServices.Dtos;
using OA.Service.Implementation.LibraryServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface ILibraryService
    {
        Task<List<string>> GetLibraryTypes();
        Task<List<LibraryResponseDto>> GetLibrariesForAdmin(Guid gradeId);
        Task AddLibrary(CreateLibraryDto library);
        Task DeleteLibrary(Guid libraryId);
        Task<List<MobileLibraryResponseDto>> GetLibraryFilesForStudent(string libraryCode);
    }
}
