using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;
using UAS.Application.Dto.Common;
using UAS.Application.Dto.Notification.RemoveNotification;
using UAS.Application.Repositories.Notification;

namespace UAS.Application.Features.Commands.Notification.RemoveNotificationCommand
{
   
    public class RemoveNotificationCommandHandler : IRequestHandler<RemoveNotificationCommandRequest, RemoveNotificationCommandResponse>
    {
        readonly INotificationService _notificationService;
        readonly IMapper _mapper;

        public RemoveNotificationCommandHandler(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public async Task<RemoveNotificationCommandResponse> Handle(RemoveNotificationCommandRequest request, CancellationToken cancellationToken)
        {
            RemoveNotification removeNotification = _mapper.Map<RemoveNotification>(request);
            var response = await _notificationService.Remove(removeNotification);

            RemoveNotificationCommandResponse removeNotificationCommandResponse = _mapper.Map<RemoveNotificationCommandResponse>(response);
            return removeNotificationCommandResponse;
        }
    }
}
