
using Notification.API.Interfaces;
using Notification.API.Models;
using SendGrid.Helpers.Mail;
using SendGrid;
using static System.Net.WebRequestMethods;

namespace Notification.API.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly string _apiKey;

        public EmailSender(string apiKey)
        {
            _apiKey = apiKey;
        }

        public Task<bool> SendNotification(SendNotificationRequest request)
        {
            /*
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("no-reply@smartbank.com", "SmartBank");
            var subject = "Your OTP Code";
            var to = new EmailAddress(request.Sender);
            var plainTextContent = $"Your OTP code is: {request.Message}";
            var htmlContent = $"<strong>Your OTP code is: {request.Message}</strong>";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);*/

            return Task.FromResult(true);
        }
    }
}
