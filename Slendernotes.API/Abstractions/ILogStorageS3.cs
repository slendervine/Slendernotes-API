using Slendernotes.Domain.Abstractions;

namespace Slendernotes.API.Abstractions
{
    public interface ILogStorageS3
    {
        Task SaveEventLogAsync(IDomainEvent domainEvent, string additionalMessage); 
    }
}
