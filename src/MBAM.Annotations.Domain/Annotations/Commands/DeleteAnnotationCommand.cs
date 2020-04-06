using System;

namespace MBAM.Annotations.Domain.Annotations.Commands
{
    public class DeleteAnnotationCommand : BaseAnnotationCommand
    {
        public DeleteAnnotationCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;  
        }
    }
}
