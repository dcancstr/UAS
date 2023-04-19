using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Dto.Common;
using UAS.Application.Dto.Notification.CreateNotification;
using UAS.Application.Dto.Notification.GetNotification;
using UAS.Application.Dto.Notification.RemoveNotification;
using UAS.Application.Dto.Notification.UpdateNotification;
using UAS.Application.Utilities.Result.Common;

namespace UAS.Application.Abstractions.Services
{
    public interface INotificationService
    {
        Task<IResult> CreateAsync(CreateNotification createNotification);
        Task<IResult> Update(UpdateNotification updateNotification);
        Task<IResult> Remove(RemoveNotification removeNotification);
        Task<GetByIdNotificationResponse> GetByIdAsync(GetByIdNotification getByIdNotification);
        Task<GetAllNotificationResponse> GetAll();
        

    }
}
