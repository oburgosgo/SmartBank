using Notification.API.Interfaces;
using Notification.API.Models;

namespace Notification.API.Services
{
    public class SmsSender : ISmsSender
    {
        public Task<bool> SendNotification(SendNotificationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
