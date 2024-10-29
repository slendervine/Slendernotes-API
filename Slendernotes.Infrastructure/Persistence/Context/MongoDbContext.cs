using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Slendernotes.Domain.Entities;
using Slendernotes.Infrastructure.Persistence.Mapping;

namespace Slendernotes.Infrastructure.Persistence.Context
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoDatabase database)
        {
            _database = database;

            // Registra os mapeamentos usando uma ação para configurar o BsonClassMap
            BsonClassMap.RegisterClassMap<Text>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
                cm.MapIdMember(x => x.Id);
                cm.MapMember(x => x.TextContent).SetIsRequired(true);
                cm.MapMember(x => x.Title).SetIsRequired(true);
                cm.MapMember(x => x.Category);
                cm.MapMember(x => x.CreateDate);
                cm.MapMember(x => x.UserId);
            });
        }

        public IMongoCollection<Text> Texts => _database.GetCollection<Text>("texts");
    }
}
