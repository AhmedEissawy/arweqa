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
    public class GradeRepo : GenericRepository<Grade>, IGradeRepo
    {
        private readonly ProjectContext _dbContext;
        public GradeRepo(ProjectContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(List<Grade>, int count)> GetGrades(FilterDto filterDto)
        {

            int skip = filterDto.PageSize * (filterDto.PageNo - 1);

            IQueryable<Grade> gradeList = _dbContext.Grades.Include(q => q.Stage).Where(q => !q.Deleted).AsQueryable();

            if (filterDto.StageId != null && filterDto.StageId != Guid.Empty)
            {
                gradeList = gradeList.Where(q => q.StageId == filterDto.StageId);
            }

            if (!string.IsNullOrEmpty(filterDto.Name) && !string.IsNullOrWhiteSpace(filterDto.Name))
            {
                gradeList = gradeList.Where(q => q.GradeName.ToLower().Contains(filterDto.Name.ToLower()));
            }

            if (filterDto.IsActive != null)
            {
                gradeList = gradeList.Where(q => q.IsActive == filterDto.IsActive);
            }

            int count = gradeList.Count();

            return (await gradeList.OrderBy(q => q.Index).Skip(skip).Take(filterDto.PageSize).ToListAsync(), count);
        }

        public async Task<Grade> GetGradeById(Guid gradeId)
        {
            Grade grade = await _dbContext.Grades.Include(q => q.Stage).Where(q => !q.Deleted).FirstOrDefaultAsync(q => q.Id == gradeId);

            return grade;
        }

        public async Task<List<Grade>> GetGradesByStageIdAdmin(Guid stageId)
        {
            List<Grade> gradeList = await _dbContext.Grades.Include(q => q.Stage).Where(q => q.StageId == stageId && !q.Deleted).OrderBy(q => q.Index).ToListAsync();

            return gradeList;
        }
        
        public async Task<List<Grade>> GetGradesByStageId(Guid stageId)
        {
            List<Grade> gradeList = await _dbContext.Grades.Include(q => q.Stage).Where(q => q.StageId == stageId && !q.Deleted && q.IsActive).OrderBy(q => q.Index).ToListAsync();

            return gradeList;
        }

        public async Task<int> GetLastGradeIndex()
        {
            List<Grade> grade = await _dbContext.Grades.ToListAsync();

            int index = 0;

            if (grade.Count != 0)
            {
                index = grade.Max(q => q.Index);
            }
            else
            {
                index = 1;
            }

            return index;
        }
    }
}
