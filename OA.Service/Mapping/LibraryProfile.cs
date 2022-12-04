using OA.Data.Domain;
using OA.Service.Implementation.LibraryServices.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Mapping
{
    public class LibraryProfile : MappingProfileBase
    {
        public LibraryProfile()
        {

            CreateMap<Library, LibraryResponseDto>()
                .ForMember(dest => dest.LibraryId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.GradeName, opts => opts.MapFrom(src => src.Grade.GradeName))
                .ForMember(dest => dest.SemesterName, opts => opts.MapFrom(src => src.Semester.SemesterName))
                .ReverseMap();

            

            CreateMap<Library, MobileLibraryResponseDto>()
                .ForMember(dest => dest.SemesterName, opts => opts.MapFrom(src => src.Semester.SemesterName)).ReverseMap();

        }
    }
}