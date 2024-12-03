using Slendernotes.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slendernotes.Domain.Text.Events
{
    public sealed record TextCreatedDomainEvent : DomainEvent
    {
        public Guid TextId { get; }

        public TextCreatedDomainEvent(Guid textId, int userId) : base(userId)
        {
            TextId = textId;
        }
    }
}
