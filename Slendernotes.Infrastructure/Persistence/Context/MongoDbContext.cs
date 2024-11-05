using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Slendernotes.Domain.Abstractions;
using Slendernotes.Domain.Text;
using Slendernotes.Infrastructure.Persistence.Mapping;

namespace Slendernotes.Infrastructure.Persistence.Context
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoDatabase database)
        {
            _database = database;

            BsonClassMap.RegisterClassMap<Entity>(classMap =>
            {
                classMap.AutoMap();

                classMap.MapIdMember(x => x.Id)
                 .SetSerializer(new GuidSerializer(GuidRepresentation.Standard)); 

                classMap.SetIsRootClass(true);
            });

            BsonClassMap.RegisterClassMap<TextContent>(cm =>
            {
                cm.AutoMap();
                cm.MapMember(x => x.Value); 
                cm.MapMember(x => x.WordCount);
                cm.MapMember(x => x.ContainsInappropriateContent);

                cm.MapCreator(x => TextContent.Create(x.Value));
            });

            // Registra os mapeamentos usando uma ação para configurar o BsonClassMap
            BsonClassMap.RegisterClassMap<Text>(cm =>
            {
                cm.AutoMap();
                cm.MapProperty(x => x.TextContent);
                cm.MapMember(x => x.TextContent);
                cm.MapMember(x => x.Title);
                cm.MapMember(x => x.Category);
                cm.MapMember(x => x.CreateDate);
                cm.MapMember(x => x.UserId);
                
            });
        }

        public IMongoCollection<Text> Texts => _database.GetCollection<Text>("Text");
    }
}
