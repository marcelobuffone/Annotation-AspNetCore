using MBAM.Annotations.Domain.Annotations.Events;
using MBAM.Annotations.Domain.Annotations.Repository;
using MBAM.Annotations.Domain.CommandHandlers;
using MBAM.Annotations.Domain.Core.Bus;
using MBAM.Annotations.Domain.Core.Events;
using MBAM.Annotations.Domain.Core.Notifications;
using MBAM.Annotations.Domain.Interfaces;
using System;
using System.Linq;

namespace MBAM.Annotations.Domain.Annotations.Commands
{
    public class AnnotationCommandHandler : CommandHandler,
        IHandler<RegisterAnnotationCommand>,
        IHandler<UpdateAnnotationCommand>,
        IHandler<DeleteAnnotationCommand>
    {
        private readonly IAnnotationRepository _annotationRepository;
        private readonly IBus _bus;

        public AnnotationCommandHandler(IAnnotationRepository annotationRepository,
                                        IUnitOfWork uow,
                                        IBus bus,
                                        IDomainNotificationHandler<DomainNotification> notifications)
              : base(uow, bus, notifications)
        {
            _annotationRepository = annotationRepository;
            _bus = bus;
        }

        public void Handle(RegisterAnnotationCommand message)
        {
            var annotation = new Annotation(message.Title, message.Description);

            if (!AnnotationValid(annotation.AnnotationHistory.FirstOrDefault())) return;

            _annotationRepository.Add(annotation);

            if (Commit())
            {
                _bus.RaiseEvent(new AnnotationRegistredEvent(annotation.Id));
            }
        }

        public void Handle(UpdateAnnotationCommand message)
        {
            if (!AnnotationExisting(message.AggregateId, message.MessageType)) return;

            var history = new AnnotationHistory(message.Title, message.Description, message.AggregateId);

            if (!AnnotationValid(history)) return;
            
            _annotationRepository.AddHistory(history);

            if (Commit())
            {
                _bus.RaiseEvent(new AnnotationUpdatedEvent(message.Title, message.Description, message.AggregateId));
            }
        }

        public void Handle(DeleteAnnotationCommand message)
        {
            if (!AnnotationExisting(message.AggregateId, message.MessageType)) return;

            _annotationRepository.Remove(message.Id);

            if (Commit())
            {
                _bus.RaiseEvent(new AnnotationDeletedEvent(message.AggregateId));
            }
        }

        private bool AnnotationValid(AnnotationHistory annotation)
        {
            if (annotation.IsValid()) return true;

            NotificationValidationsError(annotation.ValidationResult);
            return false;
        }

        private bool AnnotationExisting(Guid id, string messageType)
        {
            var annotation = _annotationRepository.GetById(id);

            if (annotation != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, "Annotation not found"));
            return false;
        }

    }
}
