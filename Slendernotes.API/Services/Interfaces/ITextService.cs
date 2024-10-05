using Slendernotes.API.DTO.Response;
using Slendernotes.API.Results;

namespace Slendernotes.API.Services.Interfaces
{
    public interface ITextService
    {
        public Task<ResultService<TextResume>> GetResumeByIdAsync(Guid id);
        public Task<ResultService<TextDetails>> GetDetailsByIdAsync(Guid id);
        public Task<ResultService<List<TextResume>>> GetAllResumeAsync();
        public Task<ResultService<List<TextDetails>>> GetAllDetailsAsync();
        public Task<ResultService<TextDetails>> CreateAsync();
        public Task<ResultService> DeleteAsync();

    }
}
