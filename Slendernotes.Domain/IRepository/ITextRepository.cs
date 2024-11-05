using Slendernotes.Domain.Common;

namespace Slendernotes.Domain.IRepository
{
    public interface ITextRepository
    {
        Task<ResultRepository<Text.Text>> GetById(Guid id);
        Task<ResultRepository<List<Text.Text>>> GetAll();
        Task<ResultRepository> Create(Text.Text text);
        Task<ResultRepository> Delete(Guid id);
    }
}
