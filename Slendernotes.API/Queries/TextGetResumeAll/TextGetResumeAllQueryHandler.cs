using AutoMapper;
using MediatR;
using Slendernotes.API.DTO.Response;
using Slendernotes.Domain.Entities;
using Slendernotes.Domain.Common;
using Slendernotes.Domain.IRepository;

namespace Slendernotes.API.Queries.TextGetResumeAll
{
    public class TextGetResumeAllQueryHandler : IRequestHandler<TextGetResumeAllQuery, ResultRepository<List<TextResume>>>
    {
        private readonly ITextRepository _textRepository;
        private readonly IMapper _mapper;

        public TextGetResumeAllQueryHandler(ITextRepository textRepository, IMapper mapper)
        {
            _textRepository = textRepository;
            _mapper = mapper;
        }

        public async Task<ResultRepository<List<TextResume>>> Handle(TextGetResumeAllQuery request, CancellationToken cancellationToken)
        {
            ResultRepository<List<Text>> result = await _textRepository.GetAll();

            if (!result.IsSuccess)
            {
                return ResultRepository.NotFound<List<TextResume>>();
            }

            List<TextResume> textDetailsList = _mapper.Map<List<TextResume>>(result.Data);

            return ResultRepository.Ok(textDetailsList);
        }
    }
}
