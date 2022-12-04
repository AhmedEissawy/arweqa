using OA.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface ILessonRepo : IGenericRepository<Lesson>
    {
        Task<List<Lesson>> GetLessonsAdmin(Guid unitId);
        Task<Lesson> GetLessonDetailsForAdmin(Guid lessonId);
        Task<Lesson> GetLessonDetailsForStudent(Guid lessonId);
        Task<List<Lesson>> GetSubjectUnitsForStudent(Guid subjectId);
    }
}
