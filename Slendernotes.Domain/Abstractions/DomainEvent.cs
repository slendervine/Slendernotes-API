using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slendernotes.Domain.Abstractions
{
    public abstract record DomainEvent : IDomainEvent
    {
        public DateTime OccurredOn { get; }
        public int UserId { get; }

        protected DomainEvent(int userId)
        {
            OccurredOn = DateTime.UtcNow;
            UserId = userId;
        }
    }
}
