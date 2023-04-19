using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;
using UAS.Application.Dto.Notification.GetNotification;
using UAS.Application.Repositories.Notification;

namespace UAS.Application.Features.Queries.Notification.GetAllNotification
{
    public class GetAllNotificationQueryHandler : IRequestHandler<GetAllNotificationQueryRequest, GetAllNotificationQueryResponse>
    {
        readonly INotificationService _notificationService;
        readonly IMapper _mapper;

        public GetAllNotificationQueryHandler(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        public  async Task<GetAllNotificationQueryResponse> Handle(GetAllNotificationQueryRequest request, CancellationToken cancellationToken)
        {
            GetAllNotificationResponse response = await _notificationService.GetAll();

            GetAllNotificationQueryResponse queryResponse = _mapper.Map<GetAllNotificationQueryResponse>(response);
            return queryResponse;
        }
    }
}
