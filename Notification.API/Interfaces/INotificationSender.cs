using Notification.API.Models;

namespace Notification.API.Interfaces
{
    public interface INotificationSender
    {
        Task<bool> SendNotification(SendNotificationRequest request);
    }
}
