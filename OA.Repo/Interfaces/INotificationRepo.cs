using OA.Data.Domain;
using OA.Repo.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repo.Interfaces
{
    public interface INotificationRepo : IGenericRepository<Notification>
    {
        Task<(List<Notification>, int totalCount, int notSeenCount)> GetNotifications(int PageSize, int PageNo);
        Task<DashboardReport> DashboardReport();
    }

}
