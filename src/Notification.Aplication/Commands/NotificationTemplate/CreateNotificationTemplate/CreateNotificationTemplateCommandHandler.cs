using AutoMapper;
using MediatR;
using Notification.Aplication.Commands.NotificationDevice.CreateNotificationDevice;
using Notification.Aplication.ExceptionBase;
using Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.NotificationTemplate.CreateNotificationTemplate;
public class CreateNotificationTemplateCommandHandler : IRequestHandler<CreateNotificationTemplateCommand, Guid> 
{
    private readonly INotificationTemplateRepository _notificationTemplateRepository;
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;
    public CreateNotificationTemplateCommandHandler(INotificationTemplateRepository notificationTemplateRepository, IUnitofWork unitofWork, IMapper mapper)
    {
        _notificationTemplateRepository = notificationTemplateRepository;
        _unitofWork = unitofWork;
        _mapper = mapper;
    }
    public async Task<Guid> Handle(CreateNotificationTemplateCommand request, CancellationToken cancellationToken) 
    {
        await Validator(request);

        var notificationTemplate = _mapper.Map<Notification.Domain.Entities.NotificationTemplate>(request);

        await _notificationTemplateRepository.CreateAsync(notificationTemplate);

        await _unitofWork.Commit();

        return notificationTemplate.Id;
    }

    private Task Validator(CreateNotificationTemplateCommand request) {
        var validator = new CreateNotificationTemplateValidator();
        var result = validator.Validate(request);

        if (!result.IsValid) {
            var messageError = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ValidationErrorException(messageError);
        }

        return Task.CompletedTask;
    }
}
