namespace Notification.API.Interfaces.Twilio
{
    public interface ITwilioSender
    {
        Task SendSmsAsync(string to, string message);
    }
}
