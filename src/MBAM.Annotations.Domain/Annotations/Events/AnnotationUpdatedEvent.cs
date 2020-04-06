using System;

namespace MBAM.Annotations.Domain.Annotations.Events
{
    public  class AnnotationUpdatedEvent : BaseAnnotationEvent
    {
        public AnnotationUpdatedEvent(string title,
                                      string description,
                                      Guid id)
        {
            Id = id;
            Title = title;
            Description = description;

            AggregateId = id;
        }
    }
}
