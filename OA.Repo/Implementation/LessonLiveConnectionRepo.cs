using OA.Data.Domain;
using OA.Repo.Interfaces;

namespace OA.Repo.Implementation
{
    public class LessonLiveConnectionRepo : GenericRepository<LessonVideoRoomConnections>, ILessonLiveConnectionsRepo
    {
        public LessonLiveConnectionRepo(ProjectContext context) : base(context)
        {
        }
    }
}
