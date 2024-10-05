using AutoMapper;
using MediatR;
using Slendernotes.API.DTO.Response;
using Slendernotes.API.Models;
using Slendernotes.API.Repository.Interfaces;
using Slendernotes.API.Results;

namespace Slendernotes.API.Queries.TextGetDetailsAll
{
    public class TextGetDetailsAllQueryHandler : IRequestHandler<TextGetDetailsAllQuery, ResultRepository<List<TextDetails>>>
    {
        private readonly ITextRepository _textRepository;
        private readonly IMapper _mapper;

        public TextGetDetailsAllQueryHandler(ITextRepository textRepository, IMapper mapper)
        {
            _textRepository = textRepository;
            _mapper = mapper;
        }

        public async Task<ResultRepository<List<TextDetails>>> Handle(TextGetDetailsAllQuery request, CancellationToken cancellationToken)
        {
            ResultRepository<List<Text>> result = await _textRepository.GetAll();

            if (!result.IsSuccess)
            {
                return ResultRepository.NotFound<List<TextDetails>>();
            }

            List<TextDetails> textDetailsList = _mapper.Map<List<TextDetails>>(result.Data);

            return ResultRepository.Ok(textDetailsList);
        }
    }
}
