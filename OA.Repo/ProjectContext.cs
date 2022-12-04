using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OA.Data;
using OA.Data.Domain;
using OA.Repo.Enums;
using OA.Repo.Interfaces;
using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace OA.Repo
{
    public class ProjectContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, IdentityUserClaim<Guid>, ApplicationUserRole, ApplicationUserLogin, IdentityRoleClaim<Guid>, ApplicationUserToken>
    {

        private readonly IUserAccessor _userAccessor;
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
            _userAccessor =  this.GetService<IUserAccessor>();
        }
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
            builder.Ignore<IdentityUserLogin<Guid>>();
            builder.Ignore<IdentityUserToken<Guid>>();
            builder.Ignore<IdentityUserRole<Guid>>();
        }

        #region Tables
        public DbSet<ApplicationUser> AspNetUsers { get; set; }
        public DbSet<ApplicationUserRole> AspNetUserRoles { get; set; }
        public DbSet<ApplicationUserLogin> AspNetUserLogins { get; set; }
        public DbSet<ApplicationUserToken> AspNetUserTokens { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<SubjectGrade> SubjectGrades { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestAttachment> RequestAttachments { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<AnswerAttachment> AnswerAttachments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<ExtraRequest> ExtraRequests { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ExceptionLogger> ExceptionLoggers { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonAttachment> LessonAttachments { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<LibraryType> LibraryTypes { get; set; }
        public DbSet<LessonQuestion> LessonQuestions { get; set; }
        public DbSet<LessonQuestionAnswer> LessonQuestionAnswers { get; set; }
        public DbSet<StudentLessonQuestionAnswer> StudentlessonQuestionAnswers { get; set; }
        public DbSet<SocialLink> SocialLinks { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<TeacherSubjectPermession>  TeacherSubjectPermessions { get; set; }

        #endregion

        #region procedures
        //public DbSet<ProcDashboardReport> ProcDashboardReport { get; set; }
        #endregion

        #region AuditSaveChanges

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
           // var superAdmin = await AspNetUsers.FirstOrDefaultAsync(x => x.IsActive && x.UserType == UserType.SuperAdmin.ToString());

            foreach (var entry in ChangeTracker.Entries<BaseEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = Guid.Parse(_userAccessor.GetCurrentUserId() ?? ApplicationConstatns.SuperAdminUserId);
                        entry.Entity.CreateDate = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = Guid.Parse(_userAccessor.GetCurrentUserId() ?? ApplicationConstatns.SuperAdminUserId);
                        entry.Entity.LastModifyDate = DateTime.UtcNow;
                        break;

                }
            }

            if (ChangeTracker.Entries<ApplicationUser>().Any())
            {
                foreach (var entry in ChangeTracker.Entries<ApplicationUser>().ToList())
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreatedBy = Guid.Parse(_userAccessor.GetCurrentUserId() ?? ApplicationConstatns.SuperAdminUserId);
                            entry.Entity.CreateDate = DateTime.UtcNow;
                            break;

                        case EntityState.Modified:
                            entry.Entity.LastModifiedBy = Guid.Parse(_userAccessor.GetCurrentUserId() ?? ApplicationConstatns.SuperAdminUserId);
                            entry.Entity.LastModifyDate = DateTime.UtcNow;
                            break;

                    }
                }
            }

            return await base.SaveChangesAsync(cancellationToken);

        }

        #endregion AuditSaveChanges

    }
}
