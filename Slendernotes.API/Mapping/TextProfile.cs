using AutoMapper;
using Slendernotes.API.DTO.Response;
using Slendernotes.Domain.Entities;

namespace Slendernotes.API.Mapping
{
    public class TextProfile : Profile
    {
        public TextProfile() 
        {
            CreateMap<Text, TextDetails>()
                .ForMember(dest => dest.TextBody, opt => opt.MapFrom(src => src.TextContent != null ? src.TextContent.Value : null));

            CreateMap<Text, TextResume>()
                .ForMember(dest => dest.TextBody, opt => opt.MapFrom(src => src.TextContent.Value));
        }

    }
}
