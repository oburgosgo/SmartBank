using Notification.API.Models;

namespace Notification.API.Interfaces
{
    public interface IEmailSender
    {
        Task<bool> SendNotification(SendNotificationRequest request);
    }
}
