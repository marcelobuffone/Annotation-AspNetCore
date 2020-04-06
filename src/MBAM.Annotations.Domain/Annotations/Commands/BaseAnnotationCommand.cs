using MBAM.Annotations.Domain.Core.Commands;
using System;

namespace MBAM.Annotations.Domain.Annotations.Commands
{
    public abstract class BaseAnnotationCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
    }
}
