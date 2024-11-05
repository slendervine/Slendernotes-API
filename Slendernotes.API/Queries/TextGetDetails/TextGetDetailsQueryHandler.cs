using AutoMapper;
using MediatR;
using Slendernotes.API.DTO.Response;
using Slendernotes.Domain.IRepository;
using Slendernotes.Domain.Common;
using Slendernotes.Domain.Text;

namespace Slendernotes.API.Queries.TextGetDetails
{
    public class TextGetResumeQueryHandler : IRequestHandler<TextGetDetailsQuery, ResultRepository<TextDetails>>
    {
        private readonly ITextRepository _textRepository;
        private readonly IMapper _mapper;

        public TextGetResumeQueryHandler(ITextRepository textRepository, IMapper mapper)
        {
            _textRepository = textRepository;
            _mapper = mapper;
        }

        public async Task<ResultRepository<TextDetails>> Handle(TextGetDetailsQuery request, CancellationToken cancellationToken)
        {
            ResultRepository<Text> result = await _textRepository.GetById(request.Id);

            if(!result.IsSuccess)
            {
                return ResultRepository.NotFound<TextDetails>();
            }

            TextDetails textDetails = _mapper.Map<TextDetails>(result.Data);

            return ResultRepository.Ok(textDetails);
        }
    }
}
