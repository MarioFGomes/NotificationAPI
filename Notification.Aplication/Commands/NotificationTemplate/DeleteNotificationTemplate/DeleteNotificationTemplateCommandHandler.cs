using AutoMapper;
using MediatR;
using Notification.Aplication.ExceptionBase;
using Notification.Domain.Enum;
using Notification.Domain.Repositories;


namespace Notification.Aplication.Commands.NotificationTemplate.DeleteNotificationTemplate;
public class DeleteNotificationTemplateCommandHandler : IRequestHandler<DeleteNotificationTemplateCommand, Unit> 
{
    private readonly INotificationTemplateRepository _notificationTemplateRepository;
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;

    public DeleteNotificationTemplateCommandHandler(INotificationTemplateRepository notificationTemplateRepository, IMapper mapper, IUnitofWork unitofWork)
    {
        _notificationTemplateRepository = notificationTemplateRepository;
        _mapper = mapper;
        _unitofWork = unitofWork;
    }
    public async Task<Unit> Handle(DeleteNotificationTemplateCommand request, CancellationToken cancellationToken) 
    {
        var notificationTemplate = await _notificationTemplateRepository.GetbyIdAsync(request.Id) ?? throw new GenericErrorException(ResourceErrorMessages.NotificationNotFound);
        
        notificationTemplate.Status = (int)NotificationStatus.Deleted;
        
        notificationTemplate.LastUpdate= DateTime.UtcNow;

        await _notificationTemplateRepository.UpdateAsync(notificationTemplate);

        await _unitofWork.Commit();

        return Unit.Value;
    }
}
