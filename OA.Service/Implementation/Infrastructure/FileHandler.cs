using ImageMagick;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using OA.Repo.Enums;
using OA.Service.Interfaces.Infrastructure;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OA.Service.Implementation.Infrastructure
{
    public class FileHandler : IFileHandler
    {
        private readonly IHostingEnvironment _env;
        public FileHandler(IHostingEnvironment env)
        {
            _env = env;
        }



        public async Task<String> SaveFile(IFormFile file, string folder)
        {
            var fileName = $"{Guid.NewGuid().ToString()}.{file.FileName.Split('.').Last()}";
            var directory = Path.Combine(_env.WebRootPath, FolderName.Files.ToString(), folder);
            if (!Directory.Exists(directory)) { Directory.CreateDirectory(directory); }
            var path = Path.Combine(_env.WebRootPath, FolderName.Files.ToString(), folder, fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
                return $"Files/{folder}/{fileName}";
            }

        }


        public bool DeleteFile(string path, string folder)
        {
            var rootpath = $"{_env.WebRootPath}\\Files\\{folder}";
            try
            {
                var files = Directory.GetFiles(rootpath, path.Split('/')[2], SearchOption.AllDirectories);

                if (files.Length > 0)
                {
                    foreach (var file in files)
                    {
                        var fileInfo = new System.IO.FileInfo(file);
                        fileInfo.Delete();

                    }
                    return true;
                }
                else return false;
            }

            catch (Exception)
            {
                return false;
            }

        }

        public async Task<String> SaveImageConverter(IFormFile image, string folder)
        {
            //HEIC & Plist Converter
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

                imagebytes.Resize(1200, 1000);

                var fileName = $"{Guid.NewGuid().ToString()}.Jpg";
                var directory = Path.Combine(_env.WebRootPath, FolderName.Files.ToString(), folder);
                if (!Directory.Exists(directory)) { Directory.CreateDirectory(directory); }

                var path = Path.Combine(_env.WebRootPath, FolderName.Files.ToString(), folder, fileName);

                imagebytes.Write(path);

                return $"Files/{folder}/{fileName}";

            }

        }


        public async Task<String> SaveImageConverter(IFormFile image, string folder , int width ,int height)
        {
            //HEIC & Plist Converter
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

                imagebytes.Resize(width, height);

                var fileName = $"{Guid.NewGuid().ToString()}.Jpg";
                var directory = Path.Combine(_env.WebRootPath, FolderName.Files.ToString(), folder);
                if (!Directory.Exists(directory)) { Directory.CreateDirectory(directory); }

                var path = Path.Combine(_env.WebRootPath, FolderName.Files.ToString(), folder, fileName);

                imagebytes.Write(path);

                return $"Files/{folder}/{fileName}";

            }

        }



        public async Task<String> ResizeAndCropImage(IFormFile image, string folder)
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

                var croppedImage = CropImage(resizedImage);

                var directory = Path.Combine(_env.WebRootPath, FolderName.Files.ToString(), folder);

                if (!Directory.Exists(directory)) { Directory.CreateDirectory(directory); }

                var fileName = $"{Guid.NewGuid().ToString()}.Jpg";

                var path = Path.Combine(_env.WebRootPath, FolderName.Files.ToString(), folder, fileName);

                croppedImage.Save(path, System.Drawing.Imaging.ImageFormat.Png);

                return $"Files/{folder}/{fileName}";

            }

        }



        private Image CropImage(Image image)
        {
            int x = image.Width / 2;
            int y = image.Height / 2;
            int r = Math.Min(x, y);

            Bitmap bitmap = null;

            bitmap = new Bitmap(2 * r, 2 * r);

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                g.TranslateTransform(bitmap.Width / 2, bitmap.Height / 2);
                GraphicsPath gp = new GraphicsPath();
                gp.AddEllipse(0 - r, 0 - r, 2 * r, 2 * r);
                Region rg = new Region(gp);
                g.SetClip(rg, CombineMode.Replace);

                Bitmap bmp = new Bitmap(image);

                g.DrawImage(bmp, new Rectangle(-r, -r, 2 * r, 2 * r), new Rectangle(x - r, y - r, 2 * r, 2 * r), GraphicsUnit.Pixel);

            }

            return bitmap;

        }



        public void ValiadteFile(IFormFile file)
        {
            if (file.Length > (50000 * 1024))
                throw new Exception(" Files size is larger than 5 Mb !");
            //if ((file.ContentType != "image/png"))
            //    throw new Exception("Image Type must be only jpeg or png!");
        }

    }
}
