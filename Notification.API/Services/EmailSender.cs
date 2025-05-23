
using Notification.API.Interfaces;
using Notification.API.Models;

namespace Notification.API.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly ISendGridClient _client;
        public EmailSender(ISendGridClient client)
        {
            this._client = client;
        }

        public async Task<bool> SendNotification(SendNotificationRequest request)
        {
            return await this._client.SendEmail(request.To,request.Subject,request.Message);
        }
    }
}
