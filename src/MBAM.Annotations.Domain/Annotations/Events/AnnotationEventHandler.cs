using MBAM.Annotations.Domain.Core.Events;

namespace MBAM.Annotations.Domain.Annotations.Events
{
    public class AnnotationEventHandler :
                IHandler<AnnotationRegistredEvent>,
                IHandler<AnnotationUpdatedEvent>,
                IHandler<AnnotationDeletedEvent>
    {
        public void Handle(AnnotationRegistredEvent message)
        {

        }

        public void Handle(AnnotationUpdatedEvent message)
        {

        }

        public void Handle(AnnotationDeletedEvent message)
        {

        }
    }
}
