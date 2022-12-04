using OA.Service.Implementation.SocialLinkServices.Dtos;
using System.Threading.Tasks;

namespace OA.Service.Interfaces
{
    public interface ISocialLinkService
    {
        Task<SocialLinkDto> GetSocialLinks();
        Task EditSocialLinks(SocialLinkDto socialLinks);
    }
}
