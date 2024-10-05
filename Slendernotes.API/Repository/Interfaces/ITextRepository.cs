using Slendernotes.API.DTO.Response;
using Slendernotes.API.Models;
using Slendernotes.API.Results;

namespace Slendernotes.API.Repository.Interfaces
{
    public interface ITextRepository
    {
        Task<ResultRepository<Text>> GetById(Guid id);
        Task<ResultRepository<List<Text>>> GetAll();
    }
}
