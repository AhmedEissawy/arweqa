using OA.Service.Implementation.AboutServices.Dtos;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface IAboutService
    {
        Task<AboutDto> GetAboutUs();
        Task<string> AboutUs(string key);
        Task EditAboutUs(AboutDto about);
    }
}
