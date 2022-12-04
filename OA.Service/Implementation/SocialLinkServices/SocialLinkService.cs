using OA.Data.Domain;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.LibraryServices.Dtos;
using OA.Service.Implementation.SocialLinkServices.Dtos;
using OA.Service.Interfaces;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Service.Implementation.SocialLinkServices
{
    public class SocialLinkService : ISocialLinkService
    {
        private readonly ISocialLinkRepo _socialLinkRepo;
        public SocialLinkService(ISocialLinkRepo socialLinkRepo)
        {
            _socialLinkRepo = socialLinkRepo;
        }


        public async Task<SocialLinkDto> GetSocialLinks()
        {
            SocialLink socialLinks = (await _socialLinkRepo.FindAsync(q => !q.Deleted)).FirstOrDefault();

            if (socialLinks == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" No Social Links found ...!" });

            SocialLinkDto socialLink = new SocialLinkDto()
            {
                Facebook = socialLinks.Facebook,
                Twitter = socialLinks.Twitter,
                Youtube = socialLinks.Youtube,
                Instagram = socialLinks.Instagram,
                Linkedin = socialLinks.Linkedin,
                WhatsApp = socialLinks.WhatsApp
            };

            return socialLink;
        }


        public async Task EditSocialLinks(SocialLinkDto socialLinks)
        {
            SocialLink dbSocialLinks = (await _socialLinkRepo.FindAsync(q => !q.Deleted)).FirstOrDefault();

            if (socialLinks == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" No Social Links found ...!" });

            dbSocialLinks.Facebook = socialLinks.Facebook;
            dbSocialLinks.Twitter = socialLinks.Twitter;
            dbSocialLinks.Youtube = socialLinks.Youtube;
            dbSocialLinks.Instagram = socialLinks.Instagram;
            dbSocialLinks.Linkedin = socialLinks.Linkedin;
            dbSocialLinks.WhatsApp = socialLinks.WhatsApp;

            await _socialLinkRepo.SaveChangesAsync();

        }

    }
}
