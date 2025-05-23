namespace Notification.API.Interfaces
{
    public interface ISendGridClient
    {
        Task<bool> SendEmail(string to, string subject, string messageHtml);
    }
}
