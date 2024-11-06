using MediatR;
using Slendernotes.Domain.Abstractions.Services;
using Slendernotes.Domain.IRepository;
using Slendernotes.Domain.Text.Events;

namespace Slendernotes.API.Commands.TextCreate
{
    internal sealed class TextCreateDomainEventHandler : INotificationHandler<TextCreatedDomainEvent>
    {
        private readonly ILogStorageS3 _logStorageS3;
        public TextCreateDomainEventHandler(ILogStorageS3 logStorageS3)
        {
            _logStorageS3 = logStorageS3;
        }
        public async Task Handle(TextCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            string message = $"Objeto Text: {notification.TextId} criado com sucesso em: {notification.OccurredOn}, pelo usuario: {notification.UserId}!";
            await _logStorageS3.SaveEventLogAsync(notification, message);
        }
    }
    
}
