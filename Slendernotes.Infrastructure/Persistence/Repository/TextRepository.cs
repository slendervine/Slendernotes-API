using MongoDB.Driver;
using Slendernotes.Domain.Common;
using Slendernotes.Domain.IRepository;
using Slendernotes.Infrastructure.Persistence.Context;
using Slendernotes.Domain.Text;

namespace Slendernotes.API.Repository
{
    public class TextRepository : ITextRepository
    {
        private IMongoCollection<Text> _texts;
        public TextRepository(MongoDbContext context)
        {
            _texts = context.Texts; //nome da collection de dentro do mongo
        }

        public async Task<ResultRepository<Text>> GetById(Guid id)
        {
            Text? text = await _texts.Find(t => t.Id == id)
                                       .FirstOrDefaultAsync();

            if (text == null)
            {
                return ResultRepository.NotFound<Text>();
            }

            return ResultRepository.Ok(text);
        }

        public async Task<ResultRepository<List<Text>>> GetAll()
        {
            List<Text>? textList = await _texts.Find(_ => true).ToListAsync();

            if (textList == null)
            {
                return ResultRepository.NotFound<List<Text>>();
            }

            return ResultRepository.Ok(textList);
        }

        public async Task<ResultRepository> Create(Text text)
        {
            await _texts.InsertOneAsync(text);
            return ResultRepository.OperationCompleted();
        }

        public async Task<ResultRepository> Delete(Guid id)
        {
            FilterDefinition<Text> filter = Builders<Text>.Filter.Eq(x => x.Id, id);
            DeleteResult deleteResult = await _texts.DeleteOneAsync(filter);

            if (deleteResult.DeletedCount > 0)
                return ResultRepository.OperationCompleted(true);

            return ResultRepository.DeleteFailure();
        }
    }
}
