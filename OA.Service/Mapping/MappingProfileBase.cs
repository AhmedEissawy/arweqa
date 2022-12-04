using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Service.Mapping
{
    public class MappingProfileBase : Profile
    {
        public MappingProfileBase()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
            ReplaceMemberName("_", "");
        }
    }
}
