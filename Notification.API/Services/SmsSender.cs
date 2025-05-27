using Notification.API.Interfaces;
using Notification.API.Interfaces.Twilio;
using Notification.API.Models;
using System.Runtime.CompilerServices;

namespace Notification.API.Services
{
    public class SmsSender : ISmsSender
    {

        private readonly ITwilioSender _sender;

        public SmsSender(ITwilioSender sender)
        {
            this._sender = sender;
        }
        public async Task<bool> SendNotification(SendNotificationRequest request)
        {
            await this._sender.SendSmsAsync(request.To, request.Message);

            return true;
        }
    }
}
