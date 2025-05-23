using Notification.API.Models;

namespace Notification.API.Interfaces
{
    public interface ISmsSender
    {
        Task<bool> SendNotification(SendNotificationRequest request);
    }
}
