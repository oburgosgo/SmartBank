using Notification.API.Interfaces;
using SendGrid.Helpers.Mail;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Notification.API.Services
{
    public class SendGridClient : ISendGridClient
    {
        private readonly HttpClient _httpClient;
        private string _apiKey;
        private string _fromEmail;
        public SendGridClient(HttpClient httpClient, IConfiguration configuration) { 
            _httpClient = httpClient;
            _apiKey = configuration["SendGrid:ApiKey"];
            _fromEmail = configuration["SendGrid:FromEmail"];
        }
        public async Task<bool> SendEmail(string to, string subject, string messageHtml)
        {
            var request = new
            {
                personalizations = new[]
                {
                    new {
                        to = new[] { new { email = to } }
                    }
                },
                from = new { email = _fromEmail },
                subject = subject,
                content = new[]
                {
                    new { type = "text/html", value = messageHtml }
                }
            };

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "mail/send");
            httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            httpRequest.Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(httpRequest);
            response.EnsureSuccessStatusCode();

            return true;
        }
    }
}
