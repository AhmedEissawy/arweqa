using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Repo.Implementation
{
    public class LessonLiveVideoRepo : GenericRepository<LessonVideoRoom>, Interfaces.ILessonLiveVideoRepo
    {
        public LessonLiveVideoRepo(ProjectContext context) : base(context)
        {

        }

        public Task<LessonVideoRoom> GetRoomByCode(string code)
        {
            return _dbSet.Include(a=>a.Connections).Include(a => a.Lesson).ThenInclude(a=>a.Unit).ThenInclude(a=>a.Subject).FirstOrDefaultAsync(a => a.RoomId == code);
        }

        public Task<LessonVideoRoom> GetRoomByConnectionId(string connectionId)
        {
            return _dbSet.FirstOrDefaultAsync(a => a.Connections.Any(z => z.Connection_Id == connectionId));
        }
    }
}
