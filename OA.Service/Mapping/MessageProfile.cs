using OA.Data.Domain;
using OA.Repo.Dtos;
using OA.Service.Implementation.Infrastructure.Dtos;
using OA.Service.Implementation.MessageServices.Dtos;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace OA.Service.Mapping
{
    public class MessageProfile : MappingProfileBase
    {

        public MessageProfile()
        {


            CreateMap<RecentChatFilterDto, RecentChatFilterModel>().ReverseMap();   
            

            CreateMap<Message, CreateMessageDto>()
                .ForMember(dest => dest.Message, opts => opts.MapFrom(src => src.Description)).ReverseMap();

            CreateMap<Message, AdminReplayDto>()
               .ForMember(dest => dest.Message, opts => opts.MapFrom(src => src.Description)).ReverseMap();


            CreateMap<Notification, NotificationDto>()
                 .ForMember(dest => dest.Date, opts => opts.MapFrom(src => src.Date.ToString("MM/dd/yyyy h:mm tt"))).ReverseMap();


            CreateMap<Message, RecentChatsDto>()
                .ForMember(dest => dest.Date, opts => opts.MapFrom(src => src.Date.ToString("MM/dd/yyyy h:mm tt"))).ReverseMap();


            CreateMap<Message, MobileMessageResponseDto>()
               .ForMember(dest => dest.Message, opts => opts.MapFrom(src => src.Description))
               .ForMember(dest => dest.Date, opts => opts.MapFrom(src => src.Date.ToString("MM/dd/yyyy h:mm tt"))).ReverseMap();
            

            CreateMap<Message, AdminMessageResponseDto>()
                .ForMember(dest => dest.Message, opts => opts.MapFrom(src => src.Description))
                .ForMember(dest => dest.Date, opts => opts.MapFrom(src => src.Date.ToString("MM/dd/yyyy h:mm tt"))).ReverseMap();


        }
    }
}
