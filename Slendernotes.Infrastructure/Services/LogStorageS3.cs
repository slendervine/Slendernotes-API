using Slendernotes.Domain.Abstractions;
using Slendernotes.Domain.Abstractions.Services;

namespace Slendernotes.Infrastructure.Services
{
    public class LogStorageS3 : ILogStorageS3
    {
        public async Task SaveEventLogAsync(IDomainEvent domainEvent, string additionalMessage)
        {
            await Task.Run(() => Console.WriteLine($"Domain Event: {domainEvent.GetType().FullName}, Ocorreu em: {domainEvent.OccurredOn}"));
        }
    }
}
