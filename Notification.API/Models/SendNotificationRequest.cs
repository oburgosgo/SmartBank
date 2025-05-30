﻿using Notification.API.Models.Enums;
using System.Globalization;

namespace Notification.API.Models
{
    public class SendNotificationRequest
    {
        public string Message { get; set; }
        public string Subject { get; set; }
        public NotificationType Type { get; set; }
        public string To { get; set; }  
    }
}
