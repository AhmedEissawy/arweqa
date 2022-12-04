using OA.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface ILibraryRepository : IGenericRepository<Library>
    {
        Task<List<Library>> GetLibrariesForAdmin(Guid gradeId);
        Task<List<Library>> GetLibraryFilesForStudent(string libraryCode, Guid gradeId, bool premiumSubscription);
    }
}
