using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Repo.Implementation
{
    public class LibraryRepository : GenericRepository<Library>, ILibraryRepository
    {
        private readonly ProjectContext _dbContext;
        public LibraryRepository(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<List<Library>> GetLibrariesForAdmin(Guid gradeId)
        {
            List<Library> libraries = await _dbContext.Libraries.Include(q => q.Grade).Include(q => q.Semester).Where(q => q.GradeId == gradeId).ToListAsync();

            return libraries;
        }



        public async Task<List<Library>> GetLibraryFilesForStudent(string libraryCode, Guid gradeId, bool premiumSubscription)
        {
            IQueryable<Library> libraries = _dbContext.Libraries.Include(q => q.Grade).Include(q => q.Semester)
                .Where(q => q.GradeId == gradeId
                && q.IsPremium == false
                && q.CategoryCode == libraryCode
                && q.Grade.IsActive
                && q.Semester.StartDate.Date <= DateTime.Now.Date
                && q.Semester.EndDate.Date >= DateTime.Now.Date);

            if (premiumSubscription)
            {
                libraries = libraries.Where(q => q.IsPremium || !q.IsPremium);
            }

            return await libraries.OrderBy(q => q.Index).ToListAsync();
        }



    }
}