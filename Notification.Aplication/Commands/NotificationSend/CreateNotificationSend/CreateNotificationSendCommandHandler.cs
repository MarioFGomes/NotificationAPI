using AutoMapper;
using MediatR;
using Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.NotificationSend.CreateNotificationSend;
public class CreateNotificationSendCommandHandler : IRequestHandler<CreateNotificationSendCommand, Unit> 
{
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;
    private readonly INotificationSendRepository _notificationSendRepository;
    public CreateNotificationSendCommandHandler(IUnitofWork unitofWork, IMapper mapper, INotificationSendRepository notificationSendRepository)
    {
        _mapper= mapper;
        _notificationSendRepository= notificationSendRepository;
        _unitofWork= unitofWork;
    }
    public Task<Unit> Handle(CreateNotificationSendCommand request, CancellationToken cancellationToken) 
    {
        throw new NotImplementedException();
    }
}
