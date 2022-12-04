using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.ReportServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces.Infrastructure
{
   public interface INotificationHub
    {
        Task PushNotification(NotificationDto notification);
        Task PushDashboardReport(DashboardReportDto report);
    }
}
