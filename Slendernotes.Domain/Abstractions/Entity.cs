using MongoDB.Bson.Serialization.Attributes;

namespace Slendernotes.Domain.Abstractions
{
    [BsonKnownTypes(typeof(Text.Text))]
    public abstract class Entity
    {
        public Guid Id { get; init; }
        private List<IDomainEvent> _domainEvents = new();

        protected Entity(Guid id)
        {
            Id = id;
        }
       
        public IReadOnlyList<IDomainEvent> GetDomainEvents()
        {
            return _domainEvents.ToList();
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        protected void RaiseDomainEvents(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

    }
}
