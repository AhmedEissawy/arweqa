using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Repo.Implementation
{
    public class NotificationRepo : GenericRepository<Notification>, INotificationRepo
    {
        public IConfiguration Configuration { get; }
        private readonly ProjectContext _dbContext;
        public NotificationRepo(ProjectContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            Configuration = configuration;
            _dbContext = dbContext;
        }

        public async Task<(List<Notification>, int totalCount, int notSeenCount)> GetNotifications(int PageSize, int PageNo)
        {
            int skip = PageSize * (PageNo - 1);

            List<Notification> notifications = await _dbContext.Notifications.OrderByDescending(q => q.Date).ToListAsync();

            return (notifications.OrderByDescending(q => q.Date).Skip(skip).Take(PageSize).ToList(), notifications.Count(), notifications.Where(q => !q.Seen).Count());
        }




        public async Task<DashboardReport> DashboardReport()
        {
            DashboardReport report = new DashboardReport();

            SqlDataReader sdr;

            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection")))
            {
                SqlCommand cmd = new SqlCommand("DashboardReport", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                await connection.OpenAsync();

                sdr = await cmd.ExecuteReaderAsync();

                while (await sdr.ReadAsync())
                {
                    report.Section = Convert.ToInt16(sdr["Section"]);
                    report.Stage = Convert.ToInt16(sdr["Stage"]);
                    report.Grade = Convert.ToInt16(sdr["Grade"]);
                    report.Subject = Convert.ToInt16(sdr["Subject"]);
                    report.Student = Convert.ToInt16(sdr["Student"]);
                    report.Teacher = Convert.ToInt16(sdr["Teacher"]);
                    report.Request = Convert.ToInt16(sdr["Request"]);
                    report.RepliedRequest = Convert.ToInt16(sdr["RepliedRequest"]);
                    report.RepliedInTimeRequest = Convert.ToInt16(sdr["RepliedInTimeRequest"]);
                    report.NotRepliedRequest = Convert.ToInt16(sdr["NotRepliedRequest"]);

                }

                await connection.CloseAsync();

            }

            return report;
        }


    }
}
