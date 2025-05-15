using Auth.API.Models.Enums;

namespace Auth.API.Models
{
    public class GenerateOtpRequest
    {
        public string Username { get; set; }
        public OtpType Type { get; set; }
        public string SendTo { get; set; }


    }
}
