using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Repo.Implementation;
using OA.Repo.Interfaces;
using OA.Service.Implementation.AnswerServices.Dtos;
using OA.Service.Implementation.ReportServices.Dtos;
using OA.Service.Implementation.RequestServices.Dtos;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OA.Service.Implementation.ReportServices
{
    public class ReportService : IReportService
    {

        private readonly IMapper _Mapper;
        private readonly IRequestRepo _RequestRepo;
        private readonly IRequestAttachmentRepo _RequestAttachmentRepo;
        private readonly IUserAccessor _userAccessor;
        private readonly IAnswerRepo _AnswerRepo;
        private readonly INotificationRepo _NotificationRepo;
        private readonly IHostingEnvironment _env;
        public ReportService(IUserAccessor userAccessor ,IMapper mapper, IRequestRepo requestRepo, IAnswerRepo answerRepo, INotificationRepo notificationRepo, IRequestAttachmentRepo requestAttachmentRepo, IHostingEnvironment hostingEnvironment)
        {
            _Mapper = mapper;
            _userAccessor = userAccessor;
            _RequestRepo = requestRepo;
            _AnswerRepo = answerRepo;
            _NotificationRepo = notificationRepo;
            _RequestAttachmentRepo = requestAttachmentRepo;
            _env = hostingEnvironment;

        }



        public async Task<TeacherRequestReportDto> GetTeacherRequestReport(TeacherReportFilterDto filter)
        {
            TeacherReportFilter filterData = _Mapper.Map<TeacherReportFilter>(filter);

            List<Request> requests = await _RequestRepo.GetTeacherRequestReport(filterData);

            TeacherRequestReportDto report = new TeacherRequestReportDto();

            report.Request = requests.Count();
            report.RepliedRequest = requests.Where(q => q.Replied).Count();
            report.RepliedInTimeRequest = requests.Where(q => q.RepliedInTime).Count();
            report.NotRepliedRequest = requests.Where(q => !q.Replied).Count();

            return report;

        }

        public async Task<TeacherRequestReportDto> TeacherViewRequestReport(TeacherReportMobileFilterDto filter)
        {
            List<Request> requests = await _RequestRepo.TeacherViewRequestReport(filter, Guid.Parse(_userAccessor.GetCurrentUserId()));

            TeacherRequestReportDto report = new TeacherRequestReportDto();

            report.Request = requests.Count();
            report.RepliedRequest = requests.Where(q => q.Replied).Count();
            report.RepliedInTimeRequest = requests.Where(q => q.RepliedInTime).Count();
            report.NotRepliedRequest = requests.Where(q => !q.Replied).Count();

            return report;
        }

        public async Task ChangeImageExtension(ImageExtensionDto file)
        {
            RequestAttachment requestAttachment = (await _RequestAttachmentRepo.FindAsync(q => q.File.Contains(file.FileName))).FirstOrDefault();

            if (requestAttachment != null)
            {
                var extension = $"{file.FileName.Split('.').Last()}";

                if ((extension == "HEIC") || (extension == "plist"))
                {
                    if (extension == "HEIC")
                    {
                        requestAttachment.File = file.FileName.Replace("HEIC", "png");

                        var rootpath = $"{_env.WebRootPath}\\";

                        var files = Directory.GetFiles(rootpath, file.FileName.Split('/')[2], SearchOption.AllDirectories);

                        string oldFileName = file.FileName.Split('\\').Last();

                        string newFileName = requestAttachment.File.Split('\\').Last();

                        string path = rootpath;
                        string Fromfile = path + oldFileName;
                        string Tofile = path + newFileName;
                        File.Move(Fromfile, Tofile);

                    }

                    else
                    {
                        requestAttachment.File = file.FileName.Replace("plist", "png");

                        var rootpath = $"{_env.WebRootPath}\\";

                        var files = Directory.GetFiles(rootpath, file.FileName.Split('/')[2], SearchOption.AllDirectories);

                        string oldFileName = file.FileName.Split('\\').Last();

                        string newFileName = requestAttachment.File.Split('\\').Last();

                        string path = rootpath;
                        string Fromfile = path + oldFileName;
                        string Tofile = path + newFileName;
                        File.Move(Fromfile, Tofile);
                    }

                    await _RequestAttachmentRepo.SaveChangesAsync();
                }

            }

        }


        public System.Drawing.Image ClipImage(System.Drawing.Image srcImage)
        {
            int x = srcImage.Width / 2;
            int y = srcImage.Height / 2;
            int r = Math.Min(x,y);

            Bitmap tmp = null;

            tmp = new Bitmap(2 * r, 2 * r);
            using (Graphics g = Graphics.FromImage(tmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.TranslateTransform(tmp.Width / 2, tmp.Height / 2);
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(0 - r, 0 - r, 2 * r, 2 * r);
                Region rg = new Region(gp);
                g.SetClip(rg, CombineMode.Replace);
                Bitmap bmp = new Bitmap(srcImage);
                g.DrawImage(bmp, new Rectangle(-r, -r, 2 * r, 2 * r), new Rectangle(x - r, y - r, 2 * r, 2 * r), GraphicsUnit.Pixel);
            }

            return tmp;


        }

        //public Image ClipToCircle(Image srcImage, PointF center, float radius, Color backGround)
        //{
        //    Image dstImage = new Bitmap(srcImage.Width, srcImage.Height, srcImage.PixelFormat);

        //    using (Graphics g = Graphics.FromImage(dstImage))
        //    {
        //        RectangleF r = new RectangleF(center.X - radius, center.Y - radius,
        //                                                 radius * 2, radius * 2);

        //        // enables smoothing of the edge of the circle (less pixelated)
        //        g.SmoothingMode = SmoothingMode.AntiAlias;

        //        // fills background color
        //        using (Brush br = new SolidBrush(backGround))
        //        {
        //            g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
        //        }

        //        // adds the new ellipse & draws the image again 
        //        GraphicsPath path = new GraphicsPath();
        //        path.AddEllipse(r);
        //        g.SetClip(path);
        //        g.DrawImage(srcImage, 0, 0);

        //        return dstImage;
        //    }
        //}

        public async Task<RequestsReportDataDto> GetRequestsReport(ReportFilterDto filter)
        {
            ReportFilter Mapedfilter = _Mapper.Map<ReportFilter>(filter);

            var requests = await _RequestRepo.GetRequestsReport(Mapedfilter);

            RequestsReportDataDto report = new RequestsReportDataDto();

            report.RequestsReport = _Mapper.Map<List<RequestsReportDto>>(requests.Item1);

            report.RowCount = requests.Item2;

            return report;

        }



        public async Task<RequestAnswerReportDto> GetRequestReportDetails(Guid requestId)
        {
            Request request = await _RequestRepo.GetRequestById(requestId);

            Answer Answer = await _AnswerRepo.GetAnswerByRequestId(requestId);

            RequestAnswerReportDto requestAnswerReport = new RequestAnswerReportDto();

            requestAnswerReport.Request = _Mapper.Map<RequestResponseDto>(request);

            requestAnswerReport.Answer = _Mapper.Map<AnswerResponseDto>(Answer);

            return requestAnswerReport;

        }



        public async Task<DashboardReportDto> DashboardReport()
        {
            DashboardReport dbreport = await _NotificationRepo.DashboardReport();

            DashboardReportDto report = _Mapper.Map<DashboardReportDto>(dbreport);

            return report;
        }


    }
}
