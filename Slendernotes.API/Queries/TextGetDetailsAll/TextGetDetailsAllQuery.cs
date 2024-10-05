using MediatR;
using Slendernotes.API.DTO.Response;
using Slendernotes.API.Results;

namespace Slendernotes.API.Queries.TextGetDetailsAll
{
    public class TextGetDetailsAllQuery : IRequest<ResultRepository<List<TextDetails>>>
    {
        public TextGetDetailsAllQuery()
        {
        }
    }
}
