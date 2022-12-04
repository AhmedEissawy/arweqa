using OA.Service.Implementation.AnswerServices.Dtos;
using OA.Service.Implementation.RequestServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Implementation.ReportServices.Dtos
{
    public class RequestAnswerReportDto
    {
        public RequestResponseDto Request { get; set; }

        public AnswerResponseDto Answer { get; set; }
      
    }
}
