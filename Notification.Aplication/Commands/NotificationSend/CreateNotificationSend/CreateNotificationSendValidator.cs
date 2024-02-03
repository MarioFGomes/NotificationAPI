using FluentValidation;
using Notification.Aplication.Commands.NotificationDevice.CreateNotificationDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.NotificationSend.CreateNotificationSend; 
public class CreateNotificationSendValidator : AbstractValidator<CreateNotificationSendCommand> 
{

    public CreateNotificationSendValidator()
    {
        RuleFor(c => c.to).NotEmpty().MinimumLength(5).WithMessage("Invalid Email");
        RuleFor(c => c.from).NotEmpty().MinimumLength(5).WithMessage("Invalid Email");
    }
}
