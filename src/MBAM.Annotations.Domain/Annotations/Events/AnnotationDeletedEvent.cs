using System;

namespace MBAM.Annotations.Domain.Annotations.Events
{
    public class AnnotationDeletedEvent : BaseAnnotationEvent
    {
        public AnnotationDeletedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
