using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slendernotes.Domain.Abstractions
{
    public interface IDomainEvent : INotification
    {
        DateTime OccurredOn { get; }
        int UserId { get; }
    }
}
