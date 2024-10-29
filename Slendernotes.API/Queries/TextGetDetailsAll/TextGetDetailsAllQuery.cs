using MediatR;
using Slendernotes.API.DTO.Response;
using Slendernotes.Domain.Common;

namespace Slendernotes.API.Queries.TextGetDetailsAll
{
    public class TextGetDetailsAllQuery : IRequest<ResultRepository<List<TextDetails>>>
    {
        public TextGetDetailsAllQuery()
        {
        }
    }
}
