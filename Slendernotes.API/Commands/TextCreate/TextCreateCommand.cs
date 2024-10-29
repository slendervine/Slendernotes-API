using MediatR;
using Slendernotes.API.DTO.Request;
using Slendernotes.Domain.Enums;
using Slendernotes.Domain.Common;

namespace Slendernotes.API.Commands.TextCreate
{
    public class TextCreateCommand : IRequest<ResultRepository<Guid>>
    {
        public string TextBody { get; set; }
        public string Title { get; set; }
        public TextCategory Category { get; set; }
        public int UserId { get; set; }

        public TextCreateCommand(TextCreateDTO dataDTO)
        {
            TextBody = dataDTO.TextBody;
            Title = dataDTO.Title;
            Category = dataDTO.Category;
            UserId = dataDTO.UserId;
        }
    }
}
