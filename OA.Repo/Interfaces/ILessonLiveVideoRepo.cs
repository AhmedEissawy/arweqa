using OA.Data.Domain;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface ILessonLiveVideoRepo:IGenericRepository<LessonVideoRoom>
    {
        Task<LessonVideoRoom> GetRoomByCode(string code);
        Task<LessonVideoRoom> GetRoomByConnectionId(string connectionId);
    }
}
