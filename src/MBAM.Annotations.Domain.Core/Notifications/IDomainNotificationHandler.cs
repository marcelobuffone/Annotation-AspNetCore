using MBAM.Annotations.Domain.Core.Events;
using System.Collections.Generic;

namespace MBAM.Annotations.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();
        List<T> GetNotifications();
    }
}
