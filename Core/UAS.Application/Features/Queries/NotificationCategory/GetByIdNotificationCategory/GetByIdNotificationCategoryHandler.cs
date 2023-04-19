using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Repositories.NotificationCategory;

namespace UAS.Application.Features.Queries.NotificationCategory.GetByIdNotificationCategory
{
    public class GetByIdNotificationCategoryHandler : IRequestHandler<GetByIdNotificationCategoryRequest, GetByIdNotificationCategoryResponse>
    {
        readonly INotificationCategoryReadRepository _notificationCategoryReadRepository;

        public GetByIdNotificationCategoryHandler(INotificationCategoryReadRepository notificationCategoryReadRepository)
        {
            _notificationCategoryReadRepository = notificationCategoryReadRepository;
        }

        public async Task<GetByIdNotificationCategoryResponse> Handle(GetByIdNotificationCategoryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.NotificationCategory notificationCategory = await _notificationCategoryReadRepository.GetByIdAsync(request.Id);

            return new GetByIdNotificationCategoryResponse()
            {
                BackgroundColor = notificationCategory.BackgroundColor,
                MailTheme = notificationCategory.MailTheme,
                Name = notificationCategory.Name,
                ShownOnPanel = notificationCategory.ShownOnPanel,
                Notifications = notificationCategory.Notifications
            };

        }
    }
}
