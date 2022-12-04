using ImageMagick;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Repo.Dtos;
using OA.Repo.Enums;
using OA.Service.Implementation.ReportServices.Dtos;
using OA.Service.Interfaces;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading.Tasks;

namespace OA.Api.Controllers
{
    [Authorize]
    public class ReportController : ApiControllersBase
    {
        private readonly IReportService _ReportService;
        private readonly IHostingEnvironment _env;
        public ReportController(IReportService reportService, IHostingEnvironment hostingEnvironment)
        {
            _ReportService = reportService;
            _env = hostingEnvironment;
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("api/Report/ResizeAndCropImage")]
        public async Task<IActionResult> ResizeAndCropImage([FromForm] IFormFile image)
        {
            byte[] bytes;

            using (var ms = new MemoryStream())
            {
                await image.CopyToAsync(ms);
                bytes = ms.ToArray();
            }

            using (var imagebytes = new MagickImage(data: bytes))
            {
                imagebytes.ColorFuzz = new Percentage(10);

                imagebytes.Quality = 75;

                imagebytes.Resize(300, 150);

                System.Drawing.Image resizedImage = null;

                using (var ms = new MemoryStream(imagebytes.ToByteArray()))
                {
                    resizedImage = System.Drawing.Image.FromStream(ms);
                }

               // var croppedImage = CropImage(resizedImage);

                var directory = Path.Combine(_env.WebRootPath, FolderName.Files.ToString(), FolderName.Subjects.ToString());

                if (!Directory.Exists(directory)) { Directory.CreateDirectory(directory); }

                var fileName = $"{Guid.NewGuid().ToString()}.Jpg";

                var path = Path.Combine(_env.WebRootPath, FolderName.Files.ToString(), FolderName.Subjects.ToString(), fileName);

              //  croppedImage.Save(path, System.Drawing.Imaging.ImageFormat.Png);

            }

            return Ok();

        }


        //private System.Drawing.Image CropImage(Image image)
        //{
        //    int x = image.Width / 2;
        //    int y = image.Height / 2;
        //    int r = Math.Min(x, y);

        //    Bitmap bitmap = null;

        //    bitmap = new Bitmap(2 * r, 2 * r);

        //    using (Graphics g = Graphics.FromImage(bitmap))
        //    {
        //        g.SmoothingMode = SmoothingMode.AntiAlias;

        //        g.TranslateTransform(bitmap.Width / 2, bitmap.Height / 2);
        //        GraphicsPath gp = new GraphicsPath();
        //        gp.AddEllipse(0 - r, 0 - r, 2 * r, 2 * r);
        //        Region rg = new Region(gp);
        //        g.SetClip(rg, CombineMode.Replace);

        //        Bitmap bmp = new Bitmap(image);

        //        g.DrawImage(bmp, new Rectangle(-r, -r, 2 * r, 2 * r), new Rectangle(x - r, y - r, 2 * r, 2 * r), GraphicsUnit.Pixel);

        //    }

        //    return bitmap;

        //}


        [HttpPut]
        [Route("api/Report/ChangeImageExtension")]
        public async Task<IActionResult> ChangeImageExtension(ImageExtensionDto file)
        {
            await _ReportService.ChangeImageExtension(file);

            return Ok();
        }


        /// <summary>
        /// Web 
        /// </summary>
        [HttpPost]
        [Route("api/Report/GetRequestsReport")]
        public async Task<IActionResult> GetRequestsReport(ReportFilterDto filter)
        {
            RequestsReportDataDto report = await _ReportService.GetRequestsReport(filter);

            return Ok(report);
        }


        /// <summary>
        /// Web 
        /// </summary>
        [HttpGet]
        [Route("api/Report/GetRequestReportDetails/{RequestId}")]
        public async Task<IActionResult> GetRequestReportDetails(Guid RequestId)
        {
            RequestAnswerReportDto report = await _ReportService.GetRequestReportDetails(RequestId);

            return Ok(report);
        }


        /// <summary>
        /// Web 
        /// </summary>
        [HttpPost]
        [Route("api/Report/GetTeacherRequestReport")]
        public async Task<IActionResult> GetTeacherRequestReport(TeacherReportFilterDto filter)
        {
            TeacherRequestReportDto report = await _ReportService.GetTeacherRequestReport(filter);

            return Ok(report);
        }



        [HttpGet]
        [Route("api/Report/DashboardReport")]
        public async Task<IActionResult> DashboardReport()
        {
            DashboardReportDto report = await _ReportService.DashboardReport();

            return Ok(report);
        }



        /// <summary>
        /// Mobile
        /// </summary>
        [HttpPost]
        [Route("api/Report/TeacherViewRequestReport")]
        public async Task<IActionResult> TeacherViewRequestReport(TeacherReportMobileFilterDto filter)
        {
            TeacherRequestReportDto report = await _ReportService.TeacherViewRequestReport(filter);

            return Ok(report);
        }


    }
}
