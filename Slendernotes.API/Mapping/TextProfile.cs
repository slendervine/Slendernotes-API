using AutoMapper;
using Slendernotes.API.DTO.Response;
using Slendernotes.Domain.Entities;

namespace Slendernotes.API.Mapping
{
    public class TextProfile : Profile
    {
        public TextProfile() 
        {
            CreateMap<Text, TextDetails>();
            CreateMap<Text, TextResume>();
        }

    }
}
