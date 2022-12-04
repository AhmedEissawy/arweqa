using OA.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface IAnswerRepo : IGenericRepository<Answer>
    {

        Task<Answer> GetAnswerByRequestId(Guid requestId);
        Task<Answer> GetAnswerAttachmentByRequestId(Guid requestId);
        Task<Answer> GetTeacherAnswerById(Guid answerId);


    }
}
