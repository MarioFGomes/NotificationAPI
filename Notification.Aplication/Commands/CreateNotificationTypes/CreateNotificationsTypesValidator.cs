using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.CreateNotificationTypes; 
public class CreateNotificationsTypesValidator: AbstractValidator<CreateNotificationsTypesCommand> 
{
    public CreateNotificationsTypesValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("name cannot be empty");
        RuleFor(c => c.Name).MinimumLength(5).WithMessage("the name must contain at least 5 letters");
        RuleFor(c => c.Description).NotEmpty().WithMessage("description cannot be empty");
        RuleFor(c => c.Description).MinimumLength(8).WithMessage("the description must contain at least 5 letters");
    }
}
