using AutoMapper;
using MediatR;
using Notification.Aplication.Commands.NotificationDevice.CreateNotificationDevice;
using Notification.Aplication.ExceptionBase;
using Notification.Domain.Repositories;


namespace Notification.Aplication.Commands.NotificationSend.CreateNotificationSend;
public class CreateNotificationSendCommandHandler : IRequestHandler<CreateNotificationSendCommand, Unit> 
{
    private readonly IUnitofWork _unitofWork;
    private readonly IMapper _mapper;
    private readonly INotificationSendRepository _notificationSendRepository;
    private readonly ISendEmailService _SendEmailService;
    public CreateNotificationSendCommandHandler(IUnitofWork unitofWork, IMapper mapper, INotificationSendRepository notificationSendRepository, ISendEmailService sendEmailService)
    {
        _mapper= mapper;
        _notificationSendRepository= notificationSendRepository;
        _unitofWork= unitofWork;
        _SendEmailService = sendEmailService;
    }
    public async Task<Unit> Handle(CreateNotificationSendCommand request, CancellationToken cancellationToken) 
    {
        await Validator(request);

        await _SendEmailService.SendNativeAsync("Email de Teste", "Este é um email de teste", "narew59353@giratex.com", "Rodrigo Gomes");

        var result=_mapper.Map<Notification.Domain.Entities.NotificationSend>(request);

        await _notificationSendRepository.CreateAsync(result);

       await  _unitofWork.Commit();

        return Unit.Value;
    }

    private Task Validator(CreateNotificationSendCommand request) 
    {
        var validator = new CreateNotificationSendValidator();
        var result = validator.Validate(request);

        if (!result.IsValid) {
            var messageError = result.Errors.Select(e => e.ErrorMessage).ToList();

            throw new ValidationErrorException(messageError);
        }

        return Task.CompletedTask;
    }
}
