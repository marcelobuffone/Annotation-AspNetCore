using System;

namespace MBAM.Annotations.Domain.Annotations.Events
{
    public class AnnotationRegistredEvent : BaseAnnotationEvent
    {
        public AnnotationRegistredEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
