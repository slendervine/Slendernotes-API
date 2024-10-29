using MediatR;
using Slendernotes.Domain.Common;

namespace Slendernotes.API.Commands.TextDelete
{
    public class TextDeleteCommand : IRequest<ResultRepository>
    {
        public Guid Id { get; set; }

        public TextDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}
