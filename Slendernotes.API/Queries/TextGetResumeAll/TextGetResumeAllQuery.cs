using MediatR;
using Slendernotes.API.DTO.Response;
using Slendernotes.API.Results;

namespace Slendernotes.API.Queries.TextGetResumeAll
{
    public class TextGetResumeAllQuery : IRequest<ResultRepository<List<TextResume>>>
    {
        public TextGetResumeAllQuery()
        {
        }
    }
}
