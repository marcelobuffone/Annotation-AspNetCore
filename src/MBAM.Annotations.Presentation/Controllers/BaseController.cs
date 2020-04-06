using MBAM.Annotations.Domain.Core.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace MBAM.Annotations.Presentation.Controllers
{
    public class BaseController : Controller
    {
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        public BaseController(IDomainNotificationHandler<DomainNotification> notifications)
        {
            _notifications = notifications;
        }

        protected bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }
    }
}
