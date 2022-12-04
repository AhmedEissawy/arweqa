using AutoMapper;
using OA.Data.Domain;
using OA.Repo.Errors;
using OA.Repo.Interfaces;
using OA.Service.Implementation.AboutServices.Dtos;
using OA.Service.Interfaces;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OA.Service.Implementation.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMapper _Mapper;
        private readonly IAboutRepository _aboutRepository;
        public AboutService(IAboutRepository aboutRepository, IMapper mapper)
        {
            _Mapper = mapper;
            _aboutRepository = aboutRepository;
        }


        public async Task<AboutDto> GetAboutUs()
        {
            About about = (await _aboutRepository.FindAsync(q => !q.Deleted)).FirstOrDefault();

            if (about == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" No About Us found ...!" });

            return _Mapper.Map<AboutDto>(about);

        }


        public async Task<string> AboutUs(string key)
        {
            About about = (await _aboutRepository.FindAsync(q => !q.Deleted)).FirstOrDefault();

            if (about == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" No About Us found ...!" });

            var x = about.GetType().GetProperty(key).GetValue(about);

            return x.ToString();

        }

        public async Task EditAboutUs(AboutDto aboutUs)
        {
            About about = (await _aboutRepository.FindAsync(q => !q.Deleted)).FirstOrDefault();

            if (about == null) throw new RestException(HttpStatusCode.BadRequest, new { message = $" No About Us found ...!" });

            about.AboutUs = aboutUs.AboutUs;
            about.Provide = aboutUs.Provide;
            about.Terms = aboutUs.Terms;
            about.Egabat = aboutUs.Egabat;
            about.Contact = aboutUs.Contact;

            await _aboutRepository.SaveChangesAsync();

        }
    }
}
