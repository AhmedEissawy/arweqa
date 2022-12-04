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
    public class AnswerRepo : GenericRepository<Answer>, IAnswerRepo
    {
        private readonly ProjectContext _dbContext;
        public AnswerRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<Answer> GetAnswerByRequestId(Guid requestId)
        {
            Answer answer = await _dbContext.Answers.Include(q => q.Subject).ThenInclude(a=>a.SubjectSections).ThenInclude(q => q.Section).Include(q => q.Subject).ThenInclude(q => q.Grade).ThenInclude(q => q.Stage).Include(q => q.AnswerFiles).Where(q => q.RequestId == requestId).FirstOrDefaultAsync();

            return answer;
        }


        public async Task<Answer> GetTeacherAnswerById(Guid answerId)
        {
            Answer answer = await _dbContext.Answers.Include(q => q.Subject).Include(q => q.Teacher).Where(q => q.Id == answerId).FirstOrDefaultAsync();

            return answer;
        }


        public async Task<Answer> GetAnswerAttachmentByRequestId(Guid requestId)
        {
            Answer answer = await _dbContext.Answers.Include(q => q.AnswerFiles).FirstOrDefaultAsync(q => q.RequestId == requestId && !q.Deleted);

            return answer;
        }



    }
}