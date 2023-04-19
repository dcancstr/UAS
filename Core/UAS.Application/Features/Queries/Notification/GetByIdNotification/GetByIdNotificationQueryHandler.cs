using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;
using UAS.Application.Dto.Notification.GetNotification;
using UAS.Application.Repositories.Notification;
using UAS.Domain.Entities;

namespace UAS.Application.Features.Queries.Notification.GetByIdNotification
{
    public class GetByIdNotificationQueryHandler : IRequestHandler<GetByIdNotificationQueryRequest, GetByIdNotificationQueryResponse>
    {
        readonly INotificationService _notificationService;
        readonly IMapper _mapper;

        public GetByIdNotificationQueryHandler(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public async Task<GetByIdNotificationQueryResponse> Handle(GetByIdNotificationQueryRequest request, CancellationToken cancellationToken)
        {
            Dto.Notification.GetNotification.GetByIdNotification getByIdNotification = _mapper.Map<Dto.Notification.GetNotification.GetByIdNotification>(request);
            GetByIdNotificationResponse response = await _notificationService.GetByIdAsync(getByIdNotification);

            GetByIdNotificationQueryResponse queryresponse = _mapper.Map<GetByIdNotificationQueryResponse>(response);

            return queryresponse; 

        }
    }
}
