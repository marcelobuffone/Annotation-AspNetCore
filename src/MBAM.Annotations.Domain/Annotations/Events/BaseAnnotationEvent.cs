using MBAM.Annotations.Domain.Core.Events;
using System;

namespace MBAM.Annotations.Domain.Annotations.Events
{
    public abstract class BaseAnnotationEvent : Event
    {
        public Guid Id { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
    }
}
