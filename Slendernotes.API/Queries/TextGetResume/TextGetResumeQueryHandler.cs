using AutoMapper;
using MediatR;
using Slendernotes.API.DTO.Response;
using Slendernotes.API.Models;
using Slendernotes.API.Repository.Interfaces;
using Slendernotes.API.Results;

namespace Slendernotes.API.Queries.TextGetResume
{
    public class TextGetResumeQueryHandler : IRequestHandler<TextGetResumeQuery, ResultRepository<TextResume>>
    {
        private readonly ITextRepository _textRepository;
        private readonly IMapper _mapper;

        public TextGetResumeQueryHandler(ITextRepository textRepository, IMapper mapper)
        {
            _textRepository = textRepository;
            _mapper = mapper;
        }

        public async Task<ResultRepository<TextResume>> Handle(TextGetResumeQuery request, CancellationToken cancellationToken)
        {
            ResultRepository<Text> result = await _textRepository.GetById(request.Id);

            if (!result.IsSuccess)
            {
                return ResultRepository.NotFound<TextResume>();
            }

            TextResume textResume = _mapper.Map<TextResume>(result.Data);

            return ResultRepository.Ok(textResume);
        }
    }
}
