using Slendernotes.Domain.Entities;
using Slendernotes.Domain.Common;

namespace Slendernotes.Domain.IRepository
{
    public interface ITextRepository
    {
        Task<ResultRepository<Text>> GetById(Guid id);
        Task<ResultRepository<List<Text>>> GetAll();
        Task<ResultRepository> Create(Text text);
        Task<ResultRepository> Delete(Guid id);
    }
}
