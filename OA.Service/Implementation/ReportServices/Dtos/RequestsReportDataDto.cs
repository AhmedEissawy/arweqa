using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.ReportServices.Dtos
{
    public class RequestsReportDataDto
    {
        public int RowCount { get; set; }

        public ICollection<RequestsReportDto> RequestsReport { get; set; }
    }
}
