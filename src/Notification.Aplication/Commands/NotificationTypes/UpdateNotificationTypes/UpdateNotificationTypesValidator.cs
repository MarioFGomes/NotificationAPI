using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.NotificationTypes.UpdateNotificationTypes;
public class UpdateNotificationTypesValidator : AbstractValidator<UpdateNotificationTypesCommand>
{
    public UpdateNotificationTypesValidator()
    {
        RuleFor(c => c.Id).NotEmpty().WithMessage(ResourceErrorMessages.NotificationId);
        RuleFor(c => c.name).NotEmpty().WithMessage(ResourceErrorMessages.NameEmpty);
        RuleFor(c => c.name).MinimumLength(5).WithMessage(ResourceErrorMessages.NameLength);
        RuleFor(c => c.description).NotEmpty().WithMessage(ResourceErrorMessages.DescriptionEmpty);
        RuleFor(c => c.description).MinimumLength(8).WithMessage(ResourceErrorMessages.DescritionLength);
    }
}
