using OA.Data.Domain;
using OA.Repo.Interfaces;

namespace OA.Repo.Implementation
{
    public class LessonAttachmentRepo : GenericRepository<LessonAttachment>, ILessonAttachmentRepo
    {
        private readonly ProjectContext _dbContext;
        public LessonAttachmentRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
