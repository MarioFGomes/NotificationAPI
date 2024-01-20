using AutoMapper;
using MediatR;
using Notification.Aplication.ExceptionBase;
using Notification.Domain.Entities;
using Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.CreateNotificationTypes;
public class CreateNotificationsTypesCommandHandler : IRequestHandler<CreateNotificationsTypesCommand, Guid> {

    private readonly INotificationTypeRepository _notificationTypeRepository;
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;
    public CreateNotificationsTypesCommandHandler(INotificationTypeRepository notificationType, IUnitofWork unitofWork, IMapper mapper)
    {
        _notificationTypeRepository= notificationType;
        _mapper= mapper;
        _unitofWork= unitofWork;

    }
    public async Task<Guid> Handle(CreateNotificationsTypesCommand request, CancellationToken cancellationToken) 
    {
        await Validator(request);

        var notificationType = _mapper.Map<NotificationType>(request);

        await _notificationTypeRepository.CreateAsync(notificationType);

        await _unitofWork.Commit();

        return notificationType.Id;
    }

    private async Task Validator(CreateNotificationsTypesCommand request) 
    {
        var validator = new CreateNotificationsTypesValidator();
        var result=validator.Validate(request);

        if (!result.IsValid) {
            var messageError = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ValidationErrorException(messageError);
        }
    }
}
