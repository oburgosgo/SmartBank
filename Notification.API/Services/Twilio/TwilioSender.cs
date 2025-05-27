using Notification.API.Interfaces.Twilio;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Notification.API.Services.Twilio
{
    public class TwilioSender : ITwilioSender
    {
        private readonly string _authToken;
        private readonly string _accountSid;
        private readonly string _fromPhone;
        public TwilioSender(IConfiguration config) {
            _authToken = config["Twilio:AuthToken"];
            _accountSid = config["Twilio:SID"];
            _fromPhone = config["Twilio:From"];

            TwilioClient.Init(_accountSid, _authToken);
        }
        public async Task SendSmsAsync(string toPhone, string message)
        {
            var response= await MessageResource.CreateAsync(
                body: message,
                from: new PhoneNumber(_fromPhone),
                to: new PhoneNumber(toPhone)
            );

            var data = string.Empty;
        }
    }
}
