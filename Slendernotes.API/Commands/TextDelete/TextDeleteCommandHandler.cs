using AutoMapper;
using MediatR;
using Slendernotes.Domain.IRepository;
using Slendernotes.Domain.Common;

namespace Slendernotes.API.Commands.TextDelete
{
    public class TextDeleteCommandHandler : IRequestHandler<TextDeleteCommand, ResultRepository>
    {
        private readonly ITextRepository _textRepository;
        private readonly IMapper _mapper;

        public TextDeleteCommandHandler(IMapper mapper, ITextRepository textRepository)
        {
            _mapper = mapper;
            _textRepository = textRepository;
        }

        public async Task<ResultRepository> Handle(TextDeleteCommand request, CancellationToken cancellationToken)
        {

            ResultRepository result = await _textRepository.Delete(request.Id);

            if (!result.IsSuccess)
            {
                return ResultRepository.DeleteFailure();
            }

            return ResultRepository.OperationCompleted();
        }

    }
}
