using Notification.API.Interfaces;
using Notification.API.Models;
using Notification.API.Models.Enums;
using System.Runtime.CompilerServices;

namespace Notification.API.Services
{
    public class NotificationSender : INotificationSender
    {

        private readonly ISmsSender _smsSender;
        private readonly IEmailSender _emailSender;
        public NotificationSender(ISmsSender smsSender, IEmailSender emailSender) { 
            this._smsSender = smsSender;
            this._emailSender = emailSender;
        }
        public async Task<bool> SendNotification(SendNotificationRequest request)
        {
            switch (request.Type)
            {
                case NotificationType.Email:
                    return await _emailSender.SendNotification(request);
                case NotificationType.Sms:
                    return await _smsSender.SendNotification(request);
                default:
                    return false;
            }
        }
    }
}
