using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;
using UAS.Application.Dto.Common;
using UAS.Application.Dto.Notification.UpdateNotification;
using UAS.Application.Repositories.Notification;

namespace UAS.Application.Features.Commands.Notification.UpdateNotificationCommand
{
    public class UpdateNotificationCommandHandler : IRequestHandler<UpdateNotificationCommandRequest, UpdateNotificationCommandResponse>
    {
        readonly INotificationService _notificationService;
        readonly IMapper _mapper;

        public UpdateNotificationCommandHandler(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public async Task<UpdateNotificationCommandResponse> Handle(UpdateNotificationCommandRequest request, CancellationToken cancellationToken)
        {
            UpdateNotification updateNotification = _mapper.Map<UpdateNotification>(request);
            var response = await _notificationService.Update(updateNotification);
            UpdateNotificationCommandResponse updateNotificationCommandResponse = _mapper.Map<UpdateNotificationCommandResponse>(response);

            return updateNotificationCommandResponse;
        }
    }
}
