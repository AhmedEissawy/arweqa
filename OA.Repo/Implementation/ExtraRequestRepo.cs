using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Implementation
{
    public class ExtraRequestRepo : GenericRepository<ExtraRequest>, IExtraRequestRepo
    {
        private readonly ProjectContext _dbContext;
        public ExtraRequestRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ExtraRequest> GetStudentExtraRequest(Guid studentId, Guid subjectId)
        {
            ExtraRequest extraRequest = await _dbContext.ExtraRequests.Include(q => q.Student).Include(q => q.Subject).Where(q => q.StudentId == studentId && q.SubjectId == subjectId).FirstOrDefaultAsync();

            return extraRequest;
        }
    }
}
