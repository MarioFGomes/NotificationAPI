﻿using AutoMapper;
using MediatR;
using Notification.Aplication.ExceptionBase;
using Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.NotificationTypes.DeleteNotificationTypes;
public class DeleteNotificationTypeCommandHandler : IRequestHandler<DeleteNotificationTypeCommand, Unit> 
{
    private readonly INotificationTypeRepository _notificationTypeRepository;
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;
    public DeleteNotificationTypeCommandHandler(INotificationTypeRepository notificationTypeRepository, IUnitofWork unitofWork, IMapper mapper)
    {
        _notificationTypeRepository = notificationTypeRepository;
        _unitofWork = unitofWork;
        _mapper = mapper;
    }
    public async Task<Unit> Handle(DeleteNotificationTypeCommand request, CancellationToken cancellationToken) 
    {
        var notificationType = await _notificationTypeRepository.GetbyIdAsync(request.Id) ?? throw new GenericErrorException(ResourceErrorMessages.NotificationType);

        notificationType = _mapper.Map(request, notificationType);

        notificationType.Status = 0;
        notificationType.LastUpdate = DateTime.UtcNow;

        await _notificationTypeRepository.UpdateAsync(notificationType);

        await _unitofWork.Commit();

        return Unit.Value;
    }
}
