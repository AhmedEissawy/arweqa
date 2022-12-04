using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service.Interfaces.Infrastructure
{
    public interface IFileHandler
    {
        Task<String> SaveFile(IFormFile file, string folder);
        bool DeleteFile(string path, string folder);
        void ValiadteFile(IFormFile file);
        Task<String> SaveImageConverter(IFormFile image, string folder ,int width, int height);
        Task<String> SaveImageConverter(IFormFile image, string folder);
        Task<String> ResizeAndCropImage(IFormFile image, string folder);

    }
}
