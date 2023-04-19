using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;
using UAS.Application.Constans;
using UAS.Application.Dto.Common;
using UAS.Application.Dto.Notification.CreateNotification;
using UAS.Application.Dto.Notification.GetNotification;
using UAS.Application.Dto.Notification.RemoveNotification;
using UAS.Application.Dto.Notification.UpdateNotification;
using UAS.Application.Features.Commands.Notification.CreateNotificationCommand;
using UAS.Application.Features.Commands.Notification.RemoveNotificationCommand;
using UAS.Application.Features.Commands.Notification.UpdateNotificationCommand;
using UAS.Application.Features.Queries.Notification.GetAllNotification;
using UAS.Application.Features.Queries.Notification.GetByIdNotification;
using UAS.Application.Features.Queries.NotificationCategory.GetByIdNotificationCategory;
using UAS.Application.Repositories.Notification;
using UAS.Application.Utilities.Result.Common;
using UAS.Domain.Entities;

namespace UAS.Persistence.Services
{
    public class NotificationService : INotificationService
    {
        readonly INotificationReadRepository _notificationReadRepository;
        readonly INotificationWriteRepository _notificationWriteRepository;
        readonly IMapper _mapper;

        public NotificationService(INotificationReadRepository notificationReadRepository, INotificationWriteRepository notificationWriteRepository, IMapper mapper)
        {
            _notificationReadRepository = notificationReadRepository;
            _notificationWriteRepository = notificationWriteRepository;
            _mapper = mapper;
        }

        public async Task<IResult> CreateAsync(CreateNotification createNotification)
        {
            //Şimdilik kontrolü text ile yapalım daha sonra duruma göre revize edeceğim.
            Notification notification = await _notificationReadRepository.GetSingleAsync(x => x.Text == createNotification.Text);
            if (notification is not null) return new ErrorResult(Message.NotificationCreatedIsFailed);

            notification = _mapper.Map<Notification>(createNotification);
            await _notificationWriteRepository.AddAsync(notification);
            await _notificationWriteRepository.SaveAsync();

            return new SuccessResult(Message.NotificationCreatedIsSuccess);
        }

        public async Task<GetAllNotificationResponse> GetAll()
        {
            var totalCount = _notificationReadRepository.GetAll(false).Count();
            var notifications = _notificationReadRepository.GetAll(false).Include(x => x.NotificationCategory).Select(p => new
            {
                p.Id,
                p.Url,
                p.Text,
                p.SmsText,
                p.CDate,
                p.EDate,
                p.Visible,
                p.NotificationCategory,
                //p.User
            }).ToList();

            return new GetAllNotificationResponse()
            {
                Message = Message.NotificationIsListed,
                Succeeded = true,
                TotalNotificationCount = totalCount,
                Notifications = notifications
            };
        }

        public async Task<GetByIdNotificationResponse> GetByIdAsync(GetByIdNotification getByIdNotification)
        {

            Domain.Entities.Notification notification = await _notificationReadRepository.GetByIdAsync(getByIdNotification.Id);
            GetByIdNotificationResponse response = new();
            if (notification==null)
            {
                response.Message = Message.NotificationGetByIdIsFailed;
                response.Succeeded = false;
                return response;    
            }
            else
            {
                response = _mapper.Map<GetByIdNotificationResponse>(notification);
                response.Message = Message.NotificationGetByIdIsSuccess;
                response.Succeeded = true;
                return response;
            }
            
        }

        public async Task<IResult> Remove(RemoveNotification removeNotification)
        {
            Notification notification = await _notificationReadRepository.GetSingleAsync(x => x.Id == removeNotification.Id);
            if (notification is null) return new ErrorResult(Message.NotificationRemoveIsFailed);

            await _notificationWriteRepository.RemoveAsync(removeNotification.Id);
            await _notificationWriteRepository.SaveAsync();

            return new SuccessResult(Message.NotificationRemoveIsSuccesss);
        }

        public async Task<IResult> Update(UpdateNotification updateNotification)
        {
            Domain.Entities.Notification notification = await _notificationReadRepository.GetByIdAsync(updateNotification.Id,false);
            if (notification is null) return new ErrorResult(Message.NotificationIsUpdatedFail);

            //Automapperde verileri eşitlerken id den dolayı hata alıyor daha sonra tekrar bak, şimdilik bu haliyle çalıştığı için bıraktım.
            //notification.Text = updateNotification.Text;
            //notification.SmsText = updateNotification.SmsText;
            //notification.Url = updateNotification.Url;
            notification = _mapper.Map<Notification>(updateNotification);

            _notificationWriteRepository.Update(notification);
            await _notificationWriteRepository.SaveAsync();

            return new SuccessResult(Message.NotificationIsUpdatedSuccess);
        }

      

       
    }
}
