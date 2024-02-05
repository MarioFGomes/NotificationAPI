using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.NotificationTemplate.CreateNotificationTemplate; 
public class CreateNotificationTemplateValidator : AbstractValidator<CreateNotificationTemplateCommand> 
{
    public CreateNotificationTemplateValidator()
    {
        RuleFor(c => c.title).NotEmpty().WithMessage(ResourceErrorMessages.TemplateTitle);
        RuleFor(c => c.description).NotEmpty().WithMessage(ResourceErrorMessages.TemplateDescription);
        RuleFor(c => c.body).NotEmpty().WithMessage(ResourceErrorMessages.TemplateBody);
        RuleFor(c => c.NotificationTypeId).NotNull().WithMessage(ResourceErrorMessages.TamplateType);
    }
}
    
