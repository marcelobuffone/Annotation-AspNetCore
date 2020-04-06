using MBAM.Annotations.Domain.Core.Commands;
using MBAM.Annotations.Domain.Core.Events;

namespace MBAM.Annotations.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;
        void RaiseEvent<T>(T theEvent) where T : Event ;
    }
}
