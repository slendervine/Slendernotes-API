using MongoDB.Bson.Serialization.Attributes;
using Slendernotes.Domain.Entities;

namespace Slendernotes.Domain.Abstractions
{
    [BsonKnownTypes(typeof(Text))]
    public abstract class Entity
    {
        protected Entity(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; init; }
    }
}
