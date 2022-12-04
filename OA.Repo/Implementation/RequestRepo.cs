using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Repo.Implementation
{
    public class RequestRepo : GenericRepository<Request>, IRequestRepo
    {
        private readonly ProjectContext _dbContext;
        public RequestRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Request> GetRequestAttachmentById(Guid requestId)
        {
            Request request = await _dbContext.Requests.Include(q => q.RequestFiles).FirstOrDefaultAsync(q => q.Id == requestId && !q.Deleted);

            return request;
        }


        public async Task<List<Request>> TeacherViewRequestReport(TeacherReportMobileFilterDto filter, Guid teacherId)
        {
            IQueryable<Request> dBrequests = _dbContext.Requests.Include(q => q.Teacher).Include(q => q.Subject).ThenInclude(q => q.Grade).ThenInclude(q => q.Stage).Where(q => !q.Deleted && q.TeacherId == teacherId).AsQueryable();

            if (!string.IsNullOrEmpty(filter.DateFrom) && !string.IsNullOrWhiteSpace(filter.DateFrom))
            {
                DateTime fromDate = DateTime.Parse(filter.DateFrom).Date;
                dBrequests = dBrequests.Where(t => t.Date.Date >= fromDate);
            }

            if (!string.IsNullOrEmpty(filter.DateTo) && !string.IsNullOrWhiteSpace(filter.DateTo))
            {
                DateTime toDate = DateTime.Parse(filter.DateTo).Date;
                dBrequests = dBrequests.Where(t => t.Date.Date <= toDate);
            }

            return await dBrequests.ToListAsync();
        }

        public async Task<List<Request>> GetTeacherRequestReport(TeacherReportFilter filter)
        {
            IQueryable<Request> dBrequests = _dbContext.Requests.Include(q => q.Teacher).Include(q => q.Subject).ThenInclude(q => q.Grade).ThenInclude(q => q.Stage).Where(q => !q.Deleted && q.TeacherId == filter.TeacherId).AsQueryable();

            if (filter.SectionId != null && filter.SectionId != Guid.Empty)
            {
                dBrequests = dBrequests.Where(t => t.Subject.SubjectSections.Any(a => a.SectionId == filter.SectionId));
            }

            if (filter.StageId != null && filter.StageId != Guid.Empty)
            {
                dBrequests = dBrequests.Where(t => t.Subject.Grade.StageId == filter.StageId);
            }

            if (filter.GradeId != null && filter.GradeId != Guid.Empty)
            {
                dBrequests = dBrequests.Where(t => t.Subject.GradeId == filter.GradeId);
            }

            if (filter.SubjectId != null && filter.SubjectId != Guid.Empty)
            {
                dBrequests = dBrequests.Where(t => t.SubjectId == filter.SubjectId);
            }

            if (!string.IsNullOrEmpty(filter.DateFrom) && !string.IsNullOrEmpty(filter.DateTo))
            {
                DateTime fromDate = DateTime.Parse(filter.DateFrom).Date;
                DateTime toDate = DateTime.Parse(filter.DateTo).Date;

                dBrequests = dBrequests.Where(t => t.Date.Date >= fromDate && t.Date.Date <= toDate);
            }

            return await dBrequests.ToListAsync();

        }


        public async Task<int> GenerateRquesrtNumber()
        {
            int rquesrtNumber = 1;

            Request request = await _dbContext.Requests.Where(q => !q.Deleted).OrderByDescending(q => q.RequestNo).FirstOrDefaultAsync();

            if (request != null)
            {
                rquesrtNumber = request.RequestNo;
                rquesrtNumber += 1;
            }

            return rquesrtNumber;
        }


        public async Task<List<Request>> CheckRequestAvailability(Guid studentId, Guid subjectId)
        {
            List<Request> request = await _dbContext.Requests.Where(q => q.StudentId == studentId && q.SubjectId == subjectId).Where(q => q.Date.Date == DateTime.Today.Date && !q.Deleted).ToListAsync();

            return request;
        }



        public async Task<Request> GetRequestById(Guid requestId)
        {
            Request request = await _dbContext.Requests.Include(q => q.Subject).ThenInclude(q => q.Grade).ThenInclude(q => q.Stage).Include(q => q.Subject).ThenInclude(a=>a.SubjectSections).ThenInclude(q => q.Section).Include(q => q.RequestFiles).Where(q => q.Id == requestId && !q.Deleted).FirstOrDefaultAsync();

            return request;
        }



        public async Task<List<Request>> GetStudentRequests(Guid studentId)
        {
            List<Request> requests = await _dbContext.Requests.Include(q => q.Subject).ThenInclude(q => q.Grade).ThenInclude(q => q.Stage).Include(q => q.RequestFiles).Where(q => q.StudentId == studentId && !q.Deleted).OrderByDescending(q => q.Date).ToListAsync();

            return requests;
        }


        public async Task<List<RequestAttachment>> GetTeacherRequestById(Guid requestId)
        {
            List<RequestAttachment> request = await _dbContext.RequestAttachments.Include(q => q.Request).ThenInclude(q => q.Subject).ThenInclude(q => q.Grade).ThenInclude(q => q.Stage).Where(q => q.RequestId == requestId && !q.Request.Deleted).ToListAsync();

            return request;
        }


        public async Task<List<Request>> GetTeacherRequests(Guid teacherId)
        {
            List<Request> requests = await _dbContext.Requests.Include(q => q.Subject).ThenInclude(q => q.Grade).ThenInclude(q => q.Stage).Include(q => q.RequestFiles).Where(q => q.TeacherId == teacherId && !q.Deleted).OrderByDescending(q => q.Date).ToListAsync();

            return requests;
        }



        public async Task<TeacherSubject> GetTeacherInRole(Guid subjectId)
        {

            Request request = await _dbContext.Requests.Include(q => q.Teacher).ThenInclude(q => q.User).Include(q => q.Teacher.TeacherSubjects).Where(q => q.SubjectId == subjectId && !q.Teacher.User.Deleted && !q.Deleted && q.Teacher.TeacherSubjects.Any(q => q.SubjectId == subjectId && q.Teacher.User.IsActive)).OrderByDescending(q => q.Date).FirstOrDefaultAsync();

            TeacherSubject nextTeacher = new TeacherSubject();

            if (request == null)
            {

                TeacherSubject teacherSubject = await _dbContext.TeacherSubjects.Include(q => q.Subject).Include(q => q.Teacher).ThenInclude(q => q.User).Where(q => q.SubjectId == subjectId && !q.Teacher.User.Deleted && q.Teacher.User.IsActive).OrderBy(q => q.Role).FirstOrDefaultAsync();

                if (teacherSubject != null)
                {
                    nextTeacher = teacherSubject;
                }

                else throw new RestException(HttpStatusCode.BadRequest, new { Message = "عفواا لايوجد مدرسين لهذه الماده الآن برجاء التواصل مع الدعم الفني" });

            }

            else if (request != null)
            {

                List<TeacherSubject> teacherSubjects = await _dbContext.TeacherSubjects.Include(q => q.Subject).Include(q => q.Teacher).ThenInclude(q => q.User).Where(q => q.SubjectId == subjectId && !q.Teacher.User.Deleted && q.Teacher.User.IsActive).OrderBy(q => q.Role).ToListAsync();

                int lastRequestTeacherRole = teacherSubjects.FirstOrDefault(q => q.TeacherId == request.TeacherId).Role;

                int maxRole = teacherSubjects.OrderByDescending(q => q.Role).FirstOrDefault().Role;


                if (lastRequestTeacherRole != maxRole && teacherSubjects.Count != 1)
                {
                    nextTeacher = teacherSubjects.FirstOrDefault(q => q.Role == lastRequestTeacherRole + 1);
                }

                else if (lastRequestTeacherRole == maxRole || teacherSubjects.Count == 1)
                {
                    nextTeacher = teacherSubjects.FirstOrDefault();
                }

                else throw new RestException(HttpStatusCode.BadRequest, new { Message = "عفواا لايوجد مدرسين لهذه الماده الآن برجاء التواصل مع الدعم الفني" });

            }

            return nextTeacher;

        }

        public async Task<(List<Request>, int)> GetRequestsReport(ReportFilter filter)
        {
            int skip = filter.PageSize * (filter.PageNo - 1);

            IQueryable<Request> dBrequests = _dbContext.Requests.Include(q => q.Student).ThenInclude(q => q.User).Include(q => q.Teacher).ThenInclude(q => q.User).Include(q => q.Subject).ThenInclude(q => q.SubjectSections).Include(q => q.Subject.Grade).Where(q => !q.Deleted).AsQueryable();

            if (filter.RequestNo != null && filter.RequestNo != 0)
            {
                dBrequests = dBrequests.Where(t => t.RequestNo == filter.RequestNo);
            }

            if (!string.IsNullOrEmpty(filter.StudentName) || !string.IsNullOrWhiteSpace(filter.StudentName))
            {
                dBrequests = dBrequests.Where(t => t.Student.User.UserFullName.ToLower().Contains(filter.StudentName.ToLower()));
            }

            if (!string.IsNullOrEmpty(filter.TeacherName) || !string.IsNullOrWhiteSpace(filter.TeacherName))
            {
                dBrequests = dBrequests.Where(t => t.Teacher.User.UserFullName.ToLower().Contains(filter.TeacherName));
            }

            if (!string.IsNullOrEmpty(filter.DateFrom) || !string.IsNullOrWhiteSpace(filter.DateFrom))
            {
                dBrequests = dBrequests.Where(t => t.Date.Date >= DateTime.Parse(filter.DateFrom).Date);
            }

            if (!string.IsNullOrEmpty(filter.DateTo) || !string.IsNullOrWhiteSpace(filter.DateTo))
            {
                dBrequests = dBrequests.Where(t => t.Date.Date <= DateTime.Parse(filter.DateTo).Date);
            }

            if (filter.SectionId != null && filter.SectionId != Guid.Empty)
            {
                dBrequests = dBrequests.Where(t => t.Subject.SubjectSections.Any(a=>a.SectionId==filter.SectionId));
            }

            if (filter.StageId != null && filter.StageId != Guid.Empty)
            {
                dBrequests = dBrequests.Where(t => t.Subject.Grade.StageId == filter.StageId);
            }

            if (filter.GradeId != null && filter.GradeId != Guid.Empty)
            {
                dBrequests = dBrequests.Where(t => t.Subject.GradeId == filter.GradeId);
            }

            if (filter.SubjectId != null && filter.SubjectId != Guid.Empty)
            {
                dBrequests = dBrequests.Where(t => t.SubjectId == filter.SubjectId);
            } 
            
            if (filter.Replied != null)
            {
                dBrequests = dBrequests.Where(t => t.Replied == filter.Replied);
            }

            int rowCount = dBrequests.Count();

            List<Request> requests = await dBrequests.OrderByDescending(q => q.RequestNo).Skip(skip).Take(filter.PageSize).ToListAsync();

            return (requests, rowCount);
        }


    }
}
