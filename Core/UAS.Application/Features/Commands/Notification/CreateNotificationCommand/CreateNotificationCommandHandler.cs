using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;
using UAS.Application.Dto.Common;
using UAS.Application.Dto.Notification.CreateNotification;
using UAS.Application.Repositories.Notification;
using UAS.Application.Utilities.Result.Common;

namespace UAS.Application.Features.Commands.Notification.CreateNotificationCommand
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommandRequest, CreateNotificationCommandResponse>
    {

        readonly INotificationService _notificationService;
        readonly IMapper _mapper;

        public CreateNotificationCommandHandler(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public async Task<CreateNotificationCommandResponse> Handle(CreateNotificationCommandRequest request, CancellationToken cancellationToken)
        {
            CreateNotification createNotification = _mapper.Map<CreateNotification>(request);
            var response = await _notificationService.CreateAsync(createNotification);
            CreateNotificationCommandResponse createNotificationCommandResponse = _mapper.Map<CreateNotificationCommandResponse>(response);

            return createNotificationCommandResponse;
        }
    }
}
