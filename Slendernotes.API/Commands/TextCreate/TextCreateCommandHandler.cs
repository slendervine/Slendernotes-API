using AutoMapper;
using MediatR;
using Slendernotes.Domain.Entities;
using Slendernotes.Domain.IRepository;
using Slendernotes.Domain.Common;

namespace Slendernotes.API.Commands.TextCreate
{
    public class TextCreateCommandHandler : IRequestHandler<TextCreateCommand, ResultRepository<Guid>>
    {
        private readonly ITextRepository _textRepository;
        private readonly IMapper _mapper;

        public TextCreateCommandHandler(IMapper mapper, ITextRepository textRepository)
        {
            _mapper = mapper;
            _textRepository = textRepository;
        }

        public async Task<ResultRepository<Guid>> Handle(TextCreateCommand request, CancellationToken cancellationToken)
        {

            // Gera um novo ID para a entidade
            var textId = Guid.NewGuid();

            // Instancia a entidade Text com os parâmetros do request
            var text = new Text(
                id: textId,
                textBody: request.TextBody,
                title: request.Title,
                category: request.Category,
                userId: request.UserId
            );

            ResultRepository result = await _textRepository.Create(text);

            if (!result.IsSuccess)
            {
                return ResultRepository.InsertFailure<Guid>();
            }

            return ResultRepository.Ok(text.Id);
        }

    }
}
