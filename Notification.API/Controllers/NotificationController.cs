using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notification.API.Interfaces;
using Notification.API.Models;

namespace Notification.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class NotificationController : ControllerBase
    {

        private readonly INotificationSender _notificationSender;

        public NotificationController(INotificationSender notificationSender)
        {
            this._notificationSender = notificationSender;
        }

        [HttpPost]
        public async Task<IActionResult> SendNotification([FromBody]SendNotificationRequest request)
        {
            var result = await _notificationSender.SendNotification(request);
            return Ok(result);
        }

    }
}
