namespace Notification.API.Interfaces.SendGrid
{
    public interface ISendGridClient
    {
        Task<bool> SendEmail(string to, string subject, string messageHtml);
    }
}
