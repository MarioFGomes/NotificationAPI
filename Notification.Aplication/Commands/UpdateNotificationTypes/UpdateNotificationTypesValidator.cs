using FluentValidation;
using Notification.Aplication.Commands.UpdateNotificationType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.UpdateNotificationTypes; 
public class UpdateNotificationTypesValidator: AbstractValidator<UpdateNotificationTypesCommand> 
{
    public UpdateNotificationTypesValidator()
    {
        RuleFor(c => c.Id).NotEmpty().WithMessage("Id can not be empty");
        RuleFor(c => c.name).NotEmpty().WithMessage("name cannot be empty");
        RuleFor(c => c.name).MinimumLength(5).WithMessage("the name must contain at least 5 letters");
        RuleFor(c => c.description).NotEmpty().WithMessage("description cannot be empty");
        RuleFor(c => c.description).MinimumLength(8).WithMessage("the description must contain at least 8 letters");
    }
}
