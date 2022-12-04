using OA.Data.Domain;
using OA.Service.Implementation.AboutServices.Dtos;

namespace OA.Service.Mapping
{
    public class AboutProfile : MappingProfileBase
    {

        public AboutProfile()
        {
            CreateMap<About, AboutDto>().ReverseMap();
        }
    }
}
