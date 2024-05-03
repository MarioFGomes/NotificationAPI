using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.NotificationDevice.CreateNotificationDevice; 
public class CreateNotificationDeviceValidator: AbstractValidator<CreateNotificationDeviceCommand>
{
    public CreateNotificationDeviceValidator()
    {
        RuleFor(c => c.device_type).NotEmpty().WithMessage(ResourceErrorMessages.DeviceTypeEmpty);
        RuleFor(c => c.Owner).NotEmpty().WithMessage(ResourceErrorMessages.DeviceOwner);
        RuleFor(c => c.device_token).NotEmpty().WithMessage(ResourceErrorMessages.DeviceToken);
        RuleFor(c => c.device_token).MinimumLength(9).WithMessage(ResourceErrorMessages.DescritionLength);
    }
}
