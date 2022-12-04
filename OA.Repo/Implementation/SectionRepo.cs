using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Repo.Implementation
{
    public class SectionRepo : GenericRepository<Section>, ISectionRepo
    {
        private readonly ProjectContext _dbContext;
        public SectionRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Section>> GetSectionsAdmin()
        {
            List<Section> sections = await _dbContext.Sections.Include(q => q.SubjectGrades).OrderBy(a => a.Index).ThenBy(a=>a.SectionName).ToListAsync();

            return sections;
        }

        public async Task<List<Section>> GetSections()
        {
            List<Section> sections = await _dbContext.Sections.Include(q => q.SubjectGrades).Where(q => !q.Deleted && q.IsActive).OrderBy(a=>a.Index).ThenBy(a=>a.SectionName).ToListAsync();

            return sections;
        }
    }
}
