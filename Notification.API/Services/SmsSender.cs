using Notification.API.Interfaces;
using Notification.API.Models;
using System.Runtime.CompilerServices;

namespace Notification.API.Services
{
    public class SmsSender : ISmsSender
    {
        
        public SmsSender() { }
        public Task<bool> SendNotification(SendNotificationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
