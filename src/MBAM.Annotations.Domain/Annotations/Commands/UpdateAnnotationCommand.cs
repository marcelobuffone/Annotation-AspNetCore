using System;

namespace MBAM.Annotations.Domain.Annotations.Commands
{
    public class UpdateAnnotationCommand : BaseAnnotationCommand 
    {
        public UpdateAnnotationCommand(string title,
                                       string description,
                                       Guid id)
        {
            //Id = id;
            Title = title;
            Description = description;
            AggregateId = id;
        }
    }
}
