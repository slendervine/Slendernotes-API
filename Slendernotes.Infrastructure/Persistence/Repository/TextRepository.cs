using MongoDB.Driver;
using Slendernotes.Domain.Common;
using Slendernotes.Domain.IRepository;
using Slendernotes.Infrastructure.Persistence.Context;
using Slendernotes.Domain.Text;
using Slendernotes.Domain.Abstractions;
using MediatR;

namespace Slendernotes.Infrastructure.Repository
{
    public class TextRepository : ITextRepository
    {
        private readonly IMongoCollection<Text> _texts;
        private readonly IMediator _mediator;
        public TextRepository(MongoDbContext context, IMediator mediator)
        {
            _texts = context.Texts; //nome da collection de dentro do mongo
            _mediator = mediator;
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

            // Publica todos os eventos da entidade
            IReadOnlyList<IDomainEvent> listDomainEvents = text.GetDomainEvents();
            List<Task> publishTasks = listDomainEvents
                .Select(evento => _mediator.Publish(evento))
                .ToList();

            await Task.WhenAll(publishTasks);


            // Limpa os eventos após publicá-los
            text.ClearDomainEvents();

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
