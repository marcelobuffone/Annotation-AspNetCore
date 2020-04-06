using MBAM.Annotations.Domain.Core.Events;
using System;

namespace MBAM.Annotations.Domain.Core.Commands
{
    public class Command : Message
    {
        public DateTime TimeStamp { get; private set; }

        public Command()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
