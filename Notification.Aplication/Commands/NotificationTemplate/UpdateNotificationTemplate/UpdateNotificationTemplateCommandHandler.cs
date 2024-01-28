using AutoMapper;
using MediatR;
using Notification.Aplication.Commands.NotificationTemplate.CreateNotificationTemplate;
using Notification.Aplication.ExceptionBase;
using Notification.Domain.Enum;
using Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.NotificationTemplate.UpdateNotificationTemplate; 
public class UpdateNotificationTemplateCommandHandler : IRequestHandler<UpdateNotificationTemplateCommand, Unit>
{
    private readonly INotificationTemplateRepository _notificationTemplateRepository;
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public UpdateNotificationTemplateCommandHandler(INotificationTemplateRepository notificationTemplateRepository, IMapper mapper, IUnitofWork unitofWork)
    {
        _notificationTemplateRepository=notificationTemplateRepository;
        _mapper=mapper;
        _unitofWork=unitofWork;
    }

    public async Task<Unit> Handle(UpdateNotificationTemplateCommand request, CancellationToken cancellationToken) 
    {
        await Validator(request);

        var notificationTemplate = await _notificationTemplateRepository.GetbyIdAsync(request.Id) ?? throw new GenericErrorException(ResourceErrorMessages.NotificationNotFound);

        notificationTemplate = _mapper.Map(request, notificationTemplate);

        notificationTemplate.LastUpdate = DateTime.UtcNow;

        await _notificationTemplateRepository.UpdateAsync(notificationTemplate);

        await _unitofWork.Commit();

        return Unit.Value;
    }

    private Task Validator(UpdateNotificationTemplateCommand request) {
        var validator = new UpdateNotificationTemplateValidator();
        var result = validator.Validate(request);

        if (!result.IsValid) {
            var messageError = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ValidationErrorException(messageError);
        }

        return Task.CompletedTask;
    }
}
