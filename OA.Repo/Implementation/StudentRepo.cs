using Microsoft.EntityFrameworkCore;
using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Repo.Implementation
{
    public class StudentRepo : GenericRepository<Student>, IStudentRepo
    {
        private readonly ProjectContext _dbContext;
        public StudentRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<(List<Student>, int)> GetStudents(FilterDto filter)
        {
            IQueryable<Student> dBStudents = _dbContext.Students.Include(q => q.User).ThenInclude(q => q.Grade).ThenInclude(q => q.Stage).Include(q => q.User).ThenInclude(q => q.Section).Where(q => !q.User.Deleted && !q.Deleted).AsQueryable();

            int skip = filter.PageSize * (filter.PageNo - 1);

            if (filter.SectionId != null && filter.SectionId != Guid.Empty)
            {
                dBStudents = dBStudents.Where(t => t.User.SectionId == filter.SectionId);
            }

            if (filter.StageId != null && filter.StageId != Guid.Empty)
            {
                dBStudents = dBStudents.Where(t => t.User.Grade.StageId == filter.StageId);
            }

            if (filter.GradeId != null && filter.GradeId != Guid.Empty)
            {
                dBStudents = dBStudents.Where(t => t.User.GradeId == filter.GradeId);
            }

            if (!(string.IsNullOrEmpty(filter.Name)) && !(string.IsNullOrWhiteSpace(filter.Name)))
            {
                dBStudents = dBStudents.Where(t => t.User.UserFullName.ToLower().Contains(filter.Name.ToLower()));
            } 
            
            if (!(string.IsNullOrEmpty(filter.Mobile)) && !(string.IsNullOrWhiteSpace(filter.Mobile)))
            {
                dBStudents = dBStudents.Where(t => t.User.PhoneNumber.Contains(filter.Mobile));
            }

            if (filter.IsActive != null)
            {
                dBStudents = dBStudents.Where(t => t.User.IsActive == filter.IsActive);
            }

            int rowCount = dBStudents.Count();

            return (await dBStudents.OrderBy(q => q.User.UserFullName).Skip(skip).Take(filter.PageSize).ToListAsync(), rowCount);
        }



        public async Task<Student> GetStudentById(Guid studentId)
        {
            Student dBStudent = await _dbContext.Students.Include(s => s.Governorate).Include(s => s.Mzhb).Include(s => s.Branch).Include(q => q.User).ThenInclude(q => q.Grade).ThenInclude(q => q.Stage).Include(q => q.User).ThenInclude(q => q.Section).FirstOrDefaultAsync(q => q.Id == studentId && !q.Deleted && !q.User.Deleted);

            return dBStudent;
        }

        public async Task<Student> GetStudentByIdentityId(Guid studentIdentityId)
        {
            Student dBStudent = await _dbContext.Students.Include(q => q.User).FirstOrDefaultAsync(q => q.Id == studentIdentityId && !q.User.Deleted && !q.Deleted);

            return dBStudent;
        }

        public Task<List<Student>> GetStudentsForGroup(FilterDto filter)
        {
            var query = _dbSet.Where(a => !a.Deleted).Include(a=>a.User).AsQueryable();

            if (filter.GradeId.HasValue)
                query = query.Where(a => a.User.GradeId == filter.GradeId);

            if (filter.SectionId.HasValue)
                query = query.Where(a => a.User.SectionId == filter.SectionId);

            if (filter.IsActive.HasValue)
                query = query.Where(a => a.User.IsActive == filter.IsActive);
           
            return query.ToListAsync();


                   
        }

        public Task<int> GetSTudentsCount(FilterDto filter)
        {
            IQueryable<Student> dBStudents = _dbContext.Students.Include(q => q.User).ThenInclude(q => q.Grade).ThenInclude(q => q.Stage).Include(q => q.User).ThenInclude(q => q.Section).Where(q => !q.User.Deleted && !q.Deleted).AsQueryable();
            if (filter.SectionId != null && filter.SectionId != Guid.Empty)
            {
                dBStudents = dBStudents.Where(t => t.User.SectionId == filter.SectionId);
            }

            if (filter.StageId != null && filter.StageId != Guid.Empty)
            {
                dBStudents = dBStudents.Where(t => t.User.Grade.StageId == filter.StageId);
            }

            if (filter.GradeId != null && filter.GradeId != Guid.Empty)
            {
                dBStudents = dBStudents.Where(t => t.User.GradeId == filter.GradeId);
            }

            if (filter.IsActive != null)
            {
                dBStudents = dBStudents.Where(t => t.User.IsActive == filter.IsActive);
            }

            return dBStudents.CountAsync();
        }

        public async Task<Student> GetStudentAsync(string studentId)
        {
            return await _dbSet.Where(s => s.Id.ToString() == studentId).Include(s => s.User).Include(s => s.Mzhb).Include(s => s.Governorate).Include(s => s.Branch).FirstOrDefaultAsync();
        }
    }
}