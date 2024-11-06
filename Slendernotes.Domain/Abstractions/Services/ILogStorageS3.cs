using Slendernotes.Domain.Abstractions;

namespace Slendernotes.Domain.Abstractions.Services
{
    public interface ILogStorageS3
    {
        Task SaveEventLogAsync(IDomainEvent domainEvent, string additionalMessage); 
    }
}
