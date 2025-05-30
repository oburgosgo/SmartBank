using FluentValidation;
using Notification.API.Models;
using Notification.API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Notification.API.Validators
{
    public sealed class NotificationRequestValidator: AbstractValidator<SendNotificationRequest>
    {
        public NotificationRequestValidator() {
            Console.WriteLine("NotificationRequestValidator initialized");

            RuleFor(x => x.Message).NotEmpty().WithMessage("Message is required");
            RuleFor(x => x.Type).IsInEnum().WithMessage("Invalid Notification type");

            RuleFor(x=>x.Subject).NotEmpty().When(x=>x.Type == NotificationType.Email).WithMessage("Subject is required")
                .MaximumLength(200).WithMessage("Subject must be less than 200 characters");

            RuleFor(x => x.To).NotEmpty().WithMessage("To is required").
                Must((model, to) => IsValidDestination(to, model.Type)).WithMessage("To: Invalid format for selected type.");
        }


        private bool IsValidDestination(string to, NotificationType type)
        {

            var isValid = false;

            switch (type)
            {
                case NotificationType.Sms:
                    isValid = Regex.IsMatch(to ?? "", @"^\+?\d{10,15}$");
                    break;
                case NotificationType.Email:
                    isValid = new EmailAddressAttribute().IsValid(to);
                    break;
            }

            return isValid;
        }
    }
}
