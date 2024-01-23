using AutoMapper;
using MediatR;
using Notification.Aplication.Commands.NotificationTypes.UpdateNotificationTypes;
using Notification.Aplication.ExceptionBase;
using Notification.Domain.Entities;
using Notification.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notification.Aplication.Commands.NotificationTypes.UpdateNotificationTypes
{
    public class UpdateNotificationTypesCommandHandler : IRequestHandler<UpdateNotificationTypesCommand, Unit>
    {
        private readonly INotificationTypeRepository _notificationTypeRepository;
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        public UpdateNotificationTypesCommandHandler(INotificationTypeRepository notificationType, IUnitofWork unitofWork, IMapper mapper)
        {
            _notificationTypeRepository = notificationType;
            _mapper = mapper;
            _unitofWork = unitofWork;
        }
        public async Task<Unit> Handle(UpdateNotificationTypesCommand request, CancellationToken cancellationToken)
        {
            await Validator(request);

            var notificationType = await _notificationTypeRepository.GetbyIdAsync(request.Id) ?? throw new GenericErrorException(ResourceErrorMessages.NotificationNotFound);

            notificationType = _mapper.Map(request, notificationType);

            notificationType.LastUpdate = DateTime.UtcNow;

            await _notificationTypeRepository.UpdateAsync(notificationType);

            await _unitofWork.Commit();

            return Unit.Value;
        }

        private async Task Validator(UpdateNotificationTypesCommand request)
        {
            var validator = new UpdateNotificationTypesValidator();
            var result = validator.Validate(request);

            var notificationType = await _notificationTypeRepository.GetbyIdAsync(request.Id);

            if (notificationType is null)
            {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure("Type", "this type of notification not exists"));
            }

            if (!result.IsValid)
            {
                var messageError = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ValidationErrorException(messageError);
            }

        }
    }
}
